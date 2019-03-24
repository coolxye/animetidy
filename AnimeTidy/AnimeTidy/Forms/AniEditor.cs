using AnimeTidy.Models;
using AnimeTidyLib;
using Ookii.Dialogs;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AnimeTidy.Forms
{
	public class AniEditor : EditForm
	{
		public AniEditor(ObjectListView olv, Anime a) : base(olv)
		{
			this._ani = a;
			this.InitData();
		}

		protected Anime _ani;
		public virtual Anime Ani
		{
			get { return this._ani; }
		}

		protected override void InitForm()
		{
			this.lblTitle = new Label();
			this.lblTitle.AutoSize = true;
			this.lblTitle.Text = "Title";
			this.lblTitle.Anchor = AnchorStyles.Left;

			this.tbTitle = new TextBox();
			this.tbTitle.Anchor = AnchorStyles.Left;
			this.tbTitle.Width = 200;

			this.lblAirDate = new Label();
			this.lblAirDate.AutoSize = true;
			this.lblAirDate.Text = "AirDate";
			this.lblAirDate.Anchor = AnchorStyles.Left;

			this.dtpAirDate = new DateTimePicker();
			this.dtpAirDate.Format = DateTimePickerFormat.Custom;
			this.dtpAirDate.CustomFormat = "yyyy/MM";
			this.dtpAirDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			this.dtpAirDate.ShowUpDown = true;
			this.dtpAirDate.Width = 120;
			this.dtpAirDate.Anchor = AnchorStyles.Left;

			this.lblFormat = new Label();
			this.lblFormat.AutoSize = true;
			this.lblFormat.Text = "Format";
			this.lblFormat.Anchor = AnchorStyles.Left;

			this.cboFormat = new ComboBox();
			this.cboFormat.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cboFormat.Anchor = AnchorStyles.Left;

			this.lblSubStyle = new Label();
			this.lblSubStyle.AutoSize = true;
			this.lblSubStyle.Text = "SubStyle";
			this.lblSubStyle.Anchor = AnchorStyles.Left;

			this.cboSubStyle = new ComboBox();
			this.cboSubStyle.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cboSubStyle.Anchor = AnchorStyles.Left;

			this.lblPath = new Label();
			this.lblPath.AutoSize = true;
			this.lblPath.Text = "Path";
			this.lblPath.Anchor = AnchorStyles.Left;

			this.tbPath = new TextBox();
			this.tbPath.Anchor = AnchorStyles.Left;
			this.tbPath.Width = 200;

			this.btnPath = new Button();
			this.btnPath.Anchor = AnchorStyles.Left;
			this.btnPath.Width = 30;
			this.btnPath.Click += btnPath_Click;

			this.pnlPath = new FlowLayoutPanel();
			this.pnlPath.AutoSize = true;
			this.pnlPath.Anchor = AnchorStyles.Left;
			this.pnlPath.Margin = new Padding(0);
			this.pnlPath.Controls.AddRange(new Control[] { this.tbPath, this.btnPath });

			this.lblKana = new Label();
			this.lblKana.AutoSize = true;
			this.lblKana.Text = "Kana";
			this.lblKana.Anchor = AnchorStyles.Left;

			this.tbKana = new TextBox();
			this.tbKana.Anchor = AnchorStyles.Left;
			this.tbKana.Width = 200;

			this.lblEpisode = new Label();
			this.lblEpisode.AutoSize = true;
			this.lblEpisode.Text = "Episode";
			this.lblEpisode.Anchor = AnchorStyles.Left;

			this.tbEpisode = new TextBox();
			this.tbEpisode.Anchor = AnchorStyles.Left;
			this.tbEpisode.Width = 200;

			this.lblInc = new Label();
			this.lblInc.AutoSize = true;
			this.lblInc.Text = "Inc";
			this.lblInc.Anchor = AnchorStyles.Left;

			this.tbInc = new TextBox();
			this.tbInc.Anchor = AnchorStyles.Left;
			this.tbInc.Width = 200;

			this.lblNote = new Label();
			this.lblNote.AutoSize = true;
			this.lblNote.Text = "Note";
			this.lblNote.Anchor = AnchorStyles.Left;

			this.rtbNote = new RichTextBox();
			this.rtbNote.Anchor = AnchorStyles.Left;
			this.rtbNote.Width = 200;
			this.rtbNote.Font = new Font("Segoe UI", 9);

			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Size = new System.Drawing.Size(400, 300);
		}

		protected virtual void InitData()
		{
			this.cboFormat.DataSource = Enum.GetValues(typeof(MergeFormat));
			this.cboSubStyle.DataSource = Enum.GetValues(typeof(SubStyle));
		}

		protected Label lblTitle;
		protected TextBox tbTitle;
		protected Label lblAirDate;
		protected DateTimePicker dtpAirDate;
		protected Label lblFormat;
		protected ComboBox cboFormat;
		protected Label lblSubStyle;
		protected ComboBox cboSubStyle;
		protected Label lblPath;
		protected TextBox tbPath;
		protected Button btnPath;
		protected FlowLayoutPanel pnlPath;
		protected Label lblKana;
		protected TextBox tbKana;
		protected Label lblEpisode;
		protected TextBox tbEpisode;
		protected Label lblInc;
		protected TextBox tbInc;
		protected Label lblNote;
		protected RichTextBox rtbNote;

		protected override void Confirm()
		{
			// check title, path
			if (this.tbTitle.Text == String.Empty)
			{
				this.tbTitle.Focus();
				return;
			}

			if (this.tbPath.Text != String.Empty && !Regex.IsMatch(this.tbPath.Text, @"^[a-zA-Z]:(\\(?![\s\.])[^\\/:\*\?\x22<>\|]*[^\s\.\\/:\*\?\x22<>\|])+$"))
			{
				this.tbPath.Focus();
				return;
			}

			this.Manipulate();
			this.Close();
		}

		protected virtual void Manipulate() { }

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == Keys.Enter)
				if (this.rtbNote.Focused)
				{
					int cur = this.rtbNote.SelectionStart;
					this.rtbNote.Text = this.rtbNote.Text.Insert(cur, "\n");
					this.rtbNote.SelectionStart = cur + 1;
					return true;
				}

			return base.ProcessDialogKey(keyData);
		}

		private void btnPath_Click(object sender, EventArgs e)
		{
			// todo upgrade
			if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
				return;

			VistaFolderBrowserDialog ofd = new VistaFolderBrowserDialog();
			if (ofd.ShowDialog(this) == DialogResult.OK)
				this.tbPath.Text = ofd.SelectedPath;
		}
	}
}
