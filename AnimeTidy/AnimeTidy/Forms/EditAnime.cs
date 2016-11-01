using AnimeTidy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimeTidy.Forms
{
	public class EditAnime : EditForm
	{
		public EditAnime(Anime a)
		{
			this._ani = a;
		}

		private Anime _ani;
		protected virtual Anime Ani
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
			this.cboFormat.DataSource = Enum.GetValues(typeof(MergeFormat));
			this.cboFormat.Anchor = AnchorStyles.Left;

			this.lblSubStyle = new Label();
			this.lblSubStyle.AutoSize = true;
			this.lblSubStyle.Text = "SubStyle";
			this.lblSubStyle.Anchor = AnchorStyles.Left;

			this.cboSubStyle = new ComboBox();
			this.cboSubStyle.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cboSubStyle.DataSource = Enum.GetValues(typeof(SubStyle));
			this.cboSubStyle.Anchor = AnchorStyles.Left;

			this.lblPath = new Label();
			this.lblPath.AutoSize = true;
			this.lblPath.Text = "Path";
			this.lblPath.Anchor = AnchorStyles.Left;

			this.tbPath = new TextBox();
			this.tbPath.Anchor = AnchorStyles.Left;

			this.btnPath = new Button();
			this.btnPath.Anchor = AnchorStyles.Left;

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

			this.lblEpisode = new Label();
			this.lblEpisode.AutoSize = true;
			this.lblEpisode.Text = "Episode";
			this.lblEpisode.Anchor = AnchorStyles.Left;

			this.tbEpisode = new TextBox();
			this.tbEpisode.Anchor = AnchorStyles.Left;

			this.lblInc = new Label();
			this.lblInc.AutoSize = true;
			this.lblInc.Text = "Inc";
			this.lblInc.Anchor = AnchorStyles.Left;

			this.tbInc = new TextBox();
			this.tbInc.Anchor = AnchorStyles.Left;
		}

		protected override void InitTable()
		{
			this.tableLayoutPanelEdit.ColumnCount = 2;
			this.tableLayoutPanelEdit.RowCount = 9;
			this.tableLayoutPanelEdit.Controls.AddRange(new Control[] {
				this.lblTitle, this.tbTitle,
				this.lblAirDate, this.dtpAirDate,
				this.lblFormat, this.cboFormat,
				this.lblSubStyle, this.cboSubStyle,
				this.lblPath, this.pnlPath,
				this.lblKana, this.tbKana,
				this.lblEpisode, this.tbEpisode,
				this.lblInc, this.tbInc
			});
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
	}
}
