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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStripMain = new System.Windows.Forms.ToolStrip();
			this.tsbtnNew = new System.Windows.Forms.ToolStripButton();
			this.tsbtnOpen = new System.Windows.Forms.ToolStripButton();
			this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
			this.statusStripMain = new System.Windows.Forms.StatusStrip();
			this.tabControlMain = new System.Windows.Forms.TabControl();
			this.tabPageAnime = new System.Windows.Forms.TabPage();
			this.tabPageMusic = new System.Windows.Forms.TabPage();
			this.tabAnimes = new AnimeTidy.TabAnime();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripMain.SuspendLayout();
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
            this.tsbtnAdd});
			this.toolStripMain.Location = new System.Drawing.Point(0, 0);
			this.toolStripMain.Name = "toolStripMain";
			this.toolStripMain.Size = new System.Drawing.Size(284, 25);
			this.toolStripMain.TabIndex = 0;
			this.toolStripMain.Text = "toolStrip1";
			// 
			// tsbtnNew
			// 
			this.tsbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNew.Image")));
			this.tsbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnNew.Name = "tsbtnNew";
			this.tsbtnNew.Size = new System.Drawing.Size(23, 22);
			this.tsbtnNew.Text = "New";
			this.tsbtnNew.Click += new System.EventHandler(this.tsbtnNew_Click);
			// 
			// tsbtnOpen
			// 
			this.tsbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpen.Image")));
			this.tsbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnOpen.Name = "tsbtnOpen";
			this.tsbtnOpen.Size = new System.Drawing.Size(23, 22);
			this.tsbtnOpen.Text = "Open";
			this.tsbtnOpen.Click += new System.EventHandler(this.tsbtnOpen_Click);
			// 
			// tsbtnSave
			// 
			this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
			this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSave.Name = "tsbtnSave";
			this.tsbtnSave.Size = new System.Drawing.Size(23, 22);
			this.tsbtnSave.Text = "Save";
			this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
			// 
			// statusStripMain
			// 
			this.statusStripMain.Location = new System.Drawing.Point(0, 240);
			this.statusStripMain.Name = "statusStripMain";
			this.statusStripMain.Size = new System.Drawing.Size(284, 22);
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
			this.tabControlMain.Size = new System.Drawing.Size(260, 209);
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
			this.tabPageAnime.Size = new System.Drawing.Size(252, 183);
			this.tabPageAnime.TabIndex = 0;
			this.tabPageAnime.Text = "Anime";
			this.tabPageAnime.UseVisualStyleBackColor = true;
			// 
			// tabPageMusic
			// 
			this.tabPageMusic.Location = new System.Drawing.Point(4, 22);
			this.tabPageMusic.Name = "tabPageMusic";
			this.tabPageMusic.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMusic.Size = new System.Drawing.Size(252, 183);
			this.tabPageMusic.TabIndex = 1;
			this.tabPageMusic.Text = "Music";
			this.tabPageMusic.UseVisualStyleBackColor = true;
			// 
			// tabAnimes
			// 
			this.tabAnimes.AnimeInfo = null;
			this.tabAnimes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabAnimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.tabAnimes.Location = new System.Drawing.Point(3, 3);
			this.tabAnimes.Name = "tabAnimes";
			this.tabAnimes.Size = new System.Drawing.Size(246, 177);
			this.tabAnimes.TabIndex = 0;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAdd.Image")));
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(23, 22);
			this.tsbtnAdd.Text = "Add";
			this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
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
	}
}

