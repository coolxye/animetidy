using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnimeTidyLib;
using AnimeTidy.Models;
using AnimeTidy.Cores;

namespace AnimeTidy
{
	public partial class TabAnime : UserControl
	{
		public TabAnime()
		{
			InitializeComponent();
			InitModel();
		}

		private AnimeInfo _animeinfo;
		public AnimeInfo AnimeInfo
		{
			get
			{
				return this._animeinfo;
			}
			set
			{
				this._animeinfo = value;
				if (value != null)
					InitAnime();
			}
		}

		// Initalize the Format of the ObjectListView
		private void InitModel()
		{
			if (ObjectListView.IsVistaOrLater)
				this.Font = new Font("msyh", 8);

			this.olvAnime.AddDecoration(new EditingCellBorderDecoration(true));

			TypedObjectListView<Anime> tolv = new TypedObjectListView<Anime>(this.olvAnime);
			tolv.GenerateAspectGetters();

			// Name of Anime
			TypedColumn<Anime> tc = new TypedColumn<Anime>(this.olvColName);
			tc.AspectPutter = (Anime a, object opn) => { a.Name = opn.ToString(); };

			// Schedule of Anime
			tc = new TypedColumn<Anime>(this.olvColAirdate);
			tc.GroupKeyGetter = (Anime a) => a.Year;

			// Type of Anime
			tc = new TypedColumn<Anime>(this.olvColType);
			tc.AspectPutter = (Anime a, object opt) => { a.Type = (MediaType)opt; };
			tc.ImageGetter = (Anime a) =>
			{
				switch (a.Format)
				{
					case MergeFormat.MKV:
						return Properties.Resources.MKV;

					case MergeFormat.MP4:
						return Properties.Resources.MP4;

					case MergeFormat.AVI:
						return Properties.Resources.AVI;

					case MergeFormat.WMV:
						return Properties.Resources.WMV;

					case MergeFormat.M2TS:
						return Properties.Resources.M2TS;

					default:
						return -1;
				}
			};

			// SubTeam of Anime
			tc = new TypedColumn<Anime>(this.olvColSubTeam);
			tc.AspectPutter = (Anime a, object opp) => { a.SubTeam = opp.ToString(); };
			tc.ImageGetter = (Anime a) =>
			{
				switch (a.SubStyle)
				{
					case SubStyle.External:
						return Properties.Resources.External;

					case SubStyle.Sealed:
						return Properties.Resources.Sealed;

					case SubStyle.Embedded:
						return Properties.Resources.Embedded;

					default:
						return -1;
				}
			};

			// Size of Anime
			this.olvColSize.AspectToStringConverter = ots =>
			{
				long ls = (long)ots;

				if (ls == 0L)
					return "-";
				else if (ls >= 1000000000L)
					return String.Format("{0:#,##0.#0} G", ls / 1073741824D);
				else
					return String.Format("{0:#,##0.#0} M", ls / 1048576D);
			};
			this.olvColSize.MakeGroupies(
				new long[] { 5368709120L, 10737418240L },
				new string[] { "0~5 GB", "5~10 GB", ">10 GB" }
				);

			// Store of Anime
			tc = new TypedColumn<Anime>(this.olvColStore);
			tc.AspectPutter = (Anime a, object opg) => { a.Store = (bool)opg; };
			this.olvColStore.Renderer = new MappedImageRenderer(true, Properties.Resources.Accept, false, Properties.Resources.Alert);

			// Enjoy of Anime
			tc = new TypedColumn<Anime>(this.olvColEnjoy);
			tc.AspectPutter = (Anime a, object opv) => { a.Enjoy = (bool)opv; };
			this.olvColEnjoy.Renderer = new MappedImageRenderer(true, Properties.Resources.Smile, false, Properties.Resources.Sad);

			// Grade of Anime
			tc = new TypedColumn<Anime>(this.olvColGrade);
			tc.AspectPutter = (Anime a, object opr) =>
			{
				int onr = (int)opr;
				a.Grade = onr;//onr < 1 ? 1 : onr;
			};
			this.olvColGrade.Renderer = new MultiImageRenderer(Properties.Resources.Diamond, 3, 0, 4);
			this.olvColGrade.MakeGroupies(
				new int[] { 1, 2 },
				new string[] { "Normal", "Nice", "Good" }
				);

			// Note of Anime
			this.olvColNote.AspectToStringConverter = otn => otn.ToString().Replace('\u0002', '\u0020');

			this.olvAnime.UseTranslucentHotItem = true;
			this.olvAnime.UseTranslucentSelection = true;
			this.olvAnime.HotItemStyle.Overlay = new AnimeViewOverlay();
			this.olvAnime.HotItemStyle = this.olvAnime.HotItemStyle;
			this.olvAnime.PrimarySortColumn = this.olvColTitle;
			this.olvAnime.PrimarySortOrder = SortOrder.Ascending;
		}

