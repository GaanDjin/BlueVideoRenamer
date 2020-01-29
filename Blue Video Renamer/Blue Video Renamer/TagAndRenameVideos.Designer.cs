namespace Blue_Video_Renamer
{
    partial class TagAndRenameVideos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagAndRenameVideos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtInstructions = new System.Windows.Forms.RichTextBox();
            this.btnLookup = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeListViewFilesAndTags = new BrightIdeasSoftware.TreeListView();
            this.colFilename = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colRenamedFile = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSeries = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSeason = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colEpisodeNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colEpisodeTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colResolution = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colYear = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colThumb = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colFormat = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSize = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colPath = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.treeListViewRootPath = new BrightIdeasSoftware.TreeListView();
            this.colPathRoot = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.bgWkrPopulateFolderView = new System.ComponentModel.BackgroundWorker();
            this.btnSettings = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewFilesAndTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewRootPath)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtInstructions);
            this.panel1.Controls.Add(this.btnSettings);
            this.panel1.Controls.Add(this.btnLookup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 411);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1157, 102);
            this.panel1.TabIndex = 1;
            // 
            // txtInstructions
            // 
            this.txtInstructions.BackColor = System.Drawing.SystemColors.Control;
            this.txtInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInstructions.Location = new System.Drawing.Point(159, 0);
            this.txtInstructions.Name = "txtInstructions";
            this.txtInstructions.Size = new System.Drawing.Size(899, 102);
            this.txtInstructions.TabIndex = 2;
            this.txtInstructions.Text = resources.GetString("txtInstructions.Text");
            // 
            // btnLookup
            // 
            this.btnLookup.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLookup.Location = new System.Drawing.Point(0, 0);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(159, 102);
            this.btnLookup.TabIndex = 0;
            this.btnLookup.Text = "Lookup";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeListViewFilesAndTags);
            this.panel2.Controls.Add(this.treeListViewRootPath);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1157, 411);
            this.panel2.TabIndex = 1;
            // 
            // treeListViewFilesAndTags
            // 
            this.treeListViewFilesAndTags.AllColumns.Add(this.colFilename);
            this.treeListViewFilesAndTags.AllColumns.Add(this.colRenamedFile);
            this.treeListViewFilesAndTags.AllColumns.Add(this.colSeries);
            this.treeListViewFilesAndTags.AllColumns.Add(this.colSeason);
            this.treeListViewFilesAndTags.AllColumns.Add(this.colEpisodeNumber);
            this.treeListViewFilesAndTags.AllColumns.Add(this.colEpisodeTitle);
            this.treeListViewFilesAndTags.AllColumns.Add(this.colResolution);
            this.treeListViewFilesAndTags.AllColumns.Add(this.colYear);
            this.treeListViewFilesAndTags.AllColumns.Add(this.colThumb);
            this.treeListViewFilesAndTags.AllColumns.Add(this.colFormat);
            this.treeListViewFilesAndTags.AllColumns.Add(this.colSize);
            this.treeListViewFilesAndTags.AllColumns.Add(this.colPath);
            this.treeListViewFilesAndTags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFilename});
            this.treeListViewFilesAndTags.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListViewFilesAndTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListViewFilesAndTags.EmptyListMsg = "Empty!";
            this.treeListViewFilesAndTags.FullRowSelect = true;
            this.treeListViewFilesAndTags.LargeImageList = this.imageListLarge;
            this.treeListViewFilesAndTags.Location = new System.Drawing.Point(327, 0);
            this.treeListViewFilesAndTags.Name = "treeListViewFilesAndTags";
            this.treeListViewFilesAndTags.ShowGroups = false;
            this.treeListViewFilesAndTags.Size = new System.Drawing.Size(830, 411);
            this.treeListViewFilesAndTags.SmallImageList = this.imageListSmall;
            this.treeListViewFilesAndTags.TabIndex = 0;
            this.treeListViewFilesAndTags.UseCompatibleStateImageBehavior = false;
            this.treeListViewFilesAndTags.View = System.Windows.Forms.View.Details;
            this.treeListViewFilesAndTags.VirtualMode = true;
            this.treeListViewFilesAndTags.ItemActivate += new System.EventHandler(this.treeListViewFilesAndTags_ItemActivate);
            // 
            // colFilename
            // 
            this.colFilename.FillsFreeSpace = true;
            this.colFilename.Text = "Filename";
            this.colFilename.Width = 268;
            // 
            // colRenamedFile
            // 
            this.colRenamedFile.DisplayIndex = 1;
            this.colRenamedFile.IsVisible = false;
            this.colRenamedFile.Text = "Rename To";
            this.colRenamedFile.Width = 326;
            // 
            // colSeries
            // 
            this.colSeries.DisplayIndex = 2;
            this.colSeries.IsVisible = false;
            this.colSeries.Text = "Series";
            // 
            // colSeason
            // 
            this.colSeason.DisplayIndex = 3;
            this.colSeason.IsVisible = false;
            this.colSeason.Text = "Season";
            // 
            // colEpisodeNumber
            // 
            this.colEpisodeNumber.DisplayIndex = 4;
            this.colEpisodeNumber.IsVisible = false;
            this.colEpisodeNumber.Text = "Episode";
            // 
            // colEpisodeTitle
            // 
            this.colEpisodeTitle.DisplayIndex = 5;
            this.colEpisodeTitle.IsVisible = false;
            this.colEpisodeTitle.Text = "Title";
            // 
            // colResolution
            // 
            this.colResolution.DisplayIndex = 6;
            this.colResolution.IsVisible = false;
            this.colResolution.Text = "Resolution";
            // 
            // colYear
            // 
            this.colYear.DisplayIndex = 7;
            this.colYear.IsVisible = false;
            this.colYear.Text = "Year";
            // 
            // colThumb
            // 
            this.colThumb.DisplayIndex = 8;
            this.colThumb.IsVisible = false;
            this.colThumb.Text = "Thumb";
            // 
            // colFormat
            // 
            this.colFormat.DisplayIndex = 9;
            this.colFormat.IsVisible = false;
            this.colFormat.Text = "Format";
            // 
            // colSize
            // 
            this.colSize.DisplayIndex = 10;
            this.colSize.IsVisible = false;
            this.colSize.Text = "Size";
            // 
            // colPath
            // 
            this.colPath.DisplayIndex = 0;
            this.colPath.IsEditable = false;
            this.colPath.IsTileViewColumn = true;
            this.colPath.IsVisible = false;
            this.colPath.MaximumWidth = 0;
            this.colPath.Text = "Path";
            this.colPath.Width = 0;
            // 
            // imageListLarge
            // 
            this.imageListLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListLarge.ImageSize = new System.Drawing.Size(64, 64);
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageListSmall
            // 
            this.imageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // treeListViewRootPath
            // 
            this.treeListViewRootPath.AllColumns.Add(this.colPathRoot);
            this.treeListViewRootPath.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPathRoot});
            this.treeListViewRootPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeListViewRootPath.Location = new System.Drawing.Point(0, 0);
            this.treeListViewRootPath.Name = "treeListViewRootPath";
            this.treeListViewRootPath.ShowGroups = false;
            this.treeListViewRootPath.Size = new System.Drawing.Size(327, 411);
            this.treeListViewRootPath.TabIndex = 1;
            this.treeListViewRootPath.UseCompatibleStateImageBehavior = false;
            this.treeListViewRootPath.View = System.Windows.Forms.View.Details;
            this.treeListViewRootPath.VirtualMode = true;
            this.treeListViewRootPath.ItemActivate += new System.EventHandler(this.treeListViewFilesAndTags_ItemActivate);
            this.treeListViewRootPath.SelectedIndexChanged += new System.EventHandler(this.treeListViewRootPath_SelectedIndexChanged);
            this.treeListViewRootPath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeListViewRootPath_MouseDoubleClick);
            // 
            // colPathRoot
            // 
            this.colPathRoot.FillsFreeSpace = true;
            this.colPathRoot.Text = "Path";
            // 
            // bgWkrPopulateFolderView
            // 
            this.bgWkrPopulateFolderView.WorkerReportsProgress = true;
            this.bgWkrPopulateFolderView.WorkerSupportsCancellation = true;
            this.bgWkrPopulateFolderView.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWkrPopulateFolderView_DoWork);
            this.bgWkrPopulateFolderView.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWkrPopulateFolderView_RunWorkerCompleted);
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSettings.Location = new System.Drawing.Point(1058, 0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(99, 102);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // TagAndRenameVideos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 513);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TagAndRenameVideos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TagAndRenameVideos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TagAndRenameVideos_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewFilesAndTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListViewRootPath)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker bgWkrPopulateFolderView;
        private BrightIdeasSoftware.TreeListView treeListViewFilesAndTags;
        private BrightIdeasSoftware.OLVColumn colFilename;
        private BrightIdeasSoftware.OLVColumn colRenamedFile;
        private BrightIdeasSoftware.OLVColumn colSeries;
        private BrightIdeasSoftware.OLVColumn colSeason;
        private BrightIdeasSoftware.OLVColumn colEpisodeNumber;
        private BrightIdeasSoftware.OLVColumn colEpisodeTitle;
        private BrightIdeasSoftware.OLVColumn colResolution;
        private BrightIdeasSoftware.OLVColumn colYear;
        private BrightIdeasSoftware.OLVColumn colThumb;
        private BrightIdeasSoftware.OLVColumn colFormat;
        private System.Windows.Forms.ImageList imageListLarge;
        private System.Windows.Forms.ImageList imageListSmall;
        private BrightIdeasSoftware.OLVColumn colPath;
        private BrightIdeasSoftware.OLVColumn colSize;
        private BrightIdeasSoftware.TreeListView treeListViewRootPath;
        private BrightIdeasSoftware.OLVColumn colPathRoot;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.RichTextBox txtInstructions;
        private System.Windows.Forms.Button btnSettings;
    }
}