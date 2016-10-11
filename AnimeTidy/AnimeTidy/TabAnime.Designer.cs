namespace AnimeTidy
{
	partial class TabAnime
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.olvAnime = new AnimeTidyLib.ObjectListView();
			this.olvColTitle = ((AnimeTidyLib.OLVColumn)(new AnimeTidyLib.OLVColumn()));
			this.olvColName = ((AnimeTidyLib.OLVColumn)(new AnimeTidyLib.OLVColumn()));
			this.olvColAirdate = ((AnimeTidyLib.OLVColumn)(new AnimeTidyLib.OLVColumn()));
			this.olvColType = ((AnimeTidyLib.OLVColumn)(new AnimeTidyLib.OLVColumn()));
			this.olvColSubTeam = ((AnimeTidyLib.OLVColumn)(new AnimeTidyLib.OLVColumn()));
			this.olvColPath = ((AnimeTidyLib.OLVColumn)(new AnimeTidyLib.OLVColumn()));
			this.olvColSize = ((AnimeTidyLib.OLVColumn)(new AnimeTidyLib.OLVColumn()));
			this.olvColStore = ((AnimeTidyLib.OLVColumn)(new AnimeTidyLib.OLVColumn()));
			this.olvColEnjoy = ((AnimeTidyLib.OLVColumn)(new AnimeTidyLib.OLVColumn()));
			this.olvColGrade = ((AnimeTidyLib.OLVColumn)(new AnimeTidyLib.OLVColumn()));
			this.olvColNote = ((AnimeTidyLib.OLVColumn)(new AnimeTidyLib.OLVColumn()));
			this.lblDes = new System.Windows.Forms.Label();
			this.splitCtnAnime = new System.Windows.Forms.SplitContainer();
			this.richtxtNote = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.olvAnime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitCtnAnime)).BeginInit();
			this.splitCtnAnime.Panel1.SuspendLayout();
			this.splitCtnAnime.Panel2.SuspendLayout();
			this.splitCtnAnime.SuspendLayout();
			this.SuspendLayout();
			// 
			// olvAnime
			// 
			this.olvAnime.AllColumns.Add(this.olvColTitle);
			this.olvAnime.AllColumns.Add(this.olvColName);
			this.olvAnime.AllColumns.Add(this.olvColAirdate);
			this.olvAnime.AllColumns.Add(this.olvColType);
			this.olvAnime.AllColumns.Add(this.olvColSubTeam);
			this.olvAnime.AllColumns.Add(this.olvColPath);
			this.olvAnime.AllColumns.Add(this.olvColSize);
			this.olvAnime.AllColumns.Add(this.olvColStore);
			this.olvAnime.AllColumns.Add(this.olvColEnjoy);
			this.olvAnime.AllColumns.Add(this.olvColGrade);
			this.olvAnime.AllColumns.Add(this.olvColNote);
			this.olvAnime.AllowColumnReorder = true;
			this.olvAnime.CellEditUseWholeCell = false;
			this.olvAnime.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColTitle,
            this.olvColName,
            this.olvColAirdate,
            this.olvColType,
            this.olvColSubTeam,
            this.olvColPath,
            this.olvColSize,
            this.olvColStore,
            this.olvColEnjoy,
            this.olvColGrade,
            this.olvColNote});
			this.olvAnime.Cursor = System.Windows.Forms.Cursors.Default;
			this.olvAnime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.olvAnime.EmptyListMsg = "アニメがない...";
			this.olvAnime.FullRowSelect = true;
			this.olvAnime.Location = new System.Drawing.Point(0, 0);
			this.olvAnime.Name = "olvAnime";
			this.olvAnime.Size = new System.Drawing.Size(150, 106);
			this.olvAnime.TabIndex = 1;
			this.olvAnime.UseCompatibleStateImageBehavior = false;
			this.olvAnime.View = System.Windows.Forms.View.Details;
			// 
			// olvColTitle
			// 
			this.olvColTitle.AspectName = "Title";
			this.olvColTitle.MinimumWidth = 130;
			this.olvColTitle.Text = "Title";
			this.olvColTitle.UseInitialLetterForGroup = true;
			this.olvColTitle.Width = 130;
			// 
			// olvColName
			// 
			this.olvColName.AspectName = "Name";
			this.olvColName.MinimumWidth = 120;
			this.olvColName.Text = "Name";
			this.olvColName.UseInitialLetterForGroup = true;
			this.olvColName.Width = 120;
			// 
			// olvColAirdate
			// 
			this.olvColAirdate.AspectName = "Airdate";
			this.olvColAirdate.IsEditable = false;
			this.olvColAirdate.MinimumWidth = 80;
			this.olvColAirdate.Text = "Airdate";
			this.olvColAirdate.Width = 80;
			// 
			// olvColType
			// 
			this.olvColType.AspectName = "Type";
			this.olvColType.MinimumWidth = 72;
			this.olvColType.Text = "Type";
			this.olvColType.Width = 72;
			// 
			// olvColSubTeam
			// 
			this.olvColSubTeam.AspectName = "SubTeam";
			this.olvColSubTeam.MinimumWidth = 100;
			this.olvColSubTeam.Text = "Subtitle";
			this.olvColSubTeam.Width = 100;
			// 
			// olvColPath
			// 
			this.olvColPath.AspectName = "Path";
			this.olvColPath.Hyperlink = true;
			this.olvColPath.IsEditable = false;
			this.olvColPath.MinimumWidth = 100;
			this.olvColPath.Text = "Path";
			this.olvColPath.Width = 120;
			// 
			// olvColSize
			// 
			this.olvColSize.AspectName = "Size";
			this.olvColSize.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.olvColSize.IsEditable = false;
			this.olvColSize.MinimumWidth = 60;
			this.olvColSize.Text = "Size";
			this.olvColSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// olvColStore
			// 
			this.olvColStore.AspectName = "Store";
			this.olvColStore.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.olvColStore.MinimumWidth = 45;
			this.olvColStore.Text = "Store";
			this.olvColStore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.olvColStore.Width = 45;
			// 
			// olvColEnjoy
			// 
			this.olvColEnjoy.AspectName = "Enjoy";
			this.olvColEnjoy.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.olvColEnjoy.MinimumWidth = 45;
			this.olvColEnjoy.Text = "Enjoy";
			this.olvColEnjoy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.olvColEnjoy.Width = 45;
			// 
			// olvColGrade
			// 
			this.olvColGrade.AspectName = "Grade";
			this.olvColGrade.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.olvColGrade.MinimumWidth = 60;
			this.olvColGrade.Text = "Grade";
			this.olvColGrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// olvColNote
			// 
			this.olvColNote.AspectName = "Note";
			this.olvColNote.IsEditable = false;
			this.olvColNote.MinimumWidth = 200;
			this.olvColNote.Text = "Note";
			this.olvColNote.Width = 200;
			// 
			// lblDes
			// 
			this.lblDes.AutoSize = true;
			this.lblDes.Location = new System.Drawing.Point(3, 0);
			this.lblDes.Name = "lblDes";
			this.lblDes.Size = new System.Drawing.Size(107, 12);
			this.lblDes.TabIndex = 0;
			this.lblDes.Text = "Anime description";
			// 
			// splitCtnAnime
			// 
			this.splitCtnAnime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitCtnAnime.Location = new System.Drawing.Point(0, 15);
			this.splitCtnAnime.Name = "splitCtnAnime";
			this.splitCtnAnime.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitCtnAnime.Panel1
			// 
			this.splitCtnAnime.Panel1.Controls.Add(this.olvAnime);
			// 
			// splitCtnAnime.Panel2
			// 
			this.splitCtnAnime.Panel2.Controls.Add(this.richtxtNote);
			this.splitCtnAnime.Size = new System.Drawing.Size(150, 135);
			this.splitCtnAnime.SplitterDistance = 106;
			this.splitCtnAnime.TabIndex = 2;
			// 
			// richtxtNote
			// 
			this.richtxtNote.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richtxtNote.Location = new System.Drawing.Point(0, 0);
			this.richtxtNote.Name = "richtxtNote";
			this.richtxtNote.ReadOnly = true;
			this.richtxtNote.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.richtxtNote.Size = new System.Drawing.Size(150, 25);
			this.richtxtNote.TabIndex = 0;
			this.richtxtNote.Text = "";
			// 
			// TabAnime
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitCtnAnime);
			this.Controls.Add(this.lblDes);
			this.Name = "TabAnime";
			((System.ComponentModel.ISupportInitialize)(this.olvAnime)).EndInit();
			this.splitCtnAnime.Panel1.ResumeLayout(false);
			this.splitCtnAnime.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitCtnAnime)).EndInit();
			this.splitCtnAnime.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private AnimeTidyLib.ObjectListView olvAnime;
		private AnimeTidyLib.OLVColumn olvColTitle;
		private AnimeTidyLib.OLVColumn olvColName;
		private AnimeTidyLib.OLVColumn olvColAirdate;
		private AnimeTidyLib.OLVColumn olvColType;
		private AnimeTidyLib.OLVColumn olvColSubTeam;
		private AnimeTidyLib.OLVColumn olvColPath;
		private AnimeTidyLib.OLVColumn olvColSize;
		private AnimeTidyLib.OLVColumn olvColStore;
		private AnimeTidyLib.OLVColumn olvColEnjoy;
		private AnimeTidyLib.OLVColumn olvColGrade;
		private AnimeTidyLib.OLVColumn olvColNote;
		private System.Windows.Forms.Label lblDes;
		private System.Windows.Forms.SplitContainer splitCtnAnime;
		private System.Windows.Forms.RichTextBox richtxtNote;
	}
}
