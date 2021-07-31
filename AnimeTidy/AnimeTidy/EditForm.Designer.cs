namespace AnimeTidy
{
	partial class EditForm
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.tableLayoutPanelEdit = new System.Windows.Forms.TableLayoutPanel();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(296, 340);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(112, 34);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(174, 340);
			this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(112, 34);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// tableLayoutPanelEdit
			// 
			this.tableLayoutPanelEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanelEdit.AutoScroll = true;
			this.tableLayoutPanelEdit.ColumnCount = 2;
			this.tableLayoutPanelEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelEdit.Location = new System.Drawing.Point(20, 18);
			this.tableLayoutPanelEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tableLayoutPanelEdit.Name = "tableLayoutPanelEdit";
			this.tableLayoutPanelEdit.RowCount = 2;
			this.tableLayoutPanelEdit.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEdit.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelEdit.Size = new System.Drawing.Size(388, 314);
			this.tableLayoutPanelEdit.TabIndex = 0;
			// 
			// EditForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(426, 393);
			this.Controls.Add(this.tableLayoutPanelEdit);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "EditForm";
			this.Text = "EditForm";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		protected System.Windows.Forms.TableLayoutPanel tableLayoutPanelEdit;
	}
}