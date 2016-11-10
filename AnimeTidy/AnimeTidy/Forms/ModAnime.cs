﻿using AnimeTidy.Models;
using AnimeTidyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimeTidy.Forms
{
	public class ModAnime : AniEditor
	{
		public ModAnime(ObjectListView olv, Anime a) : base(olv, a) { }

		protected override void InitTable()
		{
			this.tableLayoutPanelEdit.ColumnCount = 2;
			this.tableLayoutPanelEdit.RowCount = 10;
			this.tableLayoutPanelEdit.Controls.AddRange(new Control[] {
				this.lblTitle, this.tbTitle,
				this.lblAirDate, this.dtpAirDate,
				this.lblFormat, this.cboFormat,
				this.lblSubStyle, this.cboSubStyle,
				this.lblPath, this.pnlPath,
				this.lblKana, this.tbKana,
				this.lblEpisode, this.tbEpisode,
				this.lblInc, this.tbInc,
				this.lblNote, this.rtbNote
			});
		}

		protected override void InitData()
		{
			base.InitData();

			this.tbTitle.Text = Ani.Title;
			this.dtpAirDate.Value = new DateTime(Ani.Year, Ani.Month, 1);
			this.cboFormat.SelectedItem = Ani.Format;
			this.cboSubStyle.SelectedItem = Ani.SubStyle;
			this.tbPath.Text = Ani.Path;
			this.tbKana.Text = Ani.Kana;
			this.tbEpisode.Text = Ani.Episode;
			this.tbInc.Text = Ani.Inc;
		}

		public Boolean IsModified
		{ get; set; }

		protected override void Manipulate()
		{
			if (Ani.Title != this.tbTitle.Text ||
				Ani.Year != this.dtpAirDate.Value.Year ||
				Ani.Month != this.dtpAirDate.Value.Month ||
				Ani.Format != (MergeFormat)this.cboFormat.SelectedItem ||
				Ani.SubStyle != (SubStyle)this.cboSubStyle.SelectedItem ||
				Ani.Path != this.tbPath.Text ||
				Ani.Kana != this.tbKana.Text ||
				Ani.Episode != this.tbEpisode.Text ||
				Ani.Inc != this.tbInc.Text ||
				Ani.Note != this.rtbNote.Text.Replace(Environment.NewLine, "\u0002"))
			{
				Ani.Title = this.tbTitle.Text;
				Ani.Year = this.dtpAirDate.Value.Year;
				Ani.Month = this.dtpAirDate.Value.Month;
				Ani.Format = (MergeFormat)this.cboFormat.SelectedItem;
				Ani.SubStyle = (SubStyle)this.cboSubStyle.SelectedItem;
				Ani.Path = this.tbPath.Text;
				Ani.UpdateTime = DateTime.Now;
				Ani.Kana = this.tbKana.Text;
				Ani.Episode = this.tbEpisode.Text;
				Ani.Inc = this.tbInc.Text;
				Ani.Note = this.rtbNote.Text.Replace(Environment.NewLine, "\u0002");

				IsModified = true;
			}
			else
			{
				IsModified = false;
			}
		}
	}
}