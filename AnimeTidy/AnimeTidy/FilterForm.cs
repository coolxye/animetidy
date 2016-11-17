using AnimeTidy.Models;
using AnimeTidyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimeTidy
{
	public partial class FilterForm : Form
	{
		private FilterForm()
		{
			InitializeComponent();

			this._kind = MatchKind.Prefix;
		}

		private static FilterForm ff = null;

		private static ObjectListView _olv;
		private ObjectListView ListView
		{
			get { return _olv; }
		}

		private MatchKind _kind;
		private MatchKind Kind
		{
			get { return this._kind; }
		}

		public static FilterForm GetInstance(ObjectListView olv)
		{
			_olv = olv;

			if (ff == null)
				ff = new FilterForm();

			if (ff.IsDisposed)
			{
				ff = null;
				ff = new FilterForm();
			}

			return ff;
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				this.Hide();
				this.tbFind.Text = String.Empty;
				this.TimedFilter(this.ListView, String.Empty);
				return true;
			}

			return base.ProcessDialogKey(keyData);
		}

		private void TimedFilter(ObjectListView olv, string txt)
		{
			TextMatchFilter filter = null;
			if (!String.IsNullOrEmpty(txt))
			{
				switch (Kind)
				{
					case MatchKind.Prefix:
					default:
						filter = TextMatchFilter.Prefix(olv, txt);
						break;

					case MatchKind.AnyText:
						filter = TextMatchFilter.Contains(olv, txt);
						break;

					case MatchKind.Regex:
						filter = TextMatchFilter.Regex(olv, txt);
						break;
				}
			}

            // Text highlighting requires at least a default renderer
			if (olv.DefaultRenderer == null)
			olv.DefaultRenderer = new HighlightTextRenderer(filter);

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();
			olv.AdditionalFilter = filter;
			stopWatch.Stop();
		}

		private void tbFind_TextChanged(object sender, EventArgs e)
		{
			this.TimedFilter(this.ListView, this.tbFind.Text);
		}

		private void radbtnPrefix_Click(object sender, EventArgs e)
		{
			if (this._kind != MatchKind.Prefix)
			{
				this._kind = MatchKind.Prefix;
				this.TimedFilter(this.ListView, this.tbFind.Text);
			}
		}

		private void radbtnAnyText_Click(object sender, EventArgs e)
		{
			if (this._kind != MatchKind.AnyText)
			{
				this._kind = MatchKind.AnyText;
				this.TimedFilter(this.ListView, this.tbFind.Text);
			}
		}

		private void radbtnRegex_Click(object sender, EventArgs e)
		{
			if (this._kind != MatchKind.Regex)
			{
				this._kind = MatchKind.Regex;
				this.TimedFilter(this.ListView, this.tbFind.Text);
			}
		}

		private void FindForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.tbFind.Text.Length > 0)
				this.TimedFilter(this.ListView, String.Empty);
		}
	}
}
