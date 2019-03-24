using AnimeTidyLib;
using System;
using System.Windows.Forms;

namespace AnimeTidy
{
	public partial class EditForm : Form
	{
		public EditForm(ObjectListView olv)
		{
			InitializeComponent();

			InitForm();
			InitTable();

			this._olv = olv;
		}

		protected virtual void InitForm() { }

		protected virtual void InitTable() { }

		private ObjectListView _olv;
		public ObjectListView ListView
		{
			get { return this._olv; }
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.Confirm();
		}

		protected virtual void Confirm() { }

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