		private void InitAnime()
		{
			// AnimeList Load before
			// Total, Total Size todo
			AnimeInfo.TotalChanged += AnimeInfo_TotalChanged;
			AnimeInfo.SpaceChanged += AnimeInfo_SpaceChanged;

			//if (AnimeInfo.AnimeList != null)
			//{
			//	this.olvAnime.SetObjects(AnimeInfo.AnimeList);

			//	// todo
			//	AnimeInfo.IsCreated = true;
			//	AnimeInfo.IsSaved = true;
			//	AnimeInfo.UpdateStatusStrip();

			//	// todo
			//	//AnimeInfo.UpdateStatusStripTotal();
			//}

			AnimeInfo.CreateStatusChanged += AnimeInfo_CreateStatusChanged;
			AnimeInfo.SaveStatusChanged += AnimeInfo_SaveStatusChanged;
		}

		private void AnimeInfo_TotalChanged(object sender, PropertyChangedEventArgs e)
		{
			AnimeInfo.UpdateStatusStripTotal();
		}

		private void AnimeInfo_SpaceChanged(object sender, PropertyChangedEventArgs e)
		{
			AnimeInfo.UpdateStatusStripSpace();
		}

		private void AnimeInfo_CreateStatusChanged(object sender, PropertyChangedEventArgs e)
		{
			if (AnimeInfo.IsCreated)
			{
				this.olvAnime.SetObjects(AnimeInfo.AnimeList);

				AnimeInfo.UpdateSelectedTab(AnimeInfo.Name, AnimeInfo.Path);
			}
			else
			{
				this.olvAnime.ClearObjects();
				// clear's bug: cann't trigger this, dispatch!
				this.olvAnime_SelectionChanged(this.olvAnime, EventArgs.Empty);

				// clear AnimeInfo todo
				AnimeInfo.Name = TidyConst.TabAnimeName;
				AnimeInfo.Path = String.Empty;
				AnimeInfo.Total = 0;
				AnimeInfo.Space = 0L;

				// clear MainForm test todo
				AnimeInfo.UpdateSelectedTab("Anime", String.Empty);
			}
		}

		private void AnimeInfo_SaveStatusChanged(object sender, PropertyChangedEventArgs e)
		{
			AnimeInfo.UpdateToolStripButton();
		}

		public void InitAnimeInfo(TidyXml xml)
		{
			AnimeInfo.Name = xml.XatName;
			AnimeInfo.Path = xml.XatPath;

			if (AnimeInfo.AnimeList != null)
			{
				//this.olvAnime.SetObjects(AnimeInfo.AnimeList);

				// todo
				AnimeInfo.IsCreated = true;
				//AnimeInfo.IsSaved = true;

				// test
				//AnimeInfo.UpdateStatusStrip();

				// todo
				//AnimeInfo.UpdateStatusStripTotal();
			}
		}

		public void CreateAnimeInfo()
		{
			AnimeInfo.CreateInfoList(this.olvAnime);
		}

		public void OpenAnimeInfo()
		{
			AnimeInfo.OpenInfoList(this.olvAnime);
		}

		public void SaveAnimeInfo()
		{
			AnimeInfo.SaveInfoList(this.olvAnime);
		}

		public void AddAnime()
		{
			AnimeInfo.AddInfo(this.olvAnime);
		}

		public void ModifyAnime()
		{
			AnimeInfo.ModifyInfo(this.olvAnime);
		}

		public void DuplicateAnime()
		{
			AnimeInfo.DuplicateInfo(this.olvAnime);
		}

		public void DeleteAnime()
		{
			AnimeInfo.DeleteInfo(this.olvAnime);
		}

		public void UndoAnime()
		{
			AnimeInfo.UndoInfo(this.olvAnime);
		}

		public void RefreshAnime()
		{
			AnimeInfo.RefreshInfo(this.olvAnime);
		}

		public void FindAnime()
		{
			AnimeInfo.FindInfo(this.olvAnime);
		}

		public void GroupAnime()
		{
			AnimeInfo.GroupInfo(this.olvAnime);
		}

		public void OverlayAnime()
		{
			AnimeInfo.OverlayInfo(this.olvAnime);
		}

		public void BackupAnime()
		{
			AnimeInfo.BackupInfo(this.olvAnime);
		}

		private void olvAnime_SelectionChanged(object sender, EventArgs e)
		{
			AnimeInfo.HandleSelectionChanged(this.olvAnime);
			
			// todo upgrade
			Anime a = this.olvAnime.SelectedObject as Anime;
			this.richtxtNote.Text = (a == null ? String.Empty : a.Remark);
		}

		private void olvAnime_IsHyperlink(object sender, IsHyperlinkEventArgs e)
		{
			e.Url = e.Text;
		}

		private void olvAnime_CellEditFinishing(object sender, CellEditEventArgs e)
		{
			if (e.Cancel)
				return;

			// bug 选择项变更又取消的
			if (e.Value.ToString() == e.NewValue.ToString())
				return;

			Anime a = e.RowObject as Anime;
			a.UpdateTime = DateTime.Now;
			this.richtxtNote.Text = a.Remark;

			AnimeInfo.IsSaved = false;
			AnimeInfo.UpdateStatusStripSelected(a.Name);
		}

		private void olvAnime_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
		{
			if (e.Column == null || e.Column != this.olvColPath)
				return;

			e.AutoPopDelay = 8000;
			e.Text = ((Anime)e.Model).Preview;
		}
	}
}
