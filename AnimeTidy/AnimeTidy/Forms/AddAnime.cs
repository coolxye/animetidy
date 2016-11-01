using AnimeTidy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimeTidy.Forms
{
	public class AddAnime : EditAnime
	{
		public AddAnime(Anime a, Int64 id) : base(a)
		{
			this._id = id;
		}

		private Int64 _id;
		protected override Anime Ani
		{
			get
			{
				return base.Ani ?? new Anime(_id);
			}
		}

		protected override void InitForm()
		{
			base.InitForm();

			this.lblName = new Label();
			this.lblName.AutoSize = true;
			this.lblName.Text = "Name";
			this.lblName.Anchor = AnchorStyles.Left;

			this.tbName = new TextBox();
			this.tbName.Anchor = AnchorStyles.Left;

			this.lblType = new Label();
			this.lblType.AutoSize = true;
			this.lblType.Text = "Type";
			this.lblType.Anchor = AnchorStyles.Left;

			this.cboType = new ComboBox();
			this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cboType.DataSource = Enum.GetValues(typeof(MediaType));
			this.cboType.Anchor = AnchorStyles.Left;

			this.lblSubTeam = new Label();
			this.lblSubTeam.AutoSize = true;
			this.lblSubTeam.Text = "SubTeam";
			this.lblSubTeam.Anchor = AnchorStyles.Left;

			this.cboSubTeam = new ComboBox();
			this.cboSubTeam.Items.AddRange(new object[] {
				"SumiSora",
				"CASO",
				"HKG",
				"POPGO",
				"SOSG",
				"KTXP"
			});
			this.cboSubTeam.SelectedIndex = 0;
			this.cboSubTeam.Anchor = AnchorStyles.Left;

			this.lblStore = new Label();
			this.lblStore.AutoSize = true;
			this.lblStore.Text = "Store";
			this.lblStore.Anchor = AnchorStyles.Left;

			this.cboStore = new ComboBox();
			this.cboStore.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cboStore.Items.AddRange(new object[] {
				"Con.",
				"Fin."
			});
			this.cboStore.SelectedIndex = 0;
			this.cboStore.Anchor = AnchorStyles.Left;

			this.lblEnjoy = new Label();
			this.lblEnjoy.AutoSize = true;
			this.lblEnjoy.Text = "Enjoy";
			this.lblEnjoy.Anchor = AnchorStyles.Left;

			this.cboEnjoy = new ComboBox();
			this.cboEnjoy.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cboEnjoy.Items.AddRange(new object[] {
				"-~-",
				"^-^"
			});
			this.cboEnjoy.SelectedIndex = 0;
			this.cboEnjoy.Anchor = AnchorStyles.Left;

			this.lblGrade = new Label();
			this.lblGrade.AutoSize = true;
			this.lblGrade.Text = "Grade";
			this.lblGrade.Anchor = AnchorStyles.Left;

			this.cboGrade = new ComboBox();
			this.cboGrade.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cboGrade.Items.AddRange(new object[] {
				"1",
				"2",
				"3"
			});
			this.cboGrade.SelectedIndex = 0;
			this.cboGrade.Anchor = AnchorStyles.Left;
		}

		protected override void InitTable()
		{
			this.tableLayoutPanelEdit.ColumnCount = 2;
			this.tableLayoutPanelEdit.RowCount = 15;
			this.tableLayoutPanelEdit.Controls.AddRange(new Control[] {
				this.lblTitle, this.tbTitle,
				this.lblName, this.tbName,
				this.lblAirDate, this.dtpAirDate,
				this.lblType, this.cboType,
				this.lblFormat, this.cboFormat,
				this.lblSubTeam, this.cboSubTeam,
				this.lblSubStyle, this.cboSubStyle,
				this.lblStore, this.cboStore,
				this.lblEnjoy, this.cboEnjoy,
				this.lblGrade, this.cboGrade,
				this.lblPath, this.pnlPath,
				this.lblKana, this.tbKana,
				this.lblEpisode, this.tbEpisode,
				this.lblInc, this.tbInc
			});
		}

		protected Label lblName;
		protected TextBox tbName;
		protected Label lblType;
		protected ComboBox cboType;
		protected Label lblSubTeam;
		protected ComboBox cboSubTeam;
		protected Label lblStore;
		protected ComboBox cboStore;
		protected Label lblEnjoy;
		protected ComboBox cboEnjoy;
		protected Label lblGrade;
		protected ComboBox cboGrade;
	}
}
