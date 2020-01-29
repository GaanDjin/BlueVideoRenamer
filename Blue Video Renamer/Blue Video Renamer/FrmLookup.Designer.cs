namespace Blue_Video_Renamer
{
    partial class FrmLookup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLookup));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSeriesLookup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLookup = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRename = new System.Windows.Forms.Button();
            this.chkMakeMissingPlaceholder = new System.Windows.Forms.CheckBox();
            this.chkDeleteUnwantedFiles = new System.Windows.Forms.CheckBox();
            this.chkRenameAccompanyingFiles = new System.Windows.Forms.CheckBox();
            this.chkDeleteDups = new System.Windows.Forms.CheckBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.cboFormat = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblSeriesTitleLinked = new System.Windows.Forms.LinkLabel();
            this.picSeriesThumb = new System.Windows.Forms.PictureBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lstSeriesResults = new System.Windows.Forms.ListBox();
            this.tabRenamer = new System.Windows.Forms.TabPage();
            this.grdRenameData = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.txtRepeat = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.lstFileRenamer = new BrightIdeasSoftware.ObjectListView();
            this.colOrigFileName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colNewFileName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSeries = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSeason = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colEpisodeNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colEpisodeTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colYear = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colResolution = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colThumb = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colPath = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imgLstLarge = new System.Windows.Forms.ImageList(this.components);
            this.imgLstSmall = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSeriesThumb)).BeginInit();
            this.tabRenamer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRenameData)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstFileRenamer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSeriesLookup);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnLookup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1270, 29);
            this.panel1.TabIndex = 3;
            // 
            // txtSeriesLookup
            // 
            this.txtSeriesLookup.AcceptsReturn = true;
            this.txtSeriesLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSeriesLookup.Location = new System.Drawing.Point(52, 0);
            this.txtSeriesLookup.MaxLength = 255;
            this.txtSeriesLookup.Name = "txtSeriesLookup";
            this.txtSeriesLookup.Size = new System.Drawing.Size(1143, 22);
            this.txtSeriesLookup.TabIndex = 0;
            this.txtSeriesLookup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeriesLookup_KeyPress);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Series:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLookup
            // 
            this.btnLookup.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLookup.Location = new System.Drawing.Point(1195, 0);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(75, 29);
            this.btnLookup.TabIndex = 1;
            this.btnLookup.Text = "lookup";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRename);
            this.panel2.Controls.Add(this.chkMakeMissingPlaceholder);
            this.panel2.Controls.Add(this.chkDeleteUnwantedFiles);
            this.panel2.Controls.Add(this.chkRenameAccompanyingFiles);
            this.panel2.Controls.Add(this.chkDeleteDups);
            this.panel2.Controls.Add(this.lblFormat);
            this.panel2.Controls.Add(this.cboFormat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 347);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1256, 113);
            this.panel2.TabIndex = 5;
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(754, 16);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(127, 63);
            this.btnRename.TabIndex = 12;
            this.btnRename.Text = "Rename!";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // chkMakeMissingPlaceholder
            // 
            this.chkMakeMissingPlaceholder.AutoSize = true;
            this.chkMakeMissingPlaceholder.Location = new System.Drawing.Point(368, 31);
            this.chkMakeMissingPlaceholder.Name = "chkMakeMissingPlaceholder";
            this.chkMakeMissingPlaceholder.Size = new System.Drawing.Size(209, 21);
            this.chkMakeMissingPlaceholder.TabIndex = 11;
            this.chkMakeMissingPlaceholder.Text = "Create Missing Placeholders";
            this.chkMakeMissingPlaceholder.UseVisualStyleBackColor = true;
            this.chkMakeMissingPlaceholder.CheckedChanged += new System.EventHandler(this.chkMakeMissingPlaceholder_CheckedChanged);
            // 
            // chkDeleteUnwantedFiles
            // 
            this.chkDeleteUnwantedFiles.AutoSize = true;
            this.chkDeleteUnwantedFiles.Location = new System.Drawing.Point(74, 85);
            this.chkDeleteUnwantedFiles.Name = "chkDeleteUnwantedFiles";
            this.chkDeleteUnwantedFiles.Size = new System.Drawing.Size(171, 21);
            this.chkDeleteUnwantedFiles.TabIndex = 11;
            this.chkDeleteUnwantedFiles.Text = "Delete Unwanted Files";
            this.chkDeleteUnwantedFiles.UseVisualStyleBackColor = true;
            this.chkDeleteUnwantedFiles.CheckedChanged += new System.EventHandler(this.chkDeleteUnwantedFiles_CheckedChanged);
            // 
            // chkRenameAccompanyingFiles
            // 
            this.chkRenameAccompanyingFiles.AutoSize = true;
            this.chkRenameAccompanyingFiles.Location = new System.Drawing.Point(74, 58);
            this.chkRenameAccompanyingFiles.Name = "chkRenameAccompanyingFiles";
            this.chkRenameAccompanyingFiles.Size = new System.Drawing.Size(212, 21);
            this.chkRenameAccompanyingFiles.TabIndex = 11;
            this.chkRenameAccompanyingFiles.Text = "Rename Accompanying Files";
            this.chkRenameAccompanyingFiles.UseVisualStyleBackColor = true;
            this.chkRenameAccompanyingFiles.CheckedChanged += new System.EventHandler(this.chkRenameAccompanyingFiles_CheckedChanged);
            // 
            // chkDeleteDups
            // 
            this.chkDeleteDups.AutoSize = true;
            this.chkDeleteDups.Location = new System.Drawing.Point(74, 31);
            this.chkDeleteDups.Name = "chkDeleteDups";
            this.chkDeleteDups.Size = new System.Drawing.Size(141, 21);
            this.chkDeleteDups.TabIndex = 11;
            this.chkDeleteDups.Text = "Delete Duplicates";
            this.chkDeleteDups.UseVisualStyleBackColor = true;
            this.chkDeleteDups.CheckedChanged += new System.EventHandler(this.chkDeleteDups_CheckedChanged);
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(12, 6);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(56, 17);
            this.lblFormat.TabIndex = 1;
            this.lblFormat.Text = "Format:";
            // 
            // cboFormat
            // 
            this.cboFormat.FormattingEnabled = true;
            this.cboFormat.Location = new System.Drawing.Point(74, 3);
            this.cboFormat.Name = "cboFormat";
            this.cboFormat.Size = new System.Drawing.Size(324, 24);
            this.cboFormat.TabIndex = 10;
            this.cboFormat.SelectedIndexChanged += new System.EventHandler(this.cboFormat_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabResults);
            this.tabControl1.Controls.Add(this.tabRenamer);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1270, 492);
            this.tabControl1.TabIndex = 6;
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.btnSelect);
            this.tabResults.Controls.Add(this.lblSeriesTitleLinked);
            this.tabResults.Controls.Add(this.picSeriesThumb);
            this.tabResults.Controls.Add(this.lblSummary);
            this.tabResults.Controls.Add(this.lstSeriesResults);
            this.tabResults.Location = new System.Drawing.Point(4, 25);
            this.tabResults.Name = "tabResults";
            this.tabResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabResults.Size = new System.Drawing.Size(1262, 463);
            this.tabResults.TabIndex = 1;
            this.tabResults.Text = "Results";
            this.tabResults.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(322, 149);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 29);
            this.btnSelect.TabIndex = 7;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblSeriesTitleLinked
            // 
            this.lblSeriesTitleLinked.ActiveLinkColor = System.Drawing.Color.Blue;
            this.lblSeriesTitleLinked.AutoSize = true;
            this.lblSeriesTitleLinked.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeriesTitleLinked.Location = new System.Drawing.Point(403, 149);
            this.lblSeriesTitleLinked.Name = "lblSeriesTitleLinked";
            this.lblSeriesTitleLinked.Size = new System.Drawing.Size(0, 29);
            this.lblSeriesTitleLinked.TabIndex = 8;
            this.lblSeriesTitleLinked.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkedLabelClicked);
            // 
            // picSeriesThumb
            // 
            this.picSeriesThumb.Location = new System.Drawing.Point(322, 6);
            this.picSeriesThumb.Name = "picSeriesThumb";
            this.picSeriesThumb.Size = new System.Drawing.Size(758, 140);
            this.picSeriesThumb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSeriesThumb.TabIndex = 2;
            this.picSeriesThumb.TabStop = false;
            // 
            // lblSummary
            // 
            this.lblSummary.Location = new System.Drawing.Point(319, 187);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(761, 159);
            this.lblSummary.TabIndex = 1;
            // 
            // lstSeriesResults
            // 
            this.lstSeriesResults.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstSeriesResults.FormattingEnabled = true;
            this.lstSeriesResults.ItemHeight = 16;
            this.lstSeriesResults.Location = new System.Drawing.Point(3, 3);
            this.lstSeriesResults.Name = "lstSeriesResults";
            this.lstSeriesResults.Size = new System.Drawing.Size(307, 457);
            this.lstSeriesResults.TabIndex = 6;
            this.lstSeriesResults.SelectedIndexChanged += new System.EventHandler(this.lstSeriesResults_SelectedIndexChanged);
            // 
            // tabRenamer
            // 
            this.tabRenamer.Controls.Add(this.grdRenameData);
            this.tabRenamer.Controls.Add(this.panel3);
            this.tabRenamer.Controls.Add(this.panel2);
            this.tabRenamer.Controls.Add(this.lstFileRenamer);
            this.tabRenamer.Location = new System.Drawing.Point(4, 25);
            this.tabRenamer.Name = "tabRenamer";
            this.tabRenamer.Padding = new System.Windows.Forms.Padding(3);
            this.tabRenamer.Size = new System.Drawing.Size(1262, 463);
            this.tabRenamer.TabIndex = 0;
            this.tabRenamer.Text = "Renamer";
            this.tabRenamer.UseVisualStyleBackColor = true;
            // 
            // grdRenameData
            // 
            this.grdRenameData.AllowUserToAddRows = false;
            this.grdRenameData.AllowUserToDeleteRows = false;
            this.grdRenameData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.grdRenameData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRenameData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRenameData.Location = new System.Drawing.Point(3, 38);
            this.grdRenameData.MultiSelect = false;
            this.grdRenameData.Name = "grdRenameData";
            this.grdRenameData.RowHeadersWidth = 51;
            this.grdRenameData.RowTemplate.Height = 24;
            this.grdRenameData.Size = new System.Drawing.Size(1256, 309);
            this.grdRenameData.TabIndex = 10;
            this.grdRenameData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRenameData_CellValueChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblRepeat);
            this.panel3.Controls.Add(this.txtRepeat);
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.btnDown);
            this.panel3.Controls.Add(this.btnUp);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1256, 35);
            this.panel3.TabIndex = 6;
            // 
            // lblRepeat
            // 
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.Location = new System.Drawing.Point(372, 9);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(58, 17);
            this.lblRepeat.TabIndex = 7;
            this.lblRepeat.Text = "Repeat:";
            // 
            // txtRepeat
            // 
            this.txtRepeat.Location = new System.Drawing.Point(436, 6);
            this.txtRepeat.MaxLength = 3;
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.Size = new System.Drawing.Size(100, 22);
            this.txtRepeat.TabIndex = 6;
            this.txtRepeat.Text = "1";
            this.txtRepeat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRepeat_KeyPress);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 8);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 21);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Select All";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(291, 6);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(210, 6);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lstFileRenamer
            // 
            this.lstFileRenamer.AllColumns.Add(this.colOrigFileName);
            this.lstFileRenamer.AllColumns.Add(this.colNewFileName);
            this.lstFileRenamer.AllColumns.Add(this.colSeries);
            this.lstFileRenamer.AllColumns.Add(this.colSeason);
            this.lstFileRenamer.AllColumns.Add(this.colEpisodeNumber);
            this.lstFileRenamer.AllColumns.Add(this.colEpisodeTitle);
            this.lstFileRenamer.AllColumns.Add(this.colYear);
            this.lstFileRenamer.AllColumns.Add(this.colResolution);
            this.lstFileRenamer.AllColumns.Add(this.colThumb);
            this.lstFileRenamer.AllColumns.Add(this.colPath);
            this.lstFileRenamer.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.lstFileRenamer.CellEditUseWholeCell = false;
            this.lstFileRenamer.CheckBoxes = true;
            this.lstFileRenamer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOrigFileName,
            this.colNewFileName,
            this.colSeries,
            this.colSeason,
            this.colEpisodeNumber,
            this.colEpisodeTitle,
            this.colYear,
            this.colResolution,
            this.colThumb});
            this.lstFileRenamer.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstFileRenamer.FullRowSelect = true;
            this.lstFileRenamer.HideSelection = false;
            this.lstFileRenamer.LargeImageList = this.imgLstLarge;
            this.lstFileRenamer.Location = new System.Drawing.Point(3, 194);
            this.lstFileRenamer.MultiSelect = false;
            this.lstFileRenamer.Name = "lstFileRenamer";
            this.lstFileRenamer.ShowGroups = false;
            this.lstFileRenamer.Size = new System.Drawing.Size(1256, 120);
            this.lstFileRenamer.SmallImageList = this.imgLstSmall;
            this.lstFileRenamer.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstFileRenamer.TabIndex = 9;
            this.lstFileRenamer.UseAlternatingBackColors = true;
            this.lstFileRenamer.UseCompatibleStateImageBehavior = false;
            this.lstFileRenamer.View = System.Windows.Forms.View.Details;
            this.lstFileRenamer.Visible = false;
            this.lstFileRenamer.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.lstFileRenamer_CellClick);
            this.lstFileRenamer.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstFileRenamer_ItemChecked);
            // 
            // colOrigFileName
            // 
            this.colOrigFileName.AspectName = "OrigFileName";
            this.colOrigFileName.MinimumWidth = 200;
            this.colOrigFileName.Sortable = false;
            this.colOrigFileName.Text = "Old Name";
            this.colOrigFileName.Width = 222;
            // 
            // colNewFileName
            // 
            this.colNewFileName.AspectName = "NewFileName";
            this.colNewFileName.MinimumWidth = 200;
            this.colNewFileName.Text = "New Name";
            this.colNewFileName.Width = 240;
            // 
            // colSeries
            // 
            this.colSeries.AspectName = "Series";
            this.colSeries.MinimumWidth = 150;
            this.colSeries.Text = "Series";
            this.colSeries.Width = 166;
            // 
            // colSeason
            // 
            this.colSeason.AspectName = "Season";
            this.colSeason.MinimumWidth = 50;
            this.colSeason.Text = "Season";
            this.colSeason.Width = 120;
            // 
            // colEpisodeNumber
            // 
            this.colEpisodeNumber.AspectName = "EpisodeNumber";
            this.colEpisodeNumber.MinimumWidth = 50;
            this.colEpisodeNumber.Text = "Episode Number";
            this.colEpisodeNumber.Width = 124;
            // 
            // colEpisodeTitle
            // 
            this.colEpisodeTitle.AspectName = "EpisodeTitle";
            this.colEpisodeTitle.MinimumWidth = 100;
            this.colEpisodeTitle.Text = "Episode";
            this.colEpisodeTitle.Width = 100;
            // 
            // colYear
            // 
            this.colYear.AspectName = "Year";
            this.colYear.MinimumWidth = 50;
            this.colYear.Text = "Year";
            // 
            // colResolution
            // 
            this.colResolution.AspectName = "Resolution";
            this.colResolution.MinimumWidth = 100;
            this.colResolution.Text = "Resolution";
            this.colResolution.Width = 119;
            // 
            // colThumb
            // 
            this.colThumb.AspectName = "Thumb";
            this.colThumb.MinimumWidth = 50;
            this.colThumb.Text = "Thumb";
            // 
            // colPath
            // 
            this.colPath.AspectName = "Path";
            this.colPath.DisplayIndex = 0;
            this.colPath.FillsFreeSpace = true;
            this.colPath.Groupable = false;
            this.colPath.IsVisible = false;
            this.colPath.Text = "Path";
            this.colPath.Width = 0;
            // 
            // imgLstLarge
            // 
            this.imgLstLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgLstLarge.ImageSize = new System.Drawing.Size(16, 16);
            this.imgLstLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imgLstSmall
            // 
            this.imgLstSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgLstSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imgLstSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FrmLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 521);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLookup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLookup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabResults.ResumeLayout(false);
            this.tabResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSeriesThumb)).EndInit();
            this.tabRenamer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRenameData)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstFileRenamer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSeriesLookup;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.TabPage tabResults;
        private System.Windows.Forms.PictureBox picSeriesThumb;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.ListBox lstSeriesResults;
        private System.Windows.Forms.LinkLabel lblSeriesTitleLinked;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TabPage tabRenamer;
        private BrightIdeasSoftware.ObjectListView lstFileRenamer;
        private BrightIdeasSoftware.OLVColumn colPath;
        private BrightIdeasSoftware.OLVColumn colOrigFileName;
        private BrightIdeasSoftware.OLVColumn colSeries;
        private BrightIdeasSoftware.OLVColumn colSeason;
        private BrightIdeasSoftware.OLVColumn colEpisodeTitle;
        private BrightIdeasSoftware.OLVColumn colEpisodeNumber;
        private BrightIdeasSoftware.OLVColumn colYear;
        private BrightIdeasSoftware.OLVColumn colResolution;
        private BrightIdeasSoftware.OLVColumn colThumb;
        private System.Windows.Forms.ImageList imgLstSmall;
        private System.Windows.Forms.ImageList imgLstLarge;
        private BrightIdeasSoftware.OLVColumn colNewFileName;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.ComboBox cboFormat;
        private System.Windows.Forms.DataGridView grdRenameData;
        private System.Windows.Forms.CheckBox chkDeleteDups;
        private System.Windows.Forms.CheckBox chkRenameAccompanyingFiles;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.CheckBox chkDeleteUnwantedFiles;
        private System.Windows.Forms.CheckBox chkMakeMissingPlaceholder;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.TextBox txtRepeat;
    }
}