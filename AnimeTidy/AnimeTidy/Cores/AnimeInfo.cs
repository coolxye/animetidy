using AnimeTidy.Forms;
using AnimeTidy.Models;
using AnimeTidyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AnimeTidy.Cores
{
	public class AnimeInfo : TidyInfo
	{
		public override TidyType Type
		{
			get
			{ return TidyType.Anime; }
		}

		private String Summary
		{
			get
			{ return String.Join("\t", Total, Space, Uid); }
		}

		private List<Anime> _animeList;
		public List<Anime> AnimeList
		{
			get
			{ return this._animeList ?? (this._animeList = LoadAnimeList(this.Path)); }
		}

		private MainForm _mainForm;
		private MainForm Form
		{
			get
			{ return this._mainForm; }
		}

		private Stack<AnimeStack> _aniStack;
		public Stack<AnimeStack> AniStack
		{
			get
			{ return this._aniStack ?? (this._aniStack = new Stack<AnimeStack>()); }
		}

		public AnimeInfo(MainForm mainForm)
		{
			this._mainForm = mainForm;
		}

		public List<Anime> LoadAnimeList(String path)
		{
			StreamReader sr = new StreamReader(path);
			string line = sr.ReadLine();

			if (String.IsNullOrEmpty(line))
			{
				sr.Close();

				return null;
			}

			string[] info = line.Split('\t');
			if (info.Length != TidyConst.AnimeKeyLen)
			{
				sr.Close();

				return null;
			}

			int itotal;
			long lspace;
			long luid;
			if (!Int32.TryParse(info[0], out itotal) ||
				!Int64.TryParse(info[1], out lspace) ||
				!Int64.TryParse(info[2], out luid))
			{
				MessageBox.Show("The line 1 is wrong.", "Read error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				sr.Close();

				return null;
			}

			List<Anime> lstAnime = new List<Anime>();
			int iErr = 1;
			try
			{
				while (!String.IsNullOrEmpty(line = sr.ReadLine()))
				{
					iErr++;
					info = line.Split('\t');

					Anime ani = new Anime(UInt32.Parse(info[0]));
					ani.Title = info[1];
					ani.Name = info[2];
					ani.Year = Int32.Parse(info[3]);
					ani.Season = (AirSeason)Enum.Parse(typeof(AirSeason), info[4]);
					ani.Type = (MediaType)Enum.Parse(typeof(MediaType), info[5]);
					ani.Format = (MergeFormat)Enum.Parse(typeof(MergeFormat), info[6]);
					ani.SubTeam = info[7];
					ani.SubStyle = (SubStyle)Enum.Parse(typeof(SubStyle), info[8]);
					ani.Path = info[9];
					ani.Size = Int64.Parse(info[10]);
					ani.Store = Boolean.Parse(info[11]);
					ani.Enjoy = Boolean.Parse(info[12]);
					ani.Grade = Int32.Parse(info[13]);
					ani.CreateTime = DateTime.Parse(info[14]);
					ani.UpdateTime = DateTime.Parse(info[15]);
					ani.Kana = info[16];
					ani.Episode = info[17];
					ani.Inc = info[18];
					ani.Note = info[19];

					lstAnime.Add(ani);
				}
			}
			catch (IndexOutOfRangeException)
			{
				MessageBox.Show(String.Format("The line {0} is out of index.", iErr), "Read error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (FormatException)
			{
				MessageBox.Show(String.Format("The line {0} has wrong data.", iErr), "Read error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			finally
			{
				sr.Close();
			}

			// exception check
			if (lstAnime.Count != itotal)
			{
				lstAnime.Clear();

				return null;
			}

			//this.IsCreated = true;
			//this.IsSaved = true;

			// init: no event -> no clear
			// open: event -> clear all
			this.IsCreated = false;

			this.Total = itotal;
			this.Space = lspace;
			this.Uid = luid;

			return lstAnime;
		}

		protected override void OpenDeal()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = TidyConst.Filter;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				if (this.Path != ofd.FileName)
				{
					List<Anime> lstAnime;
					if ((lstAnime = this.LoadAnimeList(ofd.FileName)) != null)
					{
						// 程序初始时，执行打开，这里是空
						if (this._animeList != null)
							this._animeList.Clear();
						this._animeList = lstAnime;

						this.Name = ofd.SafeFileName;
						this.Path = ofd.FileName;
						this.IsCreated = true;

						// update TidyXml todo upgrade
						this.UpdateXmlDeal();
					}
				}
			}
		}

		protected override void SaveDeal(ObjectListView olv)
		{
			SaveToFile(this.Path, olv);

			// undo clear
			this.AniStack.Clear();
		}

		protected override void UpdateXmlDeal()
		{
			Form.TXml.UpdateXmlFile(this.Type, this.Name, this.Path);
		}

		public void UpdateSelectedTab(string txt, string tip)
		{
			Form.tabControlMain.SelectedTab.Text = txt;
			Form.tabControlMain.SelectedTab.ToolTipText = tip;
		}

		public void UpdateStatusStripSelected(string name)
		{
			Form.tsslSelName.Text = String.Format("Selected: {0}", name);
		}

		public void UpdateStatusStripTotal()
		{
			Form.tsslTotal.Text = this.Total <= 0 ? "Total: -" :
				String.Format("Total: {0}", this.Total);
		}

		public void UpdateStatusStripSpace()
		{
			Form.tsslTotSpace.Text = String.Format("Total Size: {0}", FormatAnimeSize(this.Space));
		}

		public void UpdateToolStripButton()
		{
			Form.tsbtnSave.Enabled = !this.IsSaved;
			Form.tsbtnUndo.Enabled = !this.IsSaved;
		}

		public override void AddInfo(ObjectListView olv)
		{
			Anime a = null;

			AddAnime aa = new AddAnime(olv, a);
			aa.FormClosed += aa_FormClosed;
			aa.Show();
		}

		private void aa_FormClosed(object sender, FormClosedEventArgs e)
		{
			AddAnime aa = sender as AddAnime;
			if (aa.DialogResult == DialogResult.OK)
			{
				this.Total++;
				this.Space += aa.Ani.Size;
				aa.Ani.ID = this.Uid++;
				aa.ListView.AddObject(aa.Ani);

				// undo
				this.AniStack.Push(new AnimeStack(EditType.Add, aa.Ani));

				base.AddInfo(aa.ListView);
			}
		}

		public override void ModifyInfo(ObjectListView olv)
		{
			Anime a = olv.SelectedObject as Anime;
			if (a != null)
			{
				ModAnime ma = new ModAnime(olv, a);
				ma.FormClosed += ma_FormClosed;
				ma.Show();

				// undo push
				this.AniStack.Push(new AnimeStack(EditType.ModifyBefo, a.CopyForMod()));
			}
		}

		private void ma_FormClosed(object sender, FormClosedEventArgs e)
		{
			ModAnime ma = sender as ModAnime;
			if (ma.DialogResult == DialogResult.OK &&
				ma.IsModified)
			{
				long lsize = ma.Ani.Size;
				if (ma.Ani.Path == String.Empty)
					ma.Ani.Size = 0L;
				// up
				else if (AnimeInfo.IsStorageReady())
					ma.Ani.Size = Anime.GetSize(ma.Ani.Path);
				this.Space += ma.Ani.Size - lsize;

				ma.ListView.RefreshObject(ma.Ani);
				if (ma.ListView.SelectedObject == ma.Ani)
				{
					Form.tsslSelSpace.Text = String.Format("Selected Size: {0}", FormatAnimeSize(ma.Ani.Size));
					Form.UpdateTabAnime(ma.Ani.Remark);
				}

				// undo push2
				this.AniStack.Push(new AnimeStack(EditType.ModifyAftr, ma.Ani));

				base.ModifyInfo(ma.ListView);
			}
			else
			{
				this.AniStack.Pop();
			}
		}

		public override void DuplicateInfo(ObjectListView olv)
		{
			if (olv.SelectedIndices.Count > 0)
			{
				foreach (Anime a in olv.SelectedObjects)
				{
					Anime aCopy = new Anime(a, this.Uid);
					this.Total++;
					this.Space += aCopy.Size;
					this.Uid++;
					olv.AddObject(aCopy);

					// undo
					this.AniStack.Push(new AnimeStack(EditType.Copy, aCopy));
				}

				base.DuplicateInfo(olv);
			}
		}

		public override void DeleteInfo(ObjectListView olv)
		{
			if (olv.SelectedIndices.Count > 0)
			{
				foreach (Anime a in olv.SelectedObjects)
				{
					this.Total--;
					this.Space -= a.Size;

					// undo
					this.AniStack.Push(new AnimeStack(EditType.Delete, a));
				}

				olv.RemoveObjects(olv.SelectedObjects);
				base.DeleteInfo(olv);
			}
		}

		public override void UndoInfo(ObjectListView olv)
		{
			Anime ma = null;
			foreach (AnimeStack astk in this.AniStack)
			{
				switch (astk.EType)
				{
					case EditType.Add:
					case EditType.Copy:
						this.Total--;
						this.Space -= astk.EAnime.Size;
						this.Uid--;
						olv.RemoveObject(astk.EAnime);

						break;

					case EditType.ModifyBefo:
						this.Space += astk.EAnime.Size - ma.Size;
						ma.RevertFromMod(astk.EAnime);
						olv.RefreshObject(ma);
						// bug sel name also change
						if (olv.SelectedObject == ma)
						{
							Form.tsslSelName.Text = String.Format("Selected: {0}", ma.Name);
							Form.tsslSelSpace.Text = String.Format("Selected Size: {0}", FormatAnimeSize(ma.Size));
						}
						break;

					case EditType.ModifyAftr:
						ma = astk.EAnime;
						break;

					case EditType.Delete:
						this.Total++;
						this.Space += astk.EAnime.Size;
						olv.AddObject(astk.EAnime);
						break;
				}
			}

			this.AniStack.Clear();

			base.UndoInfo(olv);
		}

		public override void RefreshInfo(ObjectListView olv)
		{
			if (!AnimeInfo.IsStorageReady())
				return;

			long lSize = 0L;
			long lSelSize = 0L;
			long lSpace = this.Space;
			bool bCheck = false;

			foreach (Anime a in olv.SelectedObjects)
			{
				if (a.Path.Length == 0)
					continue;

				lSize = Anime.GetSize(a.Path);
				if (a.Size != lSize)
				{
					bCheck = true;

					lSpace += lSize - a.Size;
					a.Size = lSize;
					olv.RefreshObject(a);
				}
				lSelSize += a.Size;
			}

			if (bCheck)
				base.RefreshInfo(olv);

			this.Space = lSpace;

			// Form SelSize update
			Form.tsslSelSpace.Text = String.Format("Selected Size: {0}", FormatAnimeSize(lSelSize));
		}

		public override void BackupInfo(ObjectListView olv)
		{
			SaveToFile(
				String.Format("{0}@{1}.bak",
					this.Path,
					DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss")),
				olv);
		}

		public void HandleSelectionChanged(ObjectListView olv)
		{
			int icount = olv.SelectedIndices.Count;
			if (icount == 0)
			{
				Form.tsbtnModify.Enabled = false;
				Form.tsbtnDuplicate.Enabled = false;
				Form.tsbtnDelete.Enabled = false;
				Form.tsbtnRefresh.Enabled = false;

				Form.tsslSelName.Text = "Selected: -";
				Form.tsslSelSpace.Text = "Selected Size: -";
			}
			else if (icount == 1)
			{
				Form.tsbtnModify.Enabled = true;
				Form.tsbtnDuplicate.Enabled = true;
				Form.tsbtnDelete.Enabled = true;
				Form.tsbtnRefresh.Enabled = true;

				Anime a = olv.SelectedObject as Anime;
				Form.tsslSelName.Text = String.Format("Selected: {0}", a.Name);
				Form.tsslSelSpace.Text = String.Format("Selected Size: {0}", FormatAnimeSize(a.Size));
			}
			else
			{
				Form.tsbtnModify.Enabled = false;
				Form.tsbtnDuplicate.Enabled = true;
				Form.tsbtnDelete.Enabled = true;
				Form.tsbtnRefresh.Enabled = true;

				long lc = 0L;
				foreach (Anime ac in olv.SelectedObjects)
					lc += ac.Size;
				Form.tsslSelName.Text = String.Format("Selected: {0}", icount);
				Form.tsslSelSpace.Text = String.Format("Selected Size: {0}", FormatAnimeSize(lc));
			}
		}

		private string FormatAnimeSize(long size)
		{
			long[] limits = new long[] { 1024 * 1024 * 1024, 1024 * 1024, 1024 };
			string[] units = new string[] { "GB", "MB", "KB" };

			for (int i = 0; i < limits.Length; i++)
			{
				if (size >= limits[i])
				{
					return String.Format("{0:#,##0.#0} " + units[i], ((double)size / limits[i]));
				}
			}

			return String.Format("{0} bytes", size);
		}

		private void SaveToFile(string path, ObjectListView olv)
		{
			StreamWriter sw = new StreamWriter(path, false, Encoding.Unicode);

			sw.WriteLine(this.Summary);

			foreach (Anime a in olv.Objects)
				sw.WriteLine(a.ToString());

			sw.Close();
		}
	}
}
