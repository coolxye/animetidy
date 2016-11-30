using AnimeTidy.Cores;
using AnimeTidy.Models;
using AnimeTidyLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnimeTidy
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			InitSelfData();
			// Anime, Music, Other..
			InitTabs();
		}

		public TidyXml TXml
		{ get; set; }

		private void InitSelfData()
		{
			this.Size = new Size(960, 540);
			this.TXml = new TidyXml();
		}

		private void InitTabs()
		{
			if (ObjectListView.IsVistaOrLater)
				this.Font = new Font("Segoe UI", 8);	// Microsoft YaHei

			this.tabPageAnime.Tag = this.tabAnimes;

			// temp
			this.tabControlMain.Controls.Remove(this.tabPageMusic);

			// Anime, Music, Other Info todo
			AnimeInfo info = new AnimeInfo(this);
			this.tabAnimes.AnimeInfo = info;

			foreach (XatXml xx in TXml.XatLst)
			{
				switch (xx.XatType)
				{
					case TidyType.Anime:
						this.tabAnimes.InitAnimeInfo(xx);
						break;

					case TidyType.Music:
						break;

					case TidyType.Other:
						break;

					default:
						break;
				}
			}
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			switch (keyData)
			{
				case (Keys.S | Keys.Control):
					this.tsbtnSave_Click(this.tsbtnSave, EventArgs.Empty);
					return true;

				case (Keys.I | Keys.Control):
					this.tsbtnAdd_Click(this.tsbtnAdd, EventArgs.Empty);
					return true;

				case (Keys.E | Keys.Control):
					this.tsbtnModify_Click(this.tsbtnModify, EventArgs.Empty);
					return true;

				case (Keys.D | Keys.Control):
					this.tsbtnDuplicate_Click(this.tsbtnDuplicate, EventArgs.Empty);
					return true;

				case (Keys.F | Keys.Control):
					this.tsbtnFind_Click(this.tsbtnFind, EventArgs.Empty);
					return true;

				default:
					return base.ProcessDialogKey(keyData);
			}
		}

		private void tabControlMain_Deselected(object sender, TabControlEventArgs e)
		{
			switch (this.tabControlMain.SelectedIndex)
			{
				case 0:
					//this.tsbtnNew.Visible = false;
					break;

				case 1:
					break;

				default:
					break;
			}
		}

		private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (this.tabControlMain.SelectedIndex)
			{
				case 0:
					//this.tsbtnNew.Visible = true;
					break;

				case 1:
					break;

				default:
					break;
			}
		}

		private void tsbtnNew_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleNew();
		}

		private void tsbtnOpen_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleOpen();
		}

		private void tsbtnSave_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleSave();
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleAdd();
		}

		private void tsbtnModify_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleModify();
		}

		private void tsbtnDuplicate_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleDuplicate();
		}

		private void tsbtnDelete_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleDelete();
		}

		private void tsbtnUndo_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleUndo();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleRefresh();
		}

		private void tsbtnFind_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleFind();
		}

		private void tsbtnGroup_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleGroup();
		}

		private void tsbtnOverlay_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleOverlay();
		}

		private void tabtnBackup_Click(object sender, EventArgs e)
		{
			((ComTab)this.tabControlMain.SelectedTab.Tag).HandleBackup();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			foreach (TabPage tab in this.tabControlMain.TabPages)
			{
				if (tab.Tag != null && !((ComTab)tab.Tag).PerformClosing())
				{
					e.Cancel = true;
					break;
				}
			}
		}

		public void UpdateTabAnime(string note)
		{
			this.tabAnimes.UpdateRichTxtNote(note);
		}
	}
}
