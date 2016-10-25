using AnimeTidy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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

		public AnimeInfo(MainForm mainForm)
		{
			this._mainForm = mainForm;

			//this._isNew = true;
			//this._isSaved = true;
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

			//this.Total = it;
			//this.Space = lt;
			//this.Uid = ut;

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

			if (lstAnime.Count != itotal)
			{
				lstAnime.Clear();

				return null;
			}

			//this.IsCreated = true;
			//this.IsSaved = true;

			this.IsCreated = false;

			this.Total = itotal;
			this.Space = lspace;
			this.Uid = luid;

			return lstAnime;
		}

		public void UpdateStatusStrip()
		{
			Form.tabControlMain.SelectedTab.Text = this.Name;
			Form.tabControlMain.SelectedTab.ToolTipText = this.Path;
		}

		protected override void OpenDeal()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = TidyConst.Filter;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				if (this.Path != ofd.FileName)
				{
					//_ai.Path = ofd.FileName;
					//_ai.Name = ofd.SafeFileName;
					List<Anime> lstAnime;
					if ((lstAnime = this.LoadAnimeList(ofd.FileName)) != null)
					{
						//this.IsCreated = false;

						this._animeList.Clear();
						this._animeList = lstAnime;

						this.Name = ofd.SafeFileName;
						this.Path = ofd.FileName;
						this.IsCreated = true;
					}
				}
			}
		}

		public void UpdateStatusStripTotal()
		{
			// test
			Form.tabControlMain.TabPages[1].Text = this.Total <= 0 ? "Total: -" :
				String.Format("Total: {0}", this.Total);
		}
	}
}
