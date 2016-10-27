namespace AnimeTidy
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.toolStripMain = new System.Windows.Forms.ToolStrip();
			this.statusStripMain = new System.Windows.Forms.StatusStrip();
			this.tabControlMain = new System.Windows.Forms.TabControl();
			this.tabPageAnime = new System.Windows.Forms.TabPage();
			this.tabPageMusic = new System.Windows.Forms.TabPage();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnNew = new System.Windows.Forms.ToolStripButton();
			this.tsbtnOpen = new System.Windows.Forms.ToolStripButton();
			this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.tsbtnModify = new System.Windows.Forms.ToolStripButton();
			this.tsbtnDuplicate = new System.Windows.Forms.ToolStripButton();
			this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
			this.tsbtnUndo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsslSelName = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslSelSpace = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslTotal = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslTotSpace = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabAnimes = new AnimeTidy.TabAnime();
			this.toolStripMain.SuspendLayout();
			this.statusStripMain.SuspendLayout();
			this.tabControlMain.SuspendLayout();
			this.tabPageAnime.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripMain
			// 
			this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNew,
            this.tsbtnOpen,
            this.tsbtnSave,
            this.toolStripSeparator1,
            this.tsbtnAdd,
            this.tsbtnModify,
            this.tsbtnDuplicate,
            this.tsbtnDelete,
            this.tsbtnUndo,
            this.toolStripSeparator2});
			this.toolStripMain.Location = new System.Drawing.Point(0, 0);
			this.toolStripMain.Name = "toolStripMain";
			this.toolStripMain.Size = new System.Drawing.Size(284, 25);
			this.toolStripMain.TabIndex = 0;
			this.toolStripMain.Text = "toolStrip1";
			// 
			// statusStripMain
			// 
			this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslSelName,
            this.tsslSelSpace,
            this.tsslTotal,
            this.tsslTotSpace});
			this.statusStripMain.Location = new System.Drawing.Point(0, 236);
			this.statusStripMain.Name = "statusStripMain";
			this.statusStripMain.Size = new System.Drawing.Size(284, 26);
			this.statusStripMain.TabIndex = 1;
			this.statusStripMain.Text = "statusStrip1";
			// 
			// tabControlMain
			// 
			this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlMain.Controls.Add(this.tabPageAnime);
			this.tabControlMain.Controls.Add(this.tabPageMusic);
			this.tabControlMain.Location = new System.Drawing.Point(12, 28);
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.SelectedIndex = 0;
			this.tabControlMain.ShowToolTips = true;
			this.tabControlMain.Size = new System.Drawing.Size(260, 205);
			this.tabControlMain.TabIndex = 2;
			this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
			this.tabControlMain.Deselected += new System.Windows.Forms.TabControlEventHandler(this.tabControlMain_Deselected);
			// 
			// tabPageAnime
			// 
			this.tabPageAnime.Controls.Add(this.tabAnimes);
			this.tabPageAnime.Location = new System.Drawing.Point(4, 22);
			this.tabPageAnime.Name = "tabPageAnime";
			this.tabPageAnime.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAnime.Size = new System.Drawing.Size(252, 179);
			this.tabPageAnime.TabIndex = 0;
			this.tabPageAnime.Text = "Anime";
			this.tabPageAnime.UseVisualStyleBackColor = true;
			// 
			// tabPageMusic
			// 
			this.tabPageMusic.Location = new System.Drawing.Point(4, 22);
			this.tabPageMusic.Name = "tabPageMusic";
			this.tabPageMusic.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMusic.Size = new System.Drawing.Size(252, 179);
			this.tabPageMusic.TabIndex = 1;
			this.tabPageMusic.Text = "Music";
			this.tabPageMusic.UseVisualStyleBackColor = true;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbtnNew
			// 
			this.tsbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnNew.Image = global::AnimeTidy.Properties.Resources.TsNew;
			this.tsbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnNew.Name = "tsbtnNew";
			this.tsbtnNew.Size = new System.Drawing.Size(23, 22);
			this.tsbtnNew.Text = "New";
			this.tsbtnNew.Click += new System.EventHandler(this.tsbtnNew_Click);
			// 
			// tsbtnOpen
			// 
			this.tsbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnOpen.Image = global::AnimeTidy.Properties.Resources.TsOpen;
			this.tsbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnOpen.Name = "tsbtnOpen";
			this.tsbtnOpen.Size = new System.Drawing.Size(23, 22);
			this.tsbtnOpen.Text = "Open";
			this.tsbtnOpen.Click += new System.EventHandler(this.tsbtnOpen_Click);
			// 
			// tsbtnSave
			// 
			this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnSave.Image = global::AnimeTidy.Properties.Resources.TsSave;
			this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSave.Name = "tsbtnSave";
			this.tsbtnSave.Size = new System.Drawing.Size(23, 22);
			this.tsbtnSave.Text = "Save";
			this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnAdd.Image = global::AnimeTidy.Properties.Resources.TsAdd;
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(23, 22);
			this.tsbtnAdd.Text = "Add(I)";
			this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
			// 
			// tsbtnModify
			// 
			this.tsbtnModify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnModify.Image = global::AnimeTidy.Properties.Resources.TsModify;
			this.tsbtnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnModify.Name = "tsbtnModify";
			this.tsbtnModify.Size = new System.Drawing.Size(23, 22);
			this.tsbtnModify.Text = "Modify(E)";
			this.tsbtnModify.Click += new System.EventHandler(this.tsbtnModify_Click);
			// 
			// tsbtnDuplicate
			// 
			this.tsbtnDuplicate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnDuplicate.Image = global::AnimeTidy.Properties.Resources.TsDuplicate;
			this.tsbtnDuplicate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDuplicate.Name = "tsbtnDuplicate";
			this.tsbtnDuplicate.Size = new System.Drawing.Size(23, 22);
			this.tsbtnDuplicate.Text = "Duplicate(D)";
			this.tsbtnDuplicate.Click += new System.EventHandler(this.tsbtnDuplicate_Click);
			// 
			// tsbtnDelete
			// 
			this.tsbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnDelete.Image = global::AnimeTidy.Properties.Resources.TsDel;
			this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDelete.Name = "tsbtnDelete";
			this.tsbtnDelete.Size = new System.Drawing.Size(23, 22);
			this.tsbtnDelete.Text = "Delete";
			this.tsbtnDelete.Click += new System.EventHandler(this.tsbtnDelete_Click);
			// 
			// tsbtnUndo
			// 
			this.tsbtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnUndo.Image = global::AnimeTidy.Properties.Resources.TsUndo;
			this.tsbtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnUndo.Name = "tsbtnUndo";
			this.tsbtnUndo.Size = new System.Drawing.Size(23, 22);
			this.tsbtnUndo.Text = "Undo";
			this.tsbtnUndo.Click += new System.EventHandler(this.tsbtnUndo_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tsslSelName
			// 
			this.tsslSelName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsslSelName.Name = "tsslSelName";
			this.tsslSelName.Size = new System.Drawing.Size(108, 21);
			this.tsslSelName.Spring = true;
			this.tsslSelName.Text = "Selected: -";
			// 
			// tsslSelSpace
			// 
			this.tsslSelSpace.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsslSelSpace.Name = "tsslSelSpace";
			this.tsslSelSpace.Size = new System.Drawing.Size(108, 21);
			this.tsslSelSpace.Spring = true;
			this.tsslSelSpace.Text = "Selected Size: -";
			// 
			// tsslTotal
			// 
			this.tsslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsslTotal.Name = "tsslTotal";
			this.tsslTotal.Size = new System.Drawing.Size(53, 21);
			this.tsslTotal.Text = "Total: -";
			// 
			// tsslTotSpace
			// 
			this.tsslTotSpace.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsslTotSpace.Name = "tsslTotSpace";
			this.tsslTotSpace.Size = new System.Drawing.Size(80, 21);
			this.tsslTotSpace.Text = "Total Size: -";
			// 
			// tabAnimes
			// 
			this.tabAnimes.AnimeInfo = null;
			this.tabAnimes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabAnimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.tabAnimes.Location = new System.Drawing.Point(3, 3);
			this.tabAnimes.Name = "tabAnimes";
			this.tabAnimes.Size = new System.Drawing.Size(246, 173);
			this.tabAnimes.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.tabControlMain);
			this.Controls.Add(this.statusStripMain);
			this.Controls.Add(this.toolStripMain);
			this.Name = "MainForm";
			this.Text = "AnimeTidy";
			this.toolStripMain.ResumeLayout(false);
			this.toolStripMain.PerformLayout();
			this.statusStripMain.ResumeLayout(false);
			this.statusStripMain.PerformLayout();
			this.tabControlMain.ResumeLayout(false);
			this.tabPageAnime.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStripMain;
		private System.Windows.Forms.StatusStrip statusStripMain;
		public System.Windows.Forms.TabControl tabControlMain;
		private System.Windows.Forms.TabPage tabPageAnime;
		private System.Windows.Forms.TabPage tabPageMusic;
		private TabAnime tabAnimes;
		private System.Windows.Forms.ToolStripButton tsbtnNew;
		private System.Windows.Forms.ToolStripButton tsbtnOpen;
		public System.Windows.Forms.ToolStripButton tsbtnSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripButton tsbtnModify;
		private System.Windows.Forms.ToolStripButton tsbtnDuplicate;
		private System.Windows.Forms.ToolStripButton tsbtnDelete;
		private System.Windows.Forms.ToolStripButton tsbtnUndo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripStatusLabel tsslSelName;
		private System.Windows.Forms.ToolStripStatusLabel tsslSelSpace;
		private System.Windows.Forms.ToolStripStatusLabel tsslTotal;
		private System.Windows.Forms.ToolStripStatusLabel tsslTotSpace;
	}
}

