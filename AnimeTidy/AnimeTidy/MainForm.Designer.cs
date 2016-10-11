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
			this.tabAnimes = new AnimeTidy.TabAnime();
			this.tabControlMain.SuspendLayout();
			this.tabPageAnime.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripMain
			// 
			this.toolStripMain.Location = new System.Drawing.Point(0, 0);
			this.toolStripMain.Name = "toolStripMain";
			this.toolStripMain.Size = new System.Drawing.Size(284, 25);
			this.toolStripMain.TabIndex = 0;
			this.toolStripMain.Text = "toolStrip1";
			// 
			// statusStripMain
			// 
			this.statusStripMain.Location = new System.Drawing.Point(0, 239);
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
			this.tabControlMain.Location = new System.Drawing.Point(13, 29);
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.SelectedIndex = 0;
			this.tabControlMain.Size = new System.Drawing.Size(259, 207);
			this.tabControlMain.TabIndex = 2;
			// 
			// tabPageAnime
			// 
			this.tabPageAnime.Controls.Add(this.tabAnimes);
			this.tabPageAnime.Location = new System.Drawing.Point(4, 22);
			this.tabPageAnime.Name = "tabPageAnime";
			this.tabPageAnime.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAnime.Size = new System.Drawing.Size(251, 181);
			this.tabPageAnime.TabIndex = 0;
			this.tabPageAnime.Text = "Anime";
			this.tabPageAnime.UseVisualStyleBackColor = true;
			// 
			// tabPageMusic
			// 
			this.tabPageMusic.Location = new System.Drawing.Point(4, 22);
			this.tabPageMusic.Name = "tabPageMusic";
			this.tabPageMusic.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMusic.Size = new System.Drawing.Size(251, 181);
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
			this.tabAnimes.Size = new System.Drawing.Size(245, 175);
			this.tabAnimes.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.tabControlMain);
			this.Controls.Add(this.statusStripMain);
			this.Controls.Add(this.toolStripMain);
			this.Name = "MainForm";
			this.Text = "AnimeTidy";
			this.tabControlMain.ResumeLayout(false);
			this.tabPageAnime.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStripMain;
		private System.Windows.Forms.StatusStrip statusStripMain;
		private System.Windows.Forms.TabControl tabControlMain;
		private System.Windows.Forms.TabPage tabPageAnime;
		private System.Windows.Forms.TabPage tabPageMusic;
		private TabAnime tabAnimes;
	}
}

