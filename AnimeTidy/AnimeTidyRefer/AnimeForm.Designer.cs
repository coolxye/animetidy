namespace AnimeTidy
{
	partial class AnimeForm
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
			this.components = new System.ComponentModel.Container();
			this.tctlAnime = new System.Windows.Forms.TabControl();
			this.tpAnime = new System.Windows.Forms.TabPage();
			this.folvAnime = new AnimeTidyLib.ObjectListView();
			this.olvColTitle = new AnimeTidyLib.OLVColumn();
			this.olvColName = new AnimeTidyLib.OLVColumn();
			this.olvColSchedule = new AnimeTidyLib.OLVColumn();
			this.olvColType = new AnimeTidyLib.OLVColumn();
			this.olvColSubTeam = new AnimeTidyLib.OLVColumn();
			this.olvColPath = new AnimeTidyLib.OLVColumn();
			this.olvColSize = new AnimeTidyLib.OLVColumn();
			this.olvColStore = new AnimeTidyLib.OLVColumn();
			this.olvColEnjoy = new AnimeTidyLib.OLVColumn();
			this.olvColGrade = new AnimeTidyLib.OLVColumn();
			this.olvColNote = new AnimeTidyLib.OLVColumn();
			this.cmsAnime = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsSepForCms = new System.Windows.Forms.ToolStripSeparator();
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tpMusic = new System.Windows.Forms.TabPage();
			this.hiStyle = new AnimeTidyLib.HotItemStyle();
			this.rtbAnime = new System.Windows.Forms.RichTextBox();
			this.scAnime = new System.Windows.Forms.SplitContainer();
			this.ssAnime = new System.Windows.Forms.StatusStrip();
			this.tsslSelected = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslSelSpace = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslTotal = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslSpace = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsBtnNew = new System.Windows.Forms.ToolStripButton();
			this.tsBtnOpen = new System.Windows.Forms.ToolStripButton();
			this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
			this.tsSepForFile = new System.Windows.Forms.ToolStripSeparator();
			this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
			this.tsBtnModify = new System.Windows.Forms.ToolStripButton();
			this.tsBtnDuplicate = new System.Windows.Forms.ToolStripButton();
			this.tsBtnDel = new System.Windows.Forms.ToolStripButton();
			this.tsBtnUndo = new System.Windows.Forms.ToolStripButton();
			this.tsSepForEdit = new System.Windows.Forms.ToolStripSeparator();
			this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.tsSepForSpecial = new System.Windows.Forms.ToolStripSeparator();
			this.tsBtnSearch = new System.Windows.Forms.ToolStripButton();
			this.tsBtnGroup = new System.Windows.Forms.ToolStripButton();
			this.tsBtnOverlay = new System.Windows.Forms.ToolStripButton();
			this.tsSepForSwitch = new System.Windows.Forms.ToolStripSeparator();
			this.tssBtnMore = new System.Windows.Forms.ToolStripSplitButton();
			this.tsMenItmFormat = new System.Windows.Forms.ToolStripMenuItem();
			this.tsMenItmBackup = new System.Windows.Forms.ToolStripMenuItem();
			this.tctlAnime.SuspendLayout();
			this.tpAnime.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.folvAnime)).BeginInit();
			this.cmsAnime.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scAnime)).BeginInit();
			this.scAnime.Panel1.SuspendLayout();
			this.scAnime.Panel2.SuspendLayout();
			this.scAnime.SuspendLayout();
			this.ssAnime.SuspendLayout();
			this.tsMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tctlAnime
			// 
			this.tctlAnime.Controls.Add(this.tpAnime);
			this.tctlAnime.Controls.Add(this.tpMusic);
			this.tctlAnime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tctlAnime.Location = new System.Drawing.Point(0, 0);
			this.tctlAnime.Name = "tctlAnime";
			this.tctlAnime.SelectedIndex = 0;
			this.tctlAnime.ShowToolTips = true;
			this.tctlAnime.Size = new System.Drawing.Size(920, 377);
			this.tctlAnime.TabIndex = 0;
			// 
			// tpAnime
			// 
			this.tpAnime.Controls.Add(this.folvAnime);
			this.tpAnime.Location = new System.Drawing.Point(4, 22);
			this.tpAnime.Name = "tpAnime";
			this.tpAnime.Padding = new System.Windows.Forms.Padding(3);
			this.tpAnime.Size = new System.Drawing.Size(912, 351);
			this.tpAnime.TabIndex = 0;
			this.tpAnime.Text = "Anime";
			this.tpAnime.UseVisualStyleBackColor = true;
			// 
			// folvAnime
			// 
			this.folvAnime.AllColumns.Add(this.olvColTitle);
			this.folvAnime.AllColumns.Add(this.olvColName);
			this.folvAnime.AllColumns.Add(this.olvColSchedule);
			this.folvAnime.AllColumns.Add(this.olvColType);
			this.folvAnime.AllColumns.Add(this.olvColSubTeam);
			this.folvAnime.AllColumns.Add(this.olvColPath);
			this.folvAnime.AllColumns.Add(this.olvColSize);
			this.folvAnime.AllColumns.Add(this.olvColStore);
			this.folvAnime.AllColumns.Add(this.olvColEnjoy);
			this.folvAnime.AllColumns.Add(this.olvColGrade);
			this.folvAnime.AllColumns.Add(this.olvColNote);
			this.folvAnime.AllowColumnReorder = true;
			this.folvAnime.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.folvAnime.CellEditActivation = AnimeTidyLib.ObjectListView.CellEditActivateMode.DoubleClick;
			this.folvAnime.CellEditUseWholeCell = false;
			this.folvAnime.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColTitle,
            this.olvColName,
            this.olvColSchedule,
            this.olvColType,
            this.olvColSubTeam,
            this.olvColPath,
            this.olvColSize,
            this.olvColStore,
            this.olvColEnjoy,
            this.olvColGrade,
            this.olvColNote});
			this.folvAnime.ContextMenuStrip = this.cmsAnime;
			this.folvAnime.Cursor = System.Windows.Forms.Cursors.Default;
			this.folvAnime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.folvAnime.EmptyListMsg = "アニメがない...";
			this.folvAnime.FullRowSelect = true;
			this.folvAnime.GroupWithItemCountSingularFormat = "{0} [{1} items]";
			this.folvAnime.HideSelection = false;
			this.folvAnime.Location = new System.Drawing.Point(3, 3);
			this.folvAnime.Name = "folvAnime";
			this.folvAnime.ShowCommandMenuOnRightClick = true;
			this.folvAnime.ShowGroups = false;
			this.folvAnime.ShowItemCountOnGroups = true;
			this.folvAnime.ShowItemToolTips = true;
			this.folvAnime.Size = new System.Drawing.Size(906, 345);
			this.folvAnime.TabIndex = 0;
			this.folvAnime.UseAlternatingBackColors = true;
			this.folvAnime.UseCompatibleStateImageBehavior = false;
			this.folvAnime.UseFiltering = true;
			this.folvAnime.UseHotItem = true;
			this.folvAnime.UseHyperlinks = true;
			this.folvAnime.View = System.Windows.Forms.View.Details;
			this.folvAnime.CellEditFinishing += new AnimeTidyLib.CellEditEventHandler(this.folvAnime_CellEditFinishing);
			this.folvAnime.CellToolTipShowing += new System.EventHandler<AnimeTidyLib.ToolTipShowingEventArgs>(this.folvAnime_CellToolTipShowing);
			this.folvAnime.IsHyperlink += new System.EventHandler<AnimeTidyLib.IsHyperlinkEventArgs>(this.folvAnime_IsHyperlink);
			this.folvAnime.SelectionChanged += new System.EventHandler(this.folvAnime_SelectionChanged);
			// 
			// olvColTitle
			// 
			this.olvColTitle.AspectName = "Title";
			this.olvColTitle.MinimumWidth = 130;
			this.olvColTitle.Text = "Title";
			this.olvColTitle.UseInitialLetterForGroup = true;
			this.olvColTitle.Width = 130;
			// 
			// olvColName
			// 
			this.olvColName.AspectName = "Name";
			this.olvColName.MinimumWidth = 120;
			this.olvColName.Text = "Name";
			this.olvColName.UseInitialLetterForGroup = true;
			this.olvColName.Width = 120;
			// 
			// olvColSchedule
			// 
			this.olvColSchedule.AspectName = "Schedule";
			this.olvColSchedule.IsEditable = false;
			this.olvColSchedule.MinimumWidth = 80;
			this.olvColSchedule.Text = "Schedule";
			this.olvColSchedule.Width = 80;
			// 
			// olvColType
			// 
			this.olvColType.AspectName = "Type";
			this.olvColType.MinimumWidth = 72;
			this.olvColType.Text = "Type";
			this.olvColType.Width = 72;
			// 
			// olvColSubTeam
			// 
			this.olvColSubTeam.AspectName = "SubTeam";
			this.olvColSubTeam.MinimumWidth = 100;
			this.olvColSubTeam.Text = "Subtitle";
			this.olvColSubTeam.Width = 100;
			// 
			// olvColPath
			// 
			this.olvColPath.AspectName = "Path";
			this.olvColPath.Hyperlink = true;
			this.olvColPath.IsEditable = false;
			this.olvColPath.MinimumWidth = 100;
			this.olvColPath.Text = "Path";
			this.olvColPath.Width = 120;
			// 
			// olvColSize
			// 
			this.olvColSize.AspectName = "Size";
			this.olvColSize.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.olvColSize.IsEditable = false;
			this.olvColSize.MinimumWidth = 60;
			this.olvColSize.Text = "Size";
			this.olvColSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// olvColStore
			// 
			this.olvColStore.AspectName = "Store";
			this.olvColStore.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.olvColStore.MinimumWidth = 45;
			this.olvColStore.Text = "Store";
			this.olvColStore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.olvColStore.Width = 45;
			// 
			// olvColEnjoy
			// 
			this.olvColEnjoy.AspectName = "Enjoy";
			this.olvColEnjoy.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.olvColEnjoy.MinimumWidth = 45;
			this.olvColEnjoy.Text = "Enjoy";
			this.olvColEnjoy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.olvColEnjoy.Width = 45;
			// 
			// olvColGrade
			// 
			this.olvColGrade.AspectName = "Grade";
			this.olvColGrade.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.olvColGrade.MinimumWidth = 60;
			this.olvColGrade.Text = "Grade";
			this.olvColGrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// olvColNote
			// 
			this.olvColNote.AspectName = "Note";
			this.olvColNote.IsEditable = false;
			this.olvColNote.MinimumWidth = 200;
			this.olvColNote.Text = "Note";
			this.olvColNote.Width = 200;
			// 
			// cmsAnime
			// 
			this.cmsAnime.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.modifyToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.tsSepForCms,
            this.refreshToolStripMenuItem});
			this.cmsAnime.Name = "ctxtMnSpAnime";
			this.cmsAnime.Size = new System.Drawing.Size(148, 120);
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.addToolStripMenuItem.Text = "Add(I)";
			this.addToolStripMenuItem.Click += new System.EventHandler(this.tsBtnAdd_Click);
			// 
			// modifyToolStripMenuItem
			// 
			this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
			this.modifyToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.modifyToolStripMenuItem.Text = "Modify(E)";
			this.modifyToolStripMenuItem.Click += new System.EventHandler(this.tsBtnModify_Click);
			// 
			// duplicateToolStripMenuItem
			// 
			this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
			this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.duplicateToolStripMenuItem.Text = "Duplicate(D)";
			this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.tsBtnDuplicate_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.tsBtnDel_Click);
			// 
			// tsSepForCms
			// 
			this.tsSepForCms.Name = "tsSepForCms";
			this.tsSepForCms.Size = new System.Drawing.Size(144, 6);
			// 
			// refreshToolStripMenuItem
			// 
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.refreshToolStripMenuItem.Text = "Refresh";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(this.tsBtnRefresh_Click);
			// 
			// tpMusic
			// 
			this.tpMusic.Location = new System.Drawing.Point(4, 22);
			this.tpMusic.Name = "tpMusic";
			this.tpMusic.Padding = new System.Windows.Forms.Padding(3);
			this.tpMusic.Size = new System.Drawing.Size(912, 351);
			this.tpMusic.TabIndex = 1;
			this.tpMusic.Text = "Music";
			this.tpMusic.UseVisualStyleBackColor = true;
			// 
			// hiStyle
			// 
			this.hiStyle.BackColor = System.Drawing.Color.PeachPuff;
			this.hiStyle.ForeColor = System.Drawing.Color.MediumBlue;
			// 
			// rtbAnime
			// 
			this.rtbAnime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbAnime.Location = new System.Drawing.Point(0, 0);
			this.rtbAnime.Name = "rtbAnime";
			this.rtbAnime.ReadOnly = true;
			this.rtbAnime.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.rtbAnime.Size = new System.Drawing.Size(920, 63);
			this.rtbAnime.TabIndex = 0;
			this.rtbAnime.Text = "";
			// 
			// scAnime
			// 
			this.scAnime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.scAnime.Location = new System.Drawing.Point(12, 28);
			this.scAnime.Name = "scAnime";
			this.scAnime.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// scAnime.Panel1
			// 
			this.scAnime.Panel1.Controls.Add(this.tctlAnime);
			// 
			// scAnime.Panel2
			// 
			this.scAnime.Panel2.Controls.Add(this.rtbAnime);
			this.scAnime.Size = new System.Drawing.Size(920, 444);
			this.scAnime.SplitterDistance = 377;
			this.scAnime.TabIndex = 2;
			// 
			// ssAnime
			// 
			this.ssAnime.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslSelected,
            this.tsslSelSpace,
            this.tsslTotal,
            this.tsslSpace});
			this.ssAnime.Location = new System.Drawing.Point(0, 475);
			this.ssAnime.Name = "ssAnime";
			this.ssAnime.Size = new System.Drawing.Size(944, 26);
			this.ssAnime.TabIndex = 3;
			// 
			// tsslSelected
			// 
			this.tsslSelected.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsslSelected.Name = "tsslSelected";
			this.tsslSelected.Size = new System.Drawing.Size(405, 21);
			this.tsslSelected.Spring = true;
			this.tsslSelected.Text = "Selected: ";
			// 
			// tsslSelSpace
			// 
			this.tsslSelSpace.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsslSelSpace.Name = "tsslSelSpace";
			this.tsslSelSpace.Size = new System.Drawing.Size(405, 21);
			this.tsslSelSpace.Spring = true;
			this.tsslSelSpace.Text = "Selected Size: ";
			// 
			// tsslTotal
			// 
			this.tsslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.tsslTotal.Name = "tsslTotal";
			this.tsslTotal.Size = new System.Drawing.Size(48, 21);
			this.tsslTotal.Text = "Total: ";
			// 
			// tsslSpace
			// 
			this.tsslSpace.Name = "tsslSpace";
			this.tsslSpace.Size = new System.Drawing.Size(71, 21);
			this.tsslSpace.Text = "Total Size: ";
			// 
			// tsMain
			// 
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnNew,
            this.tsBtnOpen,
            this.tsBtnSave,
            this.tsSepForFile,
            this.tsBtnAdd,
            this.tsBtnModify,
            this.tsBtnDuplicate,
            this.tsBtnDel,
            this.tsBtnUndo,
            this.tsSepForEdit,
            this.tsBtnRefresh,
            this.tsSepForSpecial,
            this.tsBtnSearch,
            this.tsBtnGroup,
            this.tsBtnOverlay,
            this.tsSepForSwitch,
            this.tssBtnMore});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(944, 25);
			this.tsMain.TabIndex = 1;
			this.tsMain.Text = "tsMain";
			// 
			// tsBtnNew
			// 
			this.tsBtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBtnNew.Image = global::AnimeTidy.Properties.Resources.file_new;
			this.tsBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnNew.Name = "tsBtnNew";
			this.tsBtnNew.Size = new System.Drawing.Size(23, 22);
			this.tsBtnNew.Text = "New";
			this.tsBtnNew.Click += new System.EventHandler(this.tsBtnNew_Click);
			// 
			// tsBtnOpen
			// 
			this.tsBtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBtnOpen.Image = global::AnimeTidy.Properties.Resources.open;
			this.tsBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnOpen.Name = "tsBtnOpen";
			this.tsBtnOpen.Size = new System.Drawing.Size(23, 22);
			this.tsBtnOpen.Text = "Open";
			this.tsBtnOpen.Click += new System.EventHandler(this.tsBtnOpen_Click);
			// 
			// tsBtnSave
			// 
			this.tsBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBtnSave.Image = global::AnimeTidy.Properties.Resources.save;
			this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnSave.Name = "tsBtnSave";
			this.tsBtnSave.Size = new System.Drawing.Size(23, 22);
			this.tsBtnSave.Text = "Save";
			this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
			// 
			// tsSepForFile
			// 
			this.tsSepForFile.Name = "tsSepForFile";
			this.tsSepForFile.Size = new System.Drawing.Size(6, 25);
			// 
			// tsBtnAdd
			// 
			this.tsBtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBtnAdd.Image = global::AnimeTidy.Properties.Resources.add;
			this.tsBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnAdd.Name = "tsBtnAdd";
			this.tsBtnAdd.Size = new System.Drawing.Size(23, 22);
			this.tsBtnAdd.Text = "Add(I)";
			this.tsBtnAdd.Click += new System.EventHandler(this.tsBtnAdd_Click);
			// 
			// tsBtnModify
			// 
			this.tsBtnModify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBtnModify.Image = global::AnimeTidy.Properties.Resources.edit;
			this.tsBtnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnModify.Name = "tsBtnModify";
			this.tsBtnModify.Size = new System.Drawing.Size(23, 22);
			this.tsBtnModify.Text = "Modify(E)";
			this.tsBtnModify.Click += new System.EventHandler(this.tsBtnModify_Click);
			// 
			// tsBtnDuplicate
			// 
			this.tsBtnDuplicate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBtnDuplicate.Image = global::AnimeTidy.Properties.Resources.duplicate;
			this.tsBtnDuplicate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnDuplicate.Name = "tsBtnDuplicate";
			this.tsBtnDuplicate.Size = new System.Drawing.Size(23, 22);
			this.tsBtnDuplicate.Text = "Duplicate(D)";
			this.tsBtnDuplicate.Click += new System.EventHandler(this.tsBtnDuplicate_Click);
			// 
			// tsBtnDel
			// 
			this.tsBtnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBtnDel.Image = global::AnimeTidy.Properties.Resources.del;
			this.tsBtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnDel.Name = "tsBtnDel";
			this.tsBtnDel.Size = new System.Drawing.Size(23, 22);
			this.tsBtnDel.Text = "Delete";
			this.tsBtnDel.Click += new System.EventHandler(this.tsBtnDel_Click);
			// 
			// tsBtnUndo
			// 
			this.tsBtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBtnUndo.Image = global::AnimeTidy.Properties.Resources.undo;
			this.tsBtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnUndo.Name = "tsBtnUndo";
			this.tsBtnUndo.Size = new System.Drawing.Size(23, 22);
			this.tsBtnUndo.Text = "Undo";
			this.tsBtnUndo.Click += new System.EventHandler(this.tsBtnUndo_Click);
			// 
			// tsSepForEdit
			// 
			this.tsSepForEdit.Name = "tsSepForEdit";
			this.tsSepForEdit.Size = new System.Drawing.Size(6, 25);
			// 
			// tsBtnRefresh
			// 
			this.tsBtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBtnRefresh.Image = global::AnimeTidy.Properties.Resources.refresh;
			this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnRefresh.Name = "tsBtnRefresh";
			this.tsBtnRefresh.Size = new System.Drawing.Size(23, 22);
			this.tsBtnRefresh.Text = "Refresh";
			this.tsBtnRefresh.Click += new System.EventHandler(this.tsBtnRefresh_Click);
			// 
			// tsSepForSpecial
			// 
			this.tsSepForSpecial.Name = "tsSepForSpecial";
			this.tsSepForSpecial.Size = new System.Drawing.Size(6, 25);
			// 
			// tsBtnSearch
			// 
			this.tsBtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBtnSearch.Image = global::AnimeTidy.Properties.Resources.search;
			this.tsBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnSearch.Name = "tsBtnSearch";
			this.tsBtnSearch.Size = new System.Drawing.Size(23, 22);
			this.tsBtnSearch.Text = "Search";
			this.tsBtnSearch.Click += new System.EventHandler(this.tsBtnSearch_Click);
			// 
			// tsBtnGroup
			// 
			this.tsBtnGroup.CheckOnClick = true;
			this.tsBtnGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBtnGroup.Image = global::AnimeTidy.Properties.Resources.group;
			this.tsBtnGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnGroup.Name = "tsBtnGroup";
			this.tsBtnGroup.Size = new System.Drawing.Size(23, 22);
			this.tsBtnGroup.Text = "Group";
			this.tsBtnGroup.Click += new System.EventHandler(this.tsBtnGroup_Click);
			// 
			// tsBtnOverlay
			// 
			this.tsBtnOverlay.CheckOnClick = true;
			this.tsBtnOverlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBtnOverlay.Image = global::AnimeTidy.Properties.Resources.overlay;
			this.tsBtnOverlay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBtnOverlay.Name = "tsBtnOverlay";
			this.tsBtnOverlay.Size = new System.Drawing.Size(23, 22);
			this.tsBtnOverlay.Text = "Overlay";
			this.tsBtnOverlay.Click += new System.EventHandler(this.tsBtnOverlay_Click);
			// 
			// tsSepForSwitch
			// 
			this.tsSepForSwitch.Name = "tsSepForSwitch";
			this.tsSepForSwitch.Size = new System.Drawing.Size(6, 25);
			// 
			// tssBtnMore
			// 
			this.tssBtnMore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tssBtnMore.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenItmFormat,
            this.tsMenItmBackup});
			this.tssBtnMore.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tssBtnMore.Name = "tssBtnMore";
			this.tssBtnMore.Size = new System.Drawing.Size(16, 22);
			this.tssBtnMore.Text = "More";
			this.tssBtnMore.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tssBtnMoreDropDownItemClicked);
			// 
			// tsMenItmFormat
			// 
			this.tsMenItmFormat.Image = global::AnimeTidy.Properties.Resources.format;
			this.tsMenItmFormat.Name = "tsMenItmFormat";
			this.tsMenItmFormat.Size = new System.Drawing.Size(119, 22);
			this.tsMenItmFormat.Text = "Format";
			this.tsMenItmFormat.Click += new System.EventHandler(this.tsMenItmFormat_Click);
			// 
			// tsMenItmBackup
			// 
			this.tsMenItmBackup.Image = global::AnimeTidy.Properties.Resources.backup;
			this.tsMenItmBackup.Name = "tsMenItmBackup";
			this.tsMenItmBackup.Size = new System.Drawing.Size(119, 22);
			this.tsMenItmBackup.Text = "Backup";
			this.tsMenItmBackup.Click += new System.EventHandler(this.tsMenItmBackup_Click);
			// 
			// AnimeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(944, 501);
			this.Controls.Add(this.tsMain);
			this.Controls.Add(this.ssAnime);
			this.Controls.Add(this.scAnime);
			this.Name = "AnimeForm";
			this.Text = "AnimeTidy";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnimeForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AnimeForm_FormClosed);
			this.tctlAnime.ResumeLayout(false);
			this.tpAnime.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.folvAnime)).EndInit();
			this.cmsAnime.ResumeLayout(false);
			this.scAnime.Panel1.ResumeLayout(false);
			this.scAnime.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.scAnime)).EndInit();
			this.scAnime.ResumeLayout(false);
			this.ssAnime.ResumeLayout(false);
			this.ssAnime.PerformLayout();
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tctlAnime;
		private System.Windows.Forms.TabPage tpAnime;
		private System.Windows.Forms.TabPage tpMusic;
		private AnimeTidyLib.ObjectListView folvAnime;
		private AnimeTidyLib.OLVColumn olvColTitle;
		private AnimeTidyLib.OLVColumn olvColName;
		private AnimeTidyLib.OLVColumn olvColSchedule;
		private AnimeTidyLib.OLVColumn olvColType;
		private AnimeTidyLib.OLVColumn olvColSubTeam;
		private AnimeTidyLib.OLVColumn olvColPath;
		private AnimeTidyLib.OLVColumn olvColSize;
		private AnimeTidyLib.OLVColumn olvColStore;
		private AnimeTidyLib.OLVColumn olvColEnjoy;
		private AnimeTidyLib.OLVColumn olvColGrade;
		private AnimeTidyLib.OLVColumn olvColNote;
		private System.Windows.Forms.RichTextBox rtbAnime;
		private System.Windows.Forms.SplitContainer scAnime;
		private AnimeTidyLib.HotItemStyle hiStyle;
		private System.Windows.Forms.StatusStrip ssAnime;
		private System.Windows.Forms.ToolStripStatusLabel tsslSelected;
		private System.Windows.Forms.ToolStripStatusLabel tsslSelSpace;
		private System.Windows.Forms.ToolStripStatusLabel tsslTotal;
		private System.Windows.Forms.ToolStripStatusLabel tsslSpace;
		private System.Windows.Forms.ToolStrip tsMain;
		private System.Windows.Forms.ToolStripButton tsBtnNew;
		private System.Windows.Forms.ToolStripButton tsBtnOpen;
		private System.Windows.Forms.ToolStripButton tsBtnSave;
		private System.Windows.Forms.ToolStripSeparator tsSepForFile;
		private System.Windows.Forms.ToolStripButton tsBtnAdd;
		private System.Windows.Forms.ToolStripButton tsBtnModify;
		private System.Windows.Forms.ToolStripButton tsBtnDel;
		private System.Windows.Forms.ToolStripSeparator tsSepForEdit;
		private System.Windows.Forms.ToolStripSplitButton tssBtnMore;
		private System.Windows.Forms.ToolStripMenuItem tsMenItmFormat;
		private System.Windows.Forms.ToolStripMenuItem tsMenItmBackup;
		private System.Windows.Forms.ToolStripButton tsBtnDuplicate;
		private System.Windows.Forms.ToolStripButton tsBtnRefresh;
		private System.Windows.Forms.ToolStripSeparator tsSepForSpecial;
		private System.Windows.Forms.ContextMenuStrip cmsAnime;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator tsSepForCms;
		private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton tsBtnUndo;
		private System.Windows.Forms.ToolStripButton tsBtnSearch;
		private System.Windows.Forms.ToolStripButton tsBtnGroup;
		private System.Windows.Forms.ToolStripButton tsBtnOverlay;
		private System.Windows.Forms.ToolStripSeparator tsSepForSwitch;

	}
}

