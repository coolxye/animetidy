using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using AnimeTidy.Core;

namespace AnimeTidy
{
	public partial class ModForm : Form
	{
		public ModForm(Anime a)
		{
			InitializeComponent();

			InitModValue(a);

			InitMatch();
		}

		private void InitMatch()
		{
			//MatchTitle();
			//MatchYear();
			MatchStoreIndex();
			MatchCase();
		}

		private byte btMatch = 0xF8;

		// edit 13/1/13 for fun3
		private void MatchTitle()
		{
			//if (this.tbTitle.Text == String.Empty)
			//{
			//	this.lblMatchTitle.Text = "Title is null";
			//	return false;
			//}
			//else
			//{
			//	this.lblMatchTitle.Text = String.Empty;
			//	return true;
			//}

			if (Anime.IsMatchTitle(this.tbTitle.Text))
			{
				//this.lblMatchTitle.Text = String.Empty;
				this.lblTitle.ForeColor = SystemColors.ControlText;
				btMatch |= 0x01;
			}
			else
			{
				//this.lblMatchTitle.Text = "Title is null";
				this.lblTitle.ForeColor = Color.Red;
				btMatch &= 0xFE;
			}
		}

		private void MatchYear()
		{
			//if (Regex.IsMatch(this.cboYear.Text, "^(?!0000)[0-9]{4}$"))
			//{
			//	this.lblMatchYear.Text = String.Empty;
			//	return true;
			//}
			//else
			//{
			//	this.lblMatchYear.Text = "Year is wrong";
			//	return false;
			//}
			if (Anime.IsMatchYear(this.cboYear.Text))
			{
				//this.lblMatchYear.Text = String.Empty;
				this.lblSchedule.ForeColor = SystemColors.ControlText;
				btMatch |= 0x02;
			}
			else
			{
				//this.lblMatchYear.Text = "Year is wrong";
				this.lblSchedule.ForeColor = Color.Red;
				btMatch &= 0xFD;
			}
		}

		private void MatchStoreIndex()
		{
			//if (this.tbStoreIndex.Text == String.Empty ||
			//	Regex.IsMatch(this.tbStoreIndex.Text,
			//	@"^[a-zA-Z]:(\\(?![\s\.])[^\\/:\*\?\x22<>\|]*[^\s\.\\/:\*\?\x22<>\|])+$"))
			//{
			//	this.lblMatchStoreIndex.Text = String.Empty;
			//	return true;
			//}
			//else
			//{
			//	this.lblMatchStoreIndex.Text = "Path isn't match";
			//	return false;
			//}
			if (Anime.IsMatchPath(this.tbStoreIndex.Text))
			{
				//this.lblMatchStoreIndex.Text = String.Empty;
				this.lblPath.ForeColor = SystemColors.ControlText;
				btMatch |= 0x04;
			}
			else
			{
				//this.lblMatchStoreIndex.Text = "Path isn't match";
				this.lblPath.ForeColor = Color.Red;
				btMatch &= 0xFB;
			}
		}
		// edit fin

		private void MatchCase()
		{
			if ((btMatch & 0xFF) == 0xFF)
				this.btnOK.Enabled = true;
			else
				this.btnOK.Enabled = false;
		}

		private Anime _anime;
		private long lsize;

		private void InitModValue(Anime a)
		{
			this.tbTitle.Text = a.Title;
			this.tbKana.Text = a.Kana;
			this.tbEpisode.Text = a.Episode;
			this.tbInc.Text = a.Inc;

			this.cboYear.Text = a.Year.ToString("0000");

			this.cboSeason.DataSource = Enum.GetValues(typeof(PlaySeason));
			this.cboSeason.SelectedItem = a.Season;

			this.cboFormat.DataSource = Enum.GetValues(typeof(MergeFormat));
			this.cboFormat.SelectedItem = a.Format;

			this.cboSubStyle.DataSource = Enum.GetValues(typeof(SubStyles));
			this.cboSubStyle.SelectedItem = a.SubStyle;

			this.tbStoreIndex.Text = a.Path;
			this.rtbNote.Text = a.Note.Replace('\u0002', '\n');

			_anime = a;
			lsize = a.Size;
		}

