namespace AnimeTidy
{
	partial class FilterForm
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
			this.lblFind = new System.Windows.Forms.Label();
			this.tbFind = new System.Windows.Forms.TextBox();
			this.grpboxOption = new System.Windows.Forms.GroupBox();
			this.radbtnRegex = new System.Windows.Forms.RadioButton();
			this.radbtnAnyText = new System.Windows.Forms.RadioButton();
			this.radbtnPrefix = new System.Windows.Forms.RadioButton();
			this.grpboxOption.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblFind
			// 
			this.lblFind.AutoSize = true;
			this.lblFind.Location = new System.Drawing.Point(18, 22);
			this.lblFind.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblFind.Name = "lblFind";
			this.lblFind.Size = new System.Drawing.Size(53, 18);
			this.lblFind.TabIndex = 0;
			this.lblFind.Text = "Find:";
			// 
			// tbFind
			// 
			this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFind.Location = new System.Drawing.Point(80, 18);
			this.tbFind.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tbFind.Name = "tbFind";
			this.tbFind.Size = new System.Drawing.Size(326, 28);
			this.tbFind.TabIndex = 1;
			this.tbFind.TextChanged += new System.EventHandler(this.tbFind_TextChanged);
			// 
			// grpboxOption
			// 
			this.grpboxOption.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpboxOption.Controls.Add(this.radbtnRegex);
			this.grpboxOption.Controls.Add(this.radbtnAnyText);
			this.grpboxOption.Controls.Add(this.radbtnPrefix);
			this.grpboxOption.Location = new System.Drawing.Point(18, 58);
			this.grpboxOption.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.grpboxOption.Name = "grpboxOption";
			this.grpboxOption.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.grpboxOption.Size = new System.Drawing.Size(390, 316);
			this.grpboxOption.TabIndex = 2;
			this.grpboxOption.TabStop = false;
			this.grpboxOption.Text = "Find Option";
			// 
			// radbtnRegex
			// 
			this.radbtnRegex.AutoSize = true;
			this.radbtnRegex.Location = new System.Drawing.Point(10, 100);
			this.radbtnRegex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.radbtnRegex.Name = "radbtnRegex";
			this.radbtnRegex.Size = new System.Drawing.Size(78, 22);
			this.radbtnRegex.TabIndex = 2;
			this.radbtnRegex.TabStop = true;
			this.radbtnRegex.Text = "Regex";
			this.radbtnRegex.UseVisualStyleBackColor = true;
			this.radbtnRegex.Click += new System.EventHandler(this.radbtnRegex_Click);
			// 
			// radbtnAnyText
			// 
			this.radbtnAnyText.AutoSize = true;
			this.radbtnAnyText.Location = new System.Drawing.Point(10, 66);
			this.radbtnAnyText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.radbtnAnyText.Name = "radbtnAnyText";
			this.radbtnAnyText.Size = new System.Drawing.Size(105, 22);
			this.radbtnAnyText.TabIndex = 1;
			this.radbtnAnyText.TabStop = true;
			this.radbtnAnyText.Text = "Any Text";
			this.radbtnAnyText.UseVisualStyleBackColor = true;
			this.radbtnAnyText.Click += new System.EventHandler(this.radbtnAnyText_Click);
			// 
			// radbtnPrefix
			// 
			this.radbtnPrefix.AutoSize = true;
			this.radbtnPrefix.Checked = true;
			this.radbtnPrefix.Location = new System.Drawing.Point(10, 32);
			this.radbtnPrefix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.radbtnPrefix.Name = "radbtnPrefix";
			this.radbtnPrefix.Size = new System.Drawing.Size(87, 22);
			this.radbtnPrefix.TabIndex = 0;
			this.radbtnPrefix.TabStop = true;
			this.radbtnPrefix.Text = "Prefix";
			this.radbtnPrefix.UseVisualStyleBackColor = true;
			this.radbtnPrefix.Click += new System.EventHandler(this.radbtnPrefix_Click);
			// 
			// FilterForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(426, 393);
			this.Controls.Add(this.grpboxOption);
			this.Controls.Add(this.tbFind);
			this.Controls.Add(this.lblFind);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "FilterForm";
			this.Text = "Find";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindForm_FormClosing);
			this.grpboxOption.ResumeLayout(false);
			this.grpboxOption.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblFind;
		private System.Windows.Forms.TextBox tbFind;
		private System.Windows.Forms.GroupBox grpboxOption;
		private System.Windows.Forms.RadioButton radbtnPrefix;
		private System.Windows.Forms.RadioButton radbtnAnyText;
		private System.Windows.Forms.RadioButton radbtnRegex;
	}
}