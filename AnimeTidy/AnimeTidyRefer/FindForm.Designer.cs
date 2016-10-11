namespace AnimeTidy
{
	partial class FindForm
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
			this.lblFilter = new System.Windows.Forms.Label();
			this.tbFilter = new System.Windows.Forms.TextBox();
			this.gbFilter = new System.Windows.Forms.GroupBox();
			this.rbtnRegex = new System.Windows.Forms.RadioButton();
			this.rbtnAnyText = new System.Windows.Forms.RadioButton();
			this.rbtnPrefix = new System.Windows.Forms.RadioButton();
			this.gbFilter.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblFilter
			// 
			this.lblFilter.AutoSize = true;
			this.lblFilter.Location = new System.Drawing.Point(12, 9);
			this.lblFilter.Name = "lblFilter";
			this.lblFilter.Size = new System.Drawing.Size(35, 12);
			this.lblFilter.TabIndex = 0;
			this.lblFilter.Text = "Find:";
			// 
			// tbFilter
			// 
			this.tbFilter.Location = new System.Drawing.Point(12, 24);
			this.tbFilter.Name = "tbFilter";
			this.tbFilter.Size = new System.Drawing.Size(260, 21);
			this.tbFilter.TabIndex = 1;
			this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
			// 
			// gbFilter
			// 
			this.gbFilter.Controls.Add(this.rbtnRegex);
			this.gbFilter.Controls.Add(this.rbtnAnyText);
			this.gbFilter.Controls.Add(this.rbtnPrefix);
			this.gbFilter.Location = new System.Drawing.Point(12, 51);
			this.gbFilter.Name = "gbFilter";
			this.gbFilter.Size = new System.Drawing.Size(260, 92);
			this.gbFilter.TabIndex = 2;
			this.gbFilter.TabStop = false;
			this.gbFilter.Text = "Find options";
			// 
			// rbtnRegex
			// 
			this.rbtnRegex.AutoSize = true;
			this.rbtnRegex.Location = new System.Drawing.Point(7, 65);
			this.rbtnRegex.Name = "rbtnRegex";
			this.rbtnRegex.Size = new System.Drawing.Size(53, 16);
			this.rbtnRegex.TabIndex = 2;
			this.rbtnRegex.TabStop = true;
			this.rbtnRegex.Text = "Regex";
			this.rbtnRegex.UseVisualStyleBackColor = true;
			this.rbtnRegex.CheckedChanged += new System.EventHandler(this.rbtnRegex_CheckedChanged);
			// 
			// rbtnAnyText
			// 
			this.rbtnAnyText.AutoSize = true;
			this.rbtnAnyText.Location = new System.Drawing.Point(7, 43);
			this.rbtnAnyText.Name = "rbtnAnyText";
			this.rbtnAnyText.Size = new System.Drawing.Size(71, 16);
			this.rbtnAnyText.TabIndex = 1;
			this.rbtnAnyText.TabStop = true;
			this.rbtnAnyText.Text = "Any Text";
			this.rbtnAnyText.UseVisualStyleBackColor = true;
			this.rbtnAnyText.CheckedChanged += new System.EventHandler(this.rbtnAnyText_CheckedChanged);
			// 
			// rbtnPrefix
			// 
			this.rbtnPrefix.AutoSize = true;
			this.rbtnPrefix.Checked = true;
			this.rbtnPrefix.Location = new System.Drawing.Point(7, 21);
			this.rbtnPrefix.Name = "rbtnPrefix";
			this.rbtnPrefix.Size = new System.Drawing.Size(59, 16);
			this.rbtnPrefix.TabIndex = 0;
			this.rbtnPrefix.TabStop = true;
			this.rbtnPrefix.Text = "Prefix";
			this.rbtnPrefix.UseVisualStyleBackColor = true;
			this.rbtnPrefix.CheckedChanged += new System.EventHandler(this.rbtnPrefix_CheckedChanged);
			// 
			// FindForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 155);
			this.Controls.Add(this.gbFilter);
			this.Controls.Add(this.tbFilter);
			this.Controls.Add(this.lblFilter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FindForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Find Animes";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindForm_FormClosing);
			this.gbFilter.ResumeLayout(false);
			this.gbFilter.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblFilter;
		private System.Windows.Forms.TextBox tbFilter;
		private System.Windows.Forms.GroupBox gbFilter;
		private System.Windows.Forms.RadioButton rbtnPrefix;
		private System.Windows.Forms.RadioButton rbtnRegex;
		private System.Windows.Forms.RadioButton rbtnAnyText;
	}
}