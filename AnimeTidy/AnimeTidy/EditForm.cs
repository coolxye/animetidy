using AnimeTidy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimeTidy
{
	public partial class EditForm : Form
	{
		public EditForm()
		{
			InitializeComponent();

			InitForm();
			InitTable();
		}

		protected virtual void InitForm() { }

		protected virtual void InitTable() { }

		private void btnOK_Click(object sender, EventArgs e)
		{

		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
