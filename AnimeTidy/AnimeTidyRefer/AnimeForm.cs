/*
 * Designed from AnimeTrim2
 * User: XianYe
 * Date: 2010/8/10
 * Time: 9:23
*/
using AnimeTidy.Core;
using AnimeTidyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace AnimeTidy
{
	public partial class AnimeForm : Form
	{
		public AnimeForm()
		{
			InitializeComponent();

			// edit 13/1/8 for bug3
			InitAnimeInfo();
			// edit fin
			InitForm();
			InitModel();
			InitAccessFile();
		}

		// const string
		private const String _sout = "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}" +
			"\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}\t{16}\t{17}\t{18}\t{19}";
		private const String assemname = "AnimeTidy";
		private const String xmlpath = @".\AnimeTidy.xml";
		private const String filefilter = "AnimeTidy Files|*.xat";
		private const String formatfilter = "AnimeTidy Files|*.at";

		// 1G = 1024 * 1024 * 1024 Byte
		//private const Double _dSizeG = 1073741824D;
		// 1M = 1024 * 1024 Byte
		//private const Double _dSizeM = 1048576D;

		private AnimeInfo _ai = new AnimeInfo();
		//private List<Anime> _lani = new List<Anime>();
		//private List<Anime> lstAnime;
		// stack for restore duplicated or deleted
		//private List<int> relindex = new List<int>();
		private int reists = -1;
		private List<Anime> relani = new List<Anime>();

		private FindForm findfm;

		// edit 13/1/8 for bug3
		// Initalize the anime datas
		private void InitAnimeInfo()
		{
			_ai.SaveStatusChanged += AnimeInfo_SaveStatusChanged;
		}
		// edit fin

		private void AnimeInfo_SaveStatusChanged(object sender, PropertyChangedEventArgs e)
		{
			this.tsBtnSave.Enabled = !_ai.IsSaved;
		}

		// Initalize the controls
		private void InitForm()
		{
			this.tsBtnSave.Enabled = false;
			this.tsBtnModify.Enabled = false;
			this.tsBtnDuplicate.Enabled = false;
			this.tsBtnDel.Enabled = false;
			this.tsBtnRefresh.Enabled = false;
			this.tsBtnUndo.Enabled = false;

			//this.cboFilter.SelectedIndex = 0;

			this.tssBtnMore.DefaultItem = this.tsMenItmBackup;
			this.tssBtnMore.Text = this.tsMenItmBackup.Text;
			this.tssBtnMore.ToolTipText = this.tsMenItmBackup.ToolTipText;
			this.tssBtnMore.Image = this.tsMenItmBackup.Image;

			this.tsBtnOverlay.CheckState = CheckState.Checked;
		}

		// Initalize the path and name of AnimeInfo from a xml
		private void InitAccessFile()
		{
			if (!File.Exists(xmlpath))
				return;

			XPathDocument xptdoc = new XPathDocument(xmlpath);
			XPathNavigator xptnavi = xptdoc.CreateNavigator();

			XPathNavigator xt = xptnavi.SelectSingleNode("//LastAccessName");
			if (xt == null || String.IsNullOrEmpty(xt.Value))
				return;

			_ai.Name = xt.Value;

			xt = xptnavi.SelectSingleNode("//LastAccessPath");
			if (xt == null || String.IsNullOrEmpty(xt.Value) || !File.Exists(xt.Value))
			{
				_ai.Name = null;

				return;
			}

			_ai.Path = xt.Value;

			if (!ReadXat())
				//BindData();
			//else
				_ai.Restore();
		}

		// Read file to initalize the list of Anime
		private bool ReadXat()
		{
			StreamReader sr = new StreamReader(_ai.Path);
			string line = sr.ReadLine();

			if (String.IsNullOrEmpty(line))
				return false;

			string[] info = line.Split('\t');
			if (info.Length != 3)
				return false;

			//int lasttotal = _ai.Total;

			int it;
			if (!Int32.TryParse(info[0], out it))
			{
				MessageBox.Show(this, "The line 1 is wrong.", "Read error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				sr.Close();

				return false;
			}
			else _ai.Total = it;

			long lt;
			if (!Int64.TryParse(info[1], out lt))
			{
				MessageBox.Show(this, "The line 1 is wrong.", "Read error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				sr.Close();

				return false;
			}
			else _ai.Space = lt;

			uint ut;
			if (!UInt32.TryParse(info[2], out ut))
			{
				MessageBox.Show(this, "The line 1 is wrong.", "Read error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				sr.Close();

				return false;
			}
			else _ai.Uid = ut;

			List<Anime> lstAnime = new List<Anime>();
			int iErr = 0;
			try
			{
				while (!String.IsNullOrEmpty(line = sr.ReadLine()))
				{
					iErr++;
					info = line.Split('\t');

					Anime ani = new Anime();
					ani.ID = UInt32.Parse(info[0]);
					ani.Title = info[1];
					ani.Name = info[2];
					ani.Year = UInt32.Parse(info[3]);
					ani.Season = (PlaySeason)Enum.Parse(typeof(PlaySeason), info[4]);
					ani.Type = (MediaType)Enum.Parse(typeof(MediaType), info[5]);
					ani.Format = (MergeFormat)Enum.Parse(typeof(MergeFormat), info[6]);
					ani.SubTeam = info[7];
					ani.SubStyle = (SubStyles)Enum.Parse(typeof(SubStyles), info[8]);
					ani.Path = info[9];
					ani.Size = Int64.Parse(info[10]);
					ani.Store = Boolean.Parse(info[11]);
					ani.Enjoy = Boolean.Parse(info[12]);
					ani.Grade = Int32.Parse(info[13]);
					ani.CreateTime = DateTime.Parse(info[14]);
					ani.UpdateTime = DateTime.Parse(info[15]);
					ani.Kana = info[16];
					ani.Episode = info[17];
					ani.Inc = info[18];
					ani.Note = info[19];

					//_lani.Add(ani);
					lstAnime.Add(ani);
				}

				//_lani.RemoveRange(0, lasttotal);
			}
			catch (Exception)
			{
				MessageBox.Show(this, String.Format("The line {0} is wrong.", iErr + 1), "Read error",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);

				//_lani.RemoveRange(lasttotal, iErr - 1);
				lstAnime.Clear();

				return false;
			}
			finally
			{
				sr.Close();
			}

			if (!_ai.IsNew)
			{
				ResetAll();
			}

			_ai.IsNew = false;
			_ai.IsSaved = true;
			_ai.Backup();

			this.folvAnime.SetObjects(lstAnime);

			this.tctlAnime.SelectedTab.Text = _ai.Name;
			this.tctlAnime.SelectedTab.ToolTipText = _ai.Path;
			this.tsslTotal.Text = String.Format("Total: {0}", _ai.Total);
			this.tsslSpace.Text = String.Format("Total Size: {0:#,##0.#0} GB", _ai.Space / 1073741824D);

			return true;
		}

		// Initalize the Format of the ObjectListView
		private void InitModel()
		{
			if (ObjectListView.IsVistaOrLater)
				this.Font = new Font("msyh", 8);

			this.folvAnime.AddDecoration(new EditingCellBorderDecoration(true));

			TypedObjectListView<Anime> tolv = new TypedObjectListView<Anime>(this.folvAnime);
			tolv.GenerateAspectGetters();

			// Name of Anime
			TypedColumn<Anime> tc = new TypedColumn<Anime>(this.olvColName);
			tc.AspectPutter = (Anime a, object opn) => { a.Name = opn.ToString(); };

			// Schedule of Anime
			tc = new TypedColumn<Anime>(this.olvColSchedule);
			tc.GroupKeyGetter = (Anime a) => a.Year;

			// Type of Anime
			tc = new TypedColumn<Anime>(this.olvColType);
			tc.AspectPutter = (Anime a, object opt) => { a.Type = (MediaType)opt; };
			tc.ImageGetter = (Anime a) => {
				switch (a.Format)
				{
					case MergeFormat.MKV:
						return Properties.Resources.MKV;

					case MergeFormat.MP4:
						return Properties.Resources.MP4;

					case MergeFormat.AVI:
						return Properties.Resources.AVI;

					case MergeFormat.WMV:
						return Properties.Resources.WMV;

					case MergeFormat.M2TS:
						return Properties.Resources.M2TS;

					default:
						return -1;
				}
			};

			// Format of Anime
			#region
			//this.olvColFormat.Renderer = new MappedImageRenderer(new object[] {
			//	MergeFormat.MKV, Properties.Resources.MKV,
			//	MergeFormat.MP4, Properties.Resources.MP4,
			//	MergeFormat.AVI, Properties.Resources.AVI,
			//	MergeFormat.WMV, Properties.Resources.WMV,
			//	MergeFormat.M2TS, Properties.Resources.M2TS
			//});
			//tc = new TypedColumn<Anime>(this.olvColFormat);
			//tc.AspectPutter = delegate(Anime a, object opf) { a.Format = (MergeFormat)opf; };
			#endregion

			// SubTeam of Anime
			tc = new TypedColumn<Anime>(this.olvColSubTeam);
			tc.AspectPutter = (Anime a, object opp) => { a.SubTeam = opp.ToString(); };
			tc.ImageGetter = (Anime a) => {
				switch (a.SubStyle)
				{
					case SubStyles.External:
						return Properties.Resources.External;
					
					case SubStyles.Sealed:
						return Properties.Resources.Sealed;

					case SubStyles.Embedded:
						return Properties.Resources.Embedded;

					default:
						return -1;
				}
			};

			// SubStyle of Anime
			#region
			//this.olvColSubStyle.Renderer = new MappedImageRenderer(new object[] {
			//	SubStyles.External, Properties.Resources.External,
			//	SubStyles.Sealed, Properties.Resources.Sealed,
			//	SubStyles.Embedded, Properties.Resources.Embedded
			//});
			//tc = new TypedColumn<Anime>(this.olvColSubStyle);
			//tc.AspectPutter = delegate(Anime a, object ops) { a.SubStyle = (SubStyles)ops; };
			#endregion

			// Size of Anime
			this.olvColSize.AspectToStringConverter = ots => {
				long ls = (long)ots;

				if (ls == 0L)
					return "-";
				else if (ls >= 1000000000L)
					return String.Format("{0:#,##0.#0} G", ls / 1073741824D);
				else
					return String.Format("{0:#,##0.#0} M", ls / 1048576D);
			};
			this.olvColSize.MakeGroupies(
				new long[] { 5368709120L, 10737418240L },
				new string[] { "0~5 GB", "5~10 GB", ">10 GB" }
				);

			// Store of Anime
			tc = new TypedColumn<Anime>(this.olvColStore);
			tc.AspectPutter = (Anime a, object opg) => { a.Store = (bool)opg; };
			this.olvColStore.Renderer = new MappedImageRenderer(true, Properties.Resources.Accept, false, Properties.Resources.Alert);

			// Enjoy of Anime
			tc = new TypedColumn<Anime>(this.olvColEnjoy);
			tc.AspectPutter = (Anime a, object opv) => { a.Enjoy = (bool)opv; };
			this.olvColEnjoy.Renderer = new MappedImageRenderer(true, Properties.Resources.Smile, false, Properties.Resources.Sad);

			// Grade of Anime
			tc = new TypedColumn<Anime>(this.olvColGrade);
			tc.AspectPutter = (Anime a, object opr) => {
				int onr = (int)opr;
				a.Grade = onr;//onr < 1 ? 1 : onr;
			};
			this.olvColGrade.Renderer = new MultiImageRenderer(Properties.Resources.Diamond, 3, 0, 4);
			this.olvColGrade.MakeGroupies(
				new int[] { 1, 2 },
				new string[] { "Normal", "Nice", "Good" }
				);

			// Note of Anime
			this.olvColNote.AspectToStringConverter = otn => otn.ToString().Replace('\u0002', '\u0020');

			//RowBorderDecoration rbd = new RowBorderDecoration();
			//rbd.BorderPen = new Pen(Color.Orchid, 1);
			//rbd.FillBrush = null;
			//rbd.CornerRounding = 4.0f;
			//HotItemStyle hotItemStyle = new HotItemStyle();
			//hotItemStyle.Decoration = rbd;
			//hotItemStyle.Overlay = new AnimeViewOverlay();
			//this.folvAnime.HotItemStyle = hotItemStyle;

			this.folvAnime.UseTranslucentHotItem = true;
			this.folvAnime.UseTranslucentSelection = true;
			this.folvAnime.HotItemStyle.Overlay = new AnimeViewOverlay();
			this.folvAnime.HotItemStyle = this.folvAnime.HotItemStyle;
			this.folvAnime.PrimarySortColumn = this.olvColTitle;
			this.folvAnime.PrimarySortOrder = SortOrder.Ascending;
		}

		// Initalize the model data of Anime to the ObjectListView
		private void BindData()
		{
			//_ai.IsNew = false;
			//_ai.IsSaved = true;
			//_ai.Backup();

			////this.folvAnime.SetObjects(_lani);
			//this.folvAnime.SetObjects(lstAnime);

			//this.tctlAnime.SelectedTab.Text = _ai.Name;
			//this.tctlAnime.SelectedTab.ToolTipText = _ai.Path;
			//this.tsslTotal.Text = String.Format("Total: {0}", _ai.Total);
			//this.tsslSpace.Text = String.Format("Total Size: {0:#,##0.#0} GB", _ai.Space / 1073741824D);
		}

		private void UpdateAnimeDoc()
		{
			StreamWriter sw = new StreamWriter(_ai.Path, false, Encoding.Unicode);

			sw.WriteLine("{0}\t{1}\t{2}", _ai.Total, _ai.Space, _ai.Uid);

			//_lani.ForEach(delegate(Anime a)
			//{
			//    sw.WriteLine(_sout,
			//        a.ID, a.Title, a.Name, a.Year, a.Season, a.Type, a.Format,
			//        a.SubTeam, a.SubStyle, a.Path, a.Size, a.Store,
			//        a.Enjoy, a.Grade, a.CreateTime, a.UpdateTime, a.Kana,
			//        a.Episode, a.Inc, a.Note);
			//});
			foreach (Anime a in this.folvAnime.Objects)
				sw.WriteLine(_sout,
					a.ID, a.Title, a.Name, a.Year, a.Season, a.Type, a.Format,
					a.SubTeam, a.SubStyle, a.Path, a.Size, a.Store,
					a.Enjoy, a.Grade, a.CreateTime, a.UpdateTime, a.Kana,
					a.Episode, a.Inc, a.Note);

			sw.Close();
		}

		private void ResetAll()
		{
			// Tab reset
			switch (this.tctlAnime.SelectedIndex)
			{
				case 0: this.tpAnime.Text = "Anime"; this.tpAnime.ToolTipText = ""; break;
				case 1: this.tpMusic.Text = "Music"; break;
			}

			// FastObjectListView & RichTextBox clear
			this.folvAnime.ClearObjects();
			this.rtbAnime.Clear();

			// Button reset
			this.tsBtnModify.Enabled = false;
			this.tsBtnDuplicate.Enabled = false;
			this.tsBtnDel.Enabled = false;
			this.tsBtnRefresh.Enabled = false;

			// StatusStrip reset
			this.tsslSelected.Text = "Selected: ";
			this.tsslSelSpace.Text = "Selected Size: ";
			this.tsslTotal.Text = "Total: ";
			this.tsslSpace.Text = "Total Size: ";
		}

		// edit 13/1/9 for bug3
		private bool SaveCheck()
		{
			if (_ai.IsSaved)
				return true;

			DialogResult dr;
			dr = MessageBox.Show(this, "Save current Anime?", "Save",
				MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

			if (dr == DialogResult.Yes)
				return SaveData();
			else if (dr == DialogResult.No)
				return true;
			else
				return false;
		}

		private bool SaveData()
		{
			if (!_ai.IsNew)
			{
				UpdateAnimeDoc();
				_ai.IsSaved = true;

				return true;
			}

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = filefilter;

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				_ai.Path = sfd.FileName;
				_ai.Name = Path.GetFileName(_ai.Path);
				_ai.IsNew = false;
				_ai.IsSaved = true;

				UpdateAnimeDoc();

				return true;
			}
			else
				return false;
		}
		// edit fin

		private void folvAnime_SelectionChanged(object sender, EventArgs e)
		{
			int iSel = this.folvAnime.SelectedIndices.Count;

			if (iSel == 1)
			{
				Anime a = this.folvAnime.SelectedObject as Anime;

				this.tsslSelected.Text = String.Format("Selected: {0}", a.Name);
				this.tsslSelSpace.Text = (a.Size == 0L) ? "Selected Size: -" :
					(a.Size >= 1000000000L) ? String.Format("Selected Size: {0:#,##0.#0} GB", a.Size / 1073741824D) :
					String.Format("Selected Size: {0:#,##0.#0} MB", a.Size / 1048576D);

				this.rtbAnime.Text = a.Remark;
				this.tsBtnModify.Enabled = true;
				this.tsBtnDuplicate.Enabled = true;
				this.tsBtnDel.Enabled = true;
				this.tsBtnRefresh.Enabled = true;
			}
			else
			{
				if (iSel == 0)
				{
					this.tsBtnDuplicate.Enabled = false;
					this.tsBtnDel.Enabled = false;
					this.tsBtnRefresh.Enabled = false;

					this.tsslSelected.Text = "Selected: ";
					this.tsslSelSpace.Text = "Selected Size: ";
				}
				else
				{
					this.tsBtnDuplicate.Enabled = true;
					this.tsBtnDel.Enabled = true;
					this.tsBtnRefresh.Enabled = true;

					this.tsslSelected.Text = String.Format("Selected: {0}", iSel);

					long ls = 0L;
					foreach (Anime at in this.folvAnime.SelectedObjects)
					{
						ls += at.Size;
					}
					this.tsslSelSpace.Text = (ls == 0L) ? "Selected Size: -" :
						(ls >= 1000000000L) ? String.Format("Selected Size: {0:#,##0.#0} GB", ls / 1073741824D) :
						String.Format("Selected Size: {0:#,##0.#0} MB", ls / 1048576D);
				}

				this.rtbAnime.ResetText();
				this.tsBtnModify.Enabled = false;
			}
		}

		#region Move
		//private void TimedFilter(ObjectListView folv, string txt, int matchKind)
		//{
		//	TextMatchFilter filter = null;
		//	if (!String.IsNullOrEmpty(txt))
		//	{
		//		switch (matchKind)
		//		{
		//			case 0:
		//			default:
		//				filter = TextMatchFilter.Prefix(folv, txt);
		//				break;
		//			case 1:
		//				filter = TextMatchFilter.Contains(folv, txt);
		//				break;
		//			case 2:
		//				filter = TextMatchFilter.Regex(folv, txt);
		//				break;
		//		}
		//	}
		//	// Setup a default renderer to draw the filter matches
		//	if (filter == null)
		//		folv.DefaultRenderer = null;
		//	else
		//		folv.DefaultRenderer = new HighlightTextRenderer(filter);

		//	// Some lists have renderers already installed
		//	HighlightTextRenderer highlightingRenderer = folv.GetColumn(0).Renderer as HighlightTextRenderer;
		//	if (highlightingRenderer != null)
		//		highlightingRenderer.Filter = filter;

		//	Stopwatch stopWatch = new Stopwatch();
		//	stopWatch.Start();
		//	folv.ModelFilter = filter;
		//	stopWatch.Stop();
		//}

		//private void tbFilter_TextChanged(object sender, EventArgs e)
		//{
		//	this.TimedFilter(this.folvAnime, this.tbFilter.Text, this.cboFilter.SelectedIndex);
		//}

		//private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//	this.tbFilter_TextChanged(null, null);
		//}
		#endregion

		private void tsBtnNew_Click(object sender, EventArgs e)
		{
			// edit 13/1/9 for bug3
			//if (!_ai.IsSaved)
			//{
			//    DialogResult dr;
			//    dr = MessageBox.Show(this, "Save current Anime?", "Save",
			//        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			//    if (dr == DialogResult.Yes)
			//        tsBtnSave_Click(null, null);
			//}
			if (!SaveCheck())
				return;
			// edit fin

			if (!_ai.IsNew)
			{
				_ai.IsNew = true;
				_ai.IsSaved = true;
				_ai.Clear();

				ResetAll();
			}
		}

		private void tsBtnOpen_Click(object sender, EventArgs e)
		{
			// edit 13/1/9 for bug3
			//if (!_ai.IsSaved)
			//{
			//    DialogResult dr;
			//    dr = MessageBox.Show(this, "Save current Anime?", "Save",
			//        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

			//    if (dr == DialogResult.Yes)
			//        tsBtnSave_Click(null, null);
			//    else if (dr == DialogResult.Cancel)
			//        return;
			//}
			if (!SaveCheck())
				return;
			// edit fin

			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = filefilter;

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				if (_ai.Path == ofd.FileName)
					return;

				_ai.Path = ofd.FileName;
				_ai.Name = ofd.SafeFileName;

				if (!ReadXat())
					//{
					//    if (!_ai.IsNew)
					//        ResetAll();

					//    BindData();
					//}
					//else _ai.Restore();
					_ai.Restore();
			}
		}

		private void tsBtnSave_Click(object sender, EventArgs e)
		{
			// edit 13/1/9 for bug3
			//if (!_ai.IsNew)
			//{
			//    UpdateAnimeDoc();
			//    _ai.IsSaved = true;
			//    this.tsBtnSave.Enabled = false;

			//    return;
			//}

			//const string strFilter = "AnimeTrim Files|*.xat";
			//SaveFileDialog sfd = new SaveFileDialog();
			//sfd.Filter = strFilter;

			//if (sfd.ShowDialog() == DialogResult.OK)
			//{
			//    _ai.Path = sfd.FileName;
			//    _ai.Name = Path.GetFileName(_ai.Path);
			//    _ai.IsNew = false;
			//    _ai.IsSaved = true;

			//    UpdateAnimeDoc();
			//    this.tsBtnSave.Enabled = false;
			//}
			SaveData();
			// edit fin
		}

		private void tsBtnAdd_Click(object sender, EventArgs e)
		{
			AddForm af = new AddForm();
			af.FormClosed += new FormClosedEventHandler(this.AddForm_FormClosed);
			af.Show();

			//if (af.ShowDialog(this) == DialogResult.OK)
			//{
			//	Anime a = af.GetAnime();
			//	a.ID = _ai.Uid++;
			//	_ai.Space += a.Size;
			//	_ai.Total++;
			//	_ai.IsSaved = false;
			//	_lani.Add(a);
			//	//_lani.Sort(AnimeComparer);

			//	this.folvAnime.AddObject(a);
			//	//this.folvAnime.Sort(0);
			//	//this.folvAnime.Unsort();

			//	this.folvAnime.SelectedObject = a;
			//	this.folvAnime.SelectedItem.EnsureVisible();
			//	// TODO: 需修正工具栏
			//	//this.folvAnime.Focus();
			//	this.tsslTotal.Text = String.Format("Total: {0}", _ai.Total);
			//	this.tsslSpace.Text = String.Format("Total Size: {0:#,##0.#0} GB", _ai.Space / 1073741824D);
			//	this.tsBtnSave.Enabled = true;
			//}
		}

		private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			AddForm af = sender as AddForm;

			if (af != null && af.DialogResult == DialogResult.OK)
			{
				Anime a = af.GetAnime();
				a.ID = _ai.Uid++;
				_ai.Space += a.Size;
				_ai.Total++;
				_ai.IsSaved = false;
				//_lani.Add(a);

				this.folvAnime.AddObject(a);
				this.folvAnime.SelectedObject = a;
				this.folvAnime.SelectedItem.EnsureVisible();

				this.tsslTotal.Text = String.Format("Total: {0}", _ai.Total);
				this.tsslSpace.Text = String.Format("Total Size: {0:#,##0.#0} GB", _ai.Space / 1073741824D);
			}
		}

		private void tsBtnModify_Click(object sender, EventArgs e)
		{
			Anime a = this.folvAnime.SelectedObject as Anime;

			if (a == null)
				return;

			//long ls = a.Size;
			ModForm mf = new ModForm(a);
			mf.FormClosed += new FormClosedEventHandler(this.ModForm_FormClosed);
			mf.Show();

			//if (mf.ShowDialog(this) == DialogResult.OK)
			//{
			//	_ai.Space -= ls;
			//	//a.EditCopy(mf.GetAnime());
			//	_ai.Space += a.Size;
			//	_ai.IsSaved = false;

			//	this.folvAnime_SelectionChanged(null, null);
			//	this.folvAnime.RefreshItem(this.folvAnime.SelectedItem);
			//	// TODO: 需修正工具栏
			//	//this.folvAnime.Focus();
			//	this.tsslSpace.Text = String.Format("Total Size: {0:#,##0.#0} GB", _ai.Space / 1073741824D);
			//	this.tsBtnSave.Enabled = true;
			//}
		}

		private void ModForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			ModForm mf = sender as ModForm;

			if (mf != null && mf.DialogResult == DialogResult.OK)
			{
				_ai.Space += mf.GetDiffSize();
				_ai.IsSaved = false;

				this.folvAnime_SelectionChanged(null, null);
				this.folvAnime.RefreshItem(this.folvAnime.ModelToItem(mf.GetAnime()));

				this.tsslSpace.Text = String.Format("Total Size: {0:#,##0.#0} GB", _ai.Space / 1073741824D);
			}
		}

		#region Copy + Paste = Duplicate
		//private Anime _aCopy;

		//private void btnCopy_Click(object sender, EventArgs e)
		//{
		//	Anime a = this.folvAnime.SelectedObject as Anime;

		//	if (a == null)
		//		return;
		//	else
		//	{
		//		_aCopy = new Anime(a, _ai.Uid++);
		//		this.btnPaste.Enabled = true;
		//	}
		//}

		//private void btnPaste_Click(object sender, EventArgs e)
		//{
		//	_ai.Size += _aCopy.Size;
		//	_ai.Total++;
		//	_ai.IsSaved = false;
		//	_lani.Add(_aCopy);

		//	this.folvAnime.AddObject(_aCopy);
		//	this.folvAnime.SelectedObject = _aCopy;
		//	this.folvAnime.SelectedItem.EnsureVisible();

		//	this.folvAnime.Focus();
		//	this.tsslTotal.Text = String.Format("Total: {0}", _ai.Total);
		//	this.tsslSpace.Text = String.Format("Total Size: {0:#,##0.#0} GB", _ai.Size / 1073741824D);
		//	this.tsBtnSave.Enabled = true;
		//}
		#endregion

		private void tsBtnDuplicate_Click(object sender, EventArgs e)
		{
			if (this.folvAnime.SelectedIndices.Count == 0)
				return;

			if (relani.Count != 0)
				relani.Clear();

			reists = 0;

			foreach (Anime a in this.folvAnime.SelectedObjects)
			{
				Anime aCopy = new Anime(a, _ai.Uid++);
				_ai.Space += aCopy.Size;
				_ai.Total++;
				//_lani.Add(aCopy);
				relani.Add(aCopy);

				this.folvAnime.AddObject(aCopy);
			}

			_ai.IsSaved = false;

			this.tsslTotal.Text = String.Format("Total: {0}", _ai.Total);
			this.tsslSpace.Text = String.Format("Total Size: {0:#,##0.#0} GB", _ai.Space / 1073741824D);
			this.tsBtnUndo.Enabled = true;
		}

		private void tsBtnDel_Click(object sender, EventArgs e)
		{
			if (this.folvAnime.SelectedIndices.Count == 0)
				return;

			int isel = this.folvAnime.SelectedIndices[0];

			if (relani.Count != 0)
				relani.Clear();

			reists = 1;

			foreach (Anime a in this.folvAnime.SelectedObjects)
			{
				_ai.Space -= a.Size;
				_ai.Total--;

				//_lani.Remove(a);
				relani.Add(a);
			}

			this.folvAnime.RemoveObjects(this.folvAnime.SelectedObjects);

			this.folvAnime.SelectedIndex = isel < this.folvAnime.Items.Count ? isel : isel - 1;
			this.folvAnime.SelectedItem.EnsureVisible();

			_ai.IsSaved = false;

			// TODO: 需修正工具栏
			//this.folvAnime.Focus();
			this.tsslTotal.Text = String.Format("Total: {0}", _ai.Total);
			this.tsslSpace.Text = String.Format("Total Size: {0:#,##0.#0} GB", _ai.Space / 1073741824D);
			this.tsBtnUndo.Enabled = true;
		}

		private void tsBtnRefresh_Click(object sender, EventArgs e)
		{
			if (!AnimeInfo.IsStorageReady())
				return;

			long lSize = 0L;
			long lSelSize = 0L;
			long lSpace = _ai.Space;
			bool bCheck = false;

			foreach (Anime a in this.folvAnime.SelectedObjects)
			{
				if (a.Path.Length == 0)
					continue;

				lSize = Anime.GetSize(a.Path);
				if (a.Size != lSize)
				{
					bCheck = true;

					lSpace += lSize - a.Size;
					a.Size = lSize;
					this.folvAnime.RefreshItem(this.folvAnime.ModelToItem(a));
				}
				lSelSize += a.Size;
			}

			if (bCheck)
				_ai.IsSaved = false;

			if (lSpace != _ai.Space)
			{
				_ai.Space = lSpace;

				this.tsslSelSpace.Text = (lSelSize == 0L) ? "Selected Size: -" :
					(lSelSize >= 1000000000L) ? String.Format("Selected Size: {0:#,##0.#0} GB", lSelSize / 1073741824D) :
					String.Format("Selected Size: {0:#,##0.#0} MB", lSelSize / 1048576D);
				this.tsslSpace.Text = String.Format("Total Size: {0:#,##0.#0} GB", _ai.Space / 1073741824D);
			}
		}

		private void folvAnime_IsHyperlink(object sender, IsHyperlinkEventArgs e)
		{
			e.Url = e.Text;
		}

		private void folvAnime_CellEditFinishing(object sender, CellEditEventArgs e)
		{
			// edit 13/1/7 for bug1
			if (e.Value.ToString() == e.NewValue.ToString())
				return;

			Anime a = e.RowObject as Anime;

			a.UpdateTime = DateTime.Now;

			this.rtbAnime.Text = a.Remark;
			// edit fin

			_ai.IsSaved = false;

			this.tsslSelected.Text = String.Format("Selected: {0}", a.Name);
		}

		private void folvAnime_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
		{
			if (e.Column == null || e.Column != this.olvColPath)
				return;

			e.AutoPopDelay = 8000;
			e.Text = ((Anime)e.Model).Preview;
		}

		private void AnimeForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			XmlWriterSettings xwSet = new XmlWriterSettings();
			xwSet.Indent = true;
			xwSet.IndentChars = "\t";

			XmlWriter xWriter = XmlWriter.Create(xmlpath, xwSet);
			xWriter.WriteStartElement(assemname);
			xWriter.WriteStartElement("Settings");
			xWriter.WriteElementString("LastAccessName", _ai.Name);
			xWriter.WriteElementString("LastAccessPath", _ai.Path);
			xWriter.WriteEndElement();
			xWriter.WriteEndElement();
			xWriter.Flush();
			xWriter.Close();
		}

		private void AnimeForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// edit 13/1/9 for bug3
			//if (!_ai.IsSaved)
			//{
			//    DialogResult dr;
			//    dr = MessageBox.Show(this, "Save current Anime?", "Save",
			//        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

			//    if (dr == DialogResult.Yes)
			//        tsBtnSave_Click(null, null);
			//    else if (dr == DialogResult.Cancel)
			//        e.Cancel = true;
			//}
			if (!SaveCheck())
				e.Cancel = true;
			// edit fin
		}

		#region key event
		//private void AnimeForm_KeyDown(object sender, KeyEventArgs e)
		//{
		//	if (e.Control)
		//	{
		//		e.Handled = true;

		//		switch (e.KeyCode)
		//		{
		//			case Keys.S:
		//				this.tsBtnSave.PerformClick();
		//				break;
		//			case Keys.Add:
		//				this.tsBtnAdd.PerformClick();
		//				break;
		//			case Keys.E:
		//				this.tsBtnModify.PerformClick();
		//				break;
		//			case Keys.D:
		//				this.tsBtnDuplicate.PerformClick();
		//				break;
		//			case Keys.F:
		//				//this.tbFilter.Focus();
		//				this.tsBtnSearch.PerformClick();
		//				break;

		//			default:
		//				return;
		//		}
		//	}
		//}
		#endregion

		protected override bool ProcessDialogKey(Keys keyData)
		{
			switch (keyData)
			{
				case (Keys.S | Keys.Control):
					this.tsBtnSave_Click(null, null);
					return true;

				case (Keys.I | Keys.Control):
					this.tsBtnAdd_Click(null, null);
					return true;

				case (Keys.E | Keys.Control):
					this.tsBtnModify_Click(null, null);
					return true;

				case (Keys.D | Keys.Control):
					this.tsBtnDuplicate_Click(null, null);
					return true;

				case (Keys.F | Keys.Control):
					this.tsBtnSearch_Click(null, null);
					return true;

				default:
					return base.ProcessDialogKey(keyData);
			}
		}

		private void FindForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			findfm.FormClosed -= FindForm_FormClosed;
			findfm = null;
		}

		private void tsMenItmBackup_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(_ai.Path))
				return;

			StreamWriter sw = new StreamWriter(_ai.Path + ".bak", false, Encoding.Unicode);

			sw.WriteLine("{0}\t{1}\t{2}", _ai.Total, _ai.Space, _ai.Uid);

			//_lani.ForEach(delegate(Anime a)
			//{
			//    sw.WriteLine(_sout,
			//        a.ID, a.Title, a.Name, a.Year, a.Season, a.Type, a.Format,
			//        a.SubTeam, a.SubStyle, a.Path, a.Size, a.Store,
			//        a.Enjoy, a.Grade, a.CreateTime, a.UpdateTime, a.Kana,
			//        a.Episode, a.Inc, a.Note);
			//});
			foreach (Anime a in this.folvAnime.Objects)
				sw.WriteLine(_sout,
					a.ID, a.Title, a.Name, a.Year, a.Season, a.Type, a.Format,
					a.SubTeam, a.SubStyle, a.Path, a.Size, a.Store,
					a.Enjoy, a.Grade, a.CreateTime, a.UpdateTime, a.Kana,
					a.Episode, a.Inc, a.Note);

			sw.Close();
		}

		private void tsMenItmFormat_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = formatfilter;

			#region format
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				StreamReader sr = new StreamReader(ofd.FileName);

				int iTotal;
				if (!Int32.TryParse(sr.ReadLine(), out iTotal))
				{
					// error
					sr.Close();

					return;
				}

				long lSize;
				double dSize;
				if (!Double.TryParse(sr.ReadLine(), out dSize))
				{
					// error
					sr.Close();

					return;
				}
				else lSize = (Int64)(dSize * 1024D * 1024D * 1024D + 0.5D);

				List<Anime> lAni = new List<Anime>();
				Anime ani;
				string line;
				string[] info;
				string[] date;
				uint uc = 1;

				try
				{
					while (!String.IsNullOrEmpty(line = sr.ReadLine()))
					{
						info = line.Split('\t');

						ani = new Anime(uc++);
						ani.Title = info[0];
						ani.Name = info[1];

						date = info[2].Split('.');
						ani.Year = UInt32.Parse(date[0]);
						ani.Season = (PlaySeason)Enum.Parse(typeof(PlaySeason), date[1]);

						switch (info[3])
						{
							case "BDRip":
							default:
								ani.Type = MediaType.BDRip; break;
							case "DVDRip": ani.Type = MediaType.DVDRip; break;
							case "BDRAW": ani.Type = MediaType.BDRAW; break;
							case "DVDRAW": ani.Type = MediaType.DVDRAW; break;
							case "BDMV": ani.Type = MediaType.BDMV; break;
							case "TVRip": ani.Type = MediaType.TVRip; break;
						}

						switch (info[4])
						{
							case "MKV":
							default:
								ani.Format = MergeFormat.MKV; break;
							case "MP4": ani.Format = MergeFormat.MP4; break;
							case "M2TS": ani.Format = MergeFormat.M2TS; break;
							case "WMV": ani.Format = MergeFormat.WMV; break;
							case "AVI": ani.Format = MergeFormat.AVI; break;
						}

						ani.SubTeam = info[5];

						switch (info[6])
						{
							case "External":
							default:
								ani.SubStyle = SubStyles.External; break;
							case "Sealed": ani.SubStyle = SubStyles.Sealed; break;
							case "Embedded": ani.SubStyle = SubStyles.Embedded; break;
						}

						ani.Path = info[7];

						ani.Size = (Int64)(Double.Parse(info[8]) * 1073741824D + 0.5D);

						ani.Store = (info[9] == "Fin.") ? true : false;

						ani.Enjoy = (info[10] == "^-^") ? true : false;

						ani.Grade = 1;

						ani.CreateTime = DateTime.Now;

						ani.UpdateTime = DateTime.Now;

						ani.Kana = info[11];

						ani.Episode = String.Empty;

						ani.Inc = String.Empty;

						ani.Note = info[12];

						lAni.Add(ani);
					}
				}
				catch (Exception)
				{
					lAni.Clear();

					return;
				}
				finally
				{
					sr.Close();
				}

				StreamWriter sw = new StreamWriter(ofd.FileName.Remove(ofd.FileName.LastIndexOf('.')) + ".xat", false, Encoding.Unicode);
				sw.WriteLine("{0}\t{1}\t{2}", iTotal, lSize, uc);

				lAni.ForEach(delegate(Anime a)
				{
					sw.WriteLine(_sout,
					a.ID, a.Title, a.Name, a.Year, a.Season, a.Type, a.Format,
					a.SubTeam, a.SubStyle, a.Path, a.Size, a.Store,
					a.Enjoy, a.Grade, a.CreateTime, a.UpdateTime, a.Kana,
					a.Episode, a.Inc, a.Note);
				});

				sw.Close();
			}
			#endregion
		}

		//private void tsBtnGroupClick(object sender, EventArgs e)
		//{
		//	if (ObjectListView.IsVistaOrLater)
		//	{
		//		this.folvAnime.ShowGroups = !this.folvAnime.ShowGroups;
		//		this.folvAnime.BuildList();
		//	}
		//}

		//private void tsBtnOverlayClick(object sender, EventArgs e)
		//{
		//	this.folvAnime.UseOverlays = !this.folvAnime.UseOverlays;
		//	this.folvAnime.HotItemStyle = this.folvAnime.HotItemStyle;
		//}

		private void tssBtnMoreDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			this.tssBtnMore.DefaultItem = e.ClickedItem;
			this.tssBtnMore.Text = e.ClickedItem.Text;
			this.tssBtnMore.ToolTipText = e.ClickedItem.ToolTipText;
			this.tssBtnMore.Image = e.ClickedItem.Image;
		}

		private void tsBtnUndo_Click(object sender, EventArgs e)
		{
			if (reists == -1 || relani.Count == 0)
				return;

			// restore duplicated
			if (reists == 0)
			{
				foreach (Anime a in relani)
				{
					_ai.Space -= a.Size;
					_ai.Total--;
				}

				this.folvAnime.RemoveObjects(relani);
			}
			else if (reists == 1)
			{
				foreach (Anime a in relani)
				{
					_ai.Space += a.Size;
					_ai.Total++;
				}

				this.folvAnime.AddObjects(relani);

				this.folvAnime.SelectedObject = relani[0];
				this.folvAnime.SelectedItem.EnsureVisible();
				this.folvAnime.SelectedObjects = relani;
			}

			_ai.IsSaved = false;
			reists = -1;
			relani.Clear();

			this.tsslTotal.Text = String.Format("Total: {0}", _ai.Total);
			this.tsslSpace.Text = String.Format("Total Size: {0:#,##0.#0} GB", _ai.Space / 1073741824D);
			this.tsBtnUndo.Enabled = false;
		}

		private void tsBtnGroup_Click(object sender, EventArgs e)
		{
			if (ObjectListView.IsVistaOrLater)
			{
				this.folvAnime.ShowGroups = !this.folvAnime.ShowGroups;
				this.folvAnime.BuildList();
			}
		}

		private void tsBtnOverlay_Click(object sender, EventArgs e)
		{
			this.folvAnime.UseOverlays = !this.folvAnime.UseOverlays;
			this.folvAnime.HotItemStyle = this.folvAnime.HotItemStyle;
		}

		private void tsBtnSearch_Click(object sender, EventArgs e)
		{
			if (findfm != null)
				findfm.Focus();
			else
			{
				findfm = new FindForm(this.folvAnime);
				findfm.FormClosed += FindForm_FormClosed;
				findfm.Show(this);
			}
		}
	}
}
