using AnimeTidyLib;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AnimeTidy
{
	public partial class FindForm : Form
	{
		public FindForm()
		{
			InitializeComponent();
		}

		public FindForm(ObjectListView olv)
		{
			InitializeComponent();

			folv = olv;
		}

		private ObjectListView folv;
		private int ikind = -1;

		#region key event
		//private void FindForm_KeyDown(object sender, KeyEventArgs e)
		//{
		//	if (e.KeyCode == Keys.Escape)
		//	{
		//		if (this.tbFilter.Text.Length != 0)
		//			this.TimedFilter(this.folv, "", this.ikind);

		//		this.Close();
		//	}
		//}
		#endregion

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				if (this.tbFilter.Text.Length != 0)
					this.TimedFilter(this.folv, "", this.ikind);

				this.Close();

				return true;
			}

			return base.ProcessDialogKey(keyData);
		}

		private void TimedFilter(ObjectListView folv, string txt, int matchKind)
		{
			TextMatchFilter filter = null;
			if (!String.IsNullOrEmpty(txt))
			{
				switch (matchKind)
				{
					case 0:
					default:
						filter = TextMatchFilter.Prefix(folv, txt);
						break;
					case 1:
						filter = TextMatchFilter.Contains(folv, txt);
						break;
					case 2:
						filter = TextMatchFilter.Regex(folv, txt);
						break;
				}
			}
			// Setup a default renderer to draw the filter matches
			if (filter == null)
				folv.DefaultRenderer = null;
			else
				folv.DefaultRenderer = new HighlightTextRenderer(filter);

			// Some lists have renderers already installed
			HighlightTextRenderer highlightingRenderer = folv.GetColumn(0).Renderer as HighlightTextRenderer;
			if (highlightingRenderer != null)
				highlightingRenderer.Filter = filter;

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();
			folv.ModelFilter = filter;
			stopWatch.Stop();
		}

		private void tbFilter_TextChanged(object sender, EventArgs e)
		{
			this.TimedFilter(this.folv, this.tbFilter.Text, this.ikind);
		}

		private void rbtnPrefix_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rbtnPrefix.Checked)
			{
				ikind = 0;
				this.TimedFilter(this.folv, this.tbFilter.Text, this.ikind);
			}
		}

		private void rbtnAnyText_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rbtnAnyText.Checked)
			{
				ikind = 1;
				this.TimedFilter(this.folv, this.tbFilter.Text, this.ikind);
			}
		}

		private void rbtnRegex_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rbtnRegex.Checked)
			{
				ikind = 2;
				this.TimedFilter(this.folv, this.tbFilter.Text, this.ikind);
			}
		}

		private void FindForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.tbFilter.Text.Length != 0)
				this.TimedFilter(this.folv, "", this.ikind);
		}
	}
}