		public Anime GetAnime()
		{
			return _anime;
		}

		public long GetDiffSize()
		{
			return lsize;
		}

		private void btnBrowser_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();

			if (fbd.ShowDialog(this) == DialogResult.OK)
				this.tbStoreIndex.Text = fbd.SelectedPath;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			// edit 13/1/13 for fun3
			//if (this.tbTitle.Text == "")
			//{
			//    MessageBox.Show("The title is a null value!", "Title error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//    this.tbTitle.Focus();

			//    return;
			//}

			//Regex rx = new Regex(@"^(?!0000)[0-9]{4}$");

			//if (!rx.IsMatch(this.cboYear.Text))
			//{
			//    MessageBox.Show("The Year is wrong!", "Year error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//    this.cboYear.ResetText();
			//    this.cboYear.Focus();

			//    return;
			//}

			//if (this.tbStoreIndex.Text != "")
			//{
			//    rx = new Regex(@"^[a-zA-Z]:(\\[^\s\.\\/:\*\?\x22<>\|][^\\/:\*\?\x22<>\|]*[^\s\.\\/:\*\?\x22<>\|])+$");

			//    if (!rx.IsMatch(this.tbStoreIndex.Text))
			//    {
			//        MessageBox.Show("The Path do not match!", "Path error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//        this.tbStoreIndex.ResetText();
			//        this.tbStoreIndex.Focus();

			//        return;
			//    }

			//    if (Directory.Exists(this.tbStoreIndex.Text))
			//        _anime.Size = AnimeSpace.GetSpace(this.tbStoreIndex.Text);
			//}
			//else _anime.Size = 0L;

			//bool btitle, byear, bstoreindex;

			//btitle = MatchTitle();
			//byear = MatchYear();
			//bstoreindex = MatchStoreIndex();

			//if (!btitle)
			//{
			//	this.tbTitle.Focus();
			//	return;
			//}
			//else if (!byear)
			//{
			//	this.cboYear.Text = String.Empty;
			//	this.cboYear.Focus();
			//	return;
			//}
			//else if (!bstoreindex)
			//{
			//	this.tbStoreIndex.Text = String.Empty;
			//	this.tbStoreIndex.Focus();
			//	return;
			//}
			// edit fin

			if (this.tbStoreIndex.Text.Length == 0)
				_anime.Size = 0L;
			else if (AnimeInfo.IsStorageReady())
				_anime.Size = Anime.GetSize(this.tbStoreIndex.Text);

			_anime.Title = this.tbTitle.Text;
			_anime.Year = UInt32.Parse(this.cboYear.Text);
			_anime.Season = (PlaySeason)this.cboSeason.SelectedItem;
			_anime.Path = this.tbStoreIndex.Text;

			_anime.Format = (MergeFormat)this.cboFormat.SelectedItem;
			_anime.SubStyle = (SubStyles)this.cboSubStyle.SelectedItem;

			_anime.UpdateTime = DateTime.Now;
			_anime.Kana = this.tbKana.Text;
			_anime.Episode = this.tbEpisode.Text;
			_anime.Inc = this.tbInc.Text;
			_anime.Note = this.rtbNote.Text.Replace('\n', '\u0002');

			lsize = _anime.Size - lsize;

			this.Close();
		}

		private void rtbNote_Enter(object sender, EventArgs e)
		{
			this.AcceptButton = null;
		}

		private void rtbNote_Leave(object sender, EventArgs e)
		{
			this.AcceptButton = this.btnOK;
		}

		// edit 13/1/13 for fun3
		private void tbTitle_TextChanged(object sender, EventArgs e)
		{
			MatchTitle();
			MatchCase();
		}

		private void cboYear_TextChanged(object sender, EventArgs e)
		{
			MatchYear();
			MatchCase();
		}

		private void tbStoreIndex_TextChanged(object sender, EventArgs e)
		{
			MatchStoreIndex();
			MatchCase();
		}
		// edit fin

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
