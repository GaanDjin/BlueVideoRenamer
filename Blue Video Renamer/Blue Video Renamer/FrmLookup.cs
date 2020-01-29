using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTVDB_API_v2;

namespace Blue_Video_Renamer
{
    public partial class FrmLookup : Form
    {
        private BindingSource bindingSource1 = new BindingSource();

        public string RootPath;
        public List<string> Paths;
        public SeriesSearchResult SelectedSeries;

        public FrmLookup(string rootpath, List<string> paths)
        {
            InitializeComponent();

            chkDeleteDups.Checked = Configuration.DeleteDuplicates;
            chkRenameAccompanyingFiles.Checked = Configuration.RenameMatchingAccompanyingFiles;
            chkDeleteUnwantedFiles.Checked = Configuration.DeleteUnwantedFiles;
            chkMakeMissingPlaceholder.Checked = Configuration.MakeMissingPlaceholder;

            //if (rootpath)
            {
                //TODO: Not a really great guess here. 
                FileInfo path = new FileInfo(rootpath);

                if ((path.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                    txtSeriesLookup.Text = path.Name;
                else
                    txtSeriesLookup.Text = path.Directory.Name;
            }


            //InitObjectListViewFilesAndTags();

            //ArrayList roots = new ArrayList();
            //roots.Add(new MyFileSystemInfo(new DirectoryInfo(path)));
            //this.treeListViewFilesAndTags.Roots = roots;
            RootPath = rootpath;
            Paths = paths;

            cboFormat.Items.AddRange(Configuration.RenameFormats);

            if (cboFormat.Items.Count > 0)
                cboFormat.Text = cboFormat.Items[0].ToString();

            SetupGrdRenameData();

            btnLookup_Click(this, null);
        }

        void SetupGrdRenameData()
        {
            DataGridViewColumn column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "Selected";
            column.Name = "";
            grdRenameData.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "OrigFileName";
            column.Name = "Old Name";
            grdRenameData.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "NewFileName";
            column.Name = "New Name";
            grdRenameData.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Series";
            column.Name = "Series";
            grdRenameData.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Season";
            column.Name = "Season";
            grdRenameData.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "EpisodeTitle";
            column.Name = "Title";
            grdRenameData.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "EpisodeNumber";
            column.Name = "Episode";
            grdRenameData.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Year";
            column.Name = "Year";
            grdRenameData.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Resolution";
            column.Name = "Resolution";
            grdRenameData.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Thumb";
            column.Name = "Thumb";
            grdRenameData.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Path";
            column.Name = "Path";
            grdRenameData.Columns.Add(column);

            grdRenameData.AutoGenerateColumns = false;
            grdRenameData.DataSource = bindingSource1;
            
        }

        private async void btnLookup_Click(object sender, EventArgs e)
        {
            btnLookup.Enabled = false;
            // txtSeriesLookup.Text = txtSeriesLookup.Text.Trim();
            string name = txtSeriesLookup.Text.Trim();

            lstSeriesResults.Items.Clear();
            lblSeriesTitleLinked.Links.Clear();

            if (name.Length == 0)
                return;

            SeriesSearchResult[] results = await VideoInformation.ThetvDB.SearchSeries(name);

            if (results != null)
                foreach (SeriesSearchResult result in results)
                {
                    lstSeriesResults.Items.Add(new ListBoxItem(result));
                }

            if (lstSeriesResults.Items.Count > 0)
            {
                lstSeriesResults.SelectedIndex = 0;
                btnSelect.Enabled = true;
            }
            else
            {
                btnSelect.Enabled = false;
                MessageBox.Show("No shows found!");
                txtSeriesLookup.Focus();
                txtSeriesLookup.SelectAll();
            }
            btnLookup.Enabled = true;
        }

        private void lstSeriesResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSeriesTitleLinked.Links.Clear();

            btnSelect.Enabled = true;

            ListBoxItem item = (ListBoxItem)lstSeriesResults.Items[lstSeriesResults.SelectedIndex];

            lblSeriesTitleLinked.Text = item.SearchResult.SeriesName;
            lblSeriesTitleLinked.Links.Add(0, item.SearchResult.SeriesName.Length, "https://www.thetvdb.com/series/" + item.SearchResult.Slug);

            if (item.SearchResult.Banner == null)
                picSeriesThumb.ImageLocation = "No Banner Art.png";
            else
                picSeriesThumb.ImageLocation = item.SearchResult.Banner;
            
            lblSummary.Text = item.SearchResult.Overview;
        }

        private void LinkedLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)

        {

            //dynamicLinkLabel.LinkVisited = true;

            System.Diagnostics.Process.Start((string)lblSeriesTitleLinked.Links[0].LinkData);

        }

        private async Task<bool> InitLstFileRenamerAsync(List<string> paths)
        {
            btnLookup.Enabled = false;
            ListBoxRenameItem item;
            //string newName;
            int filenum = 0;

            this.lstFileRenamer.Items.Clear();

            Series series = await VideoInformation.ThetvDB.GetSeries(SelectedSeries);
            List<Episode> episodes = new List<Episode>(Task.Run(async () => { return await VideoInformation.ThetvDB.GetAllEpisodes(SelectedSeries); }).Result);
            episodes = HelperFunctions.DistinctBy( episodes, c => c.Id).ToList();
            List<Episode> matchedEpisodes = new List<Episode>();
            List<FileInfo> orphanedEpisodes = new List<FileInfo>();

            List<string> files = new List<string>();

            //Check each path and if it's a dir then get all files in that dir.
            foreach(string path in paths)
            {
                FileInfo fi = new FileInfo(path);
                if ((fi.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                    foreach (string file in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
                    {
                        files.Add(file);
                    }
                else
                    files.Add(path);
            }

            files = files.Distinct().ToList();
            files.Sort();
            
            if (MatchEpisodes(ref files, ref episodes, series, ref filenum, ref matchedEpisodes, orphanedEpisodes, true) == 0)
            {
                //If the match totally failed then try matching again without the series name. 
                filenum = 0;
                matchedEpisodes = new List<Episode>();
                orphanedEpisodes = new List<FileInfo>();

                MatchEpisodes(ref files, ref episodes, series, ref filenum, ref matchedEpisodes, orphanedEpisodes, false);
            }
            foreach (FileInfo info in orphanedEpisodes)
            {
                filenum++;

                //if (episodes.Count > 0)
                //{
                //    Episode ep = episodes[0];
                //    episodes.RemoveAt(0);

                //    //newName = VideoInformation.GetEpisodeName(info.Name, series, new Episode[] { ep }, cboFormat.Text, filenum, Configuration.InvalidCharReplacement, Configuration.EpisodeDateFormat, Configuration.SeriesDateFormat);
                //    item = new ListBoxRenameItem(info.FullName, info.Name, newName, series.SeriesName, ep.AiredSeason.ToString(), ep.EpisodeName, ep.AiredEpisodeNumber.ToString(), series.FirstAired.Year.ToString(), "", "" );//"res", "thumb" 
                //}
                //else
                {
                    item = new ListBoxRenameItem(info.Directory.FullName, info.Name, "Missing!", series.SeriesName, "", "", "", series.FirstAired.Year.ToString(), "", "" );
                }

                Add(item);
            }

            foreach (Episode ep in episodes)
            {
                string newName = VideoInformation.GetEpisodeName("", series, new Episode[] { ep }, cboFormat.Text, filenum, Configuration.InvalidCharReplacement, Configuration.EpisodeDateFormat, Configuration.SeriesDateFormat);
                item = new ListBoxRenameItem( "", "Missing!", newName, series.SeriesName, ep.AiredSeason.ToString(), ep.EpisodeName, ep.AiredEpisodeNumber.ToString(), series.FirstAired.Year.ToString(), "", "" );//"res", "thumb" 
                Add(item);
            }

            checkBox1.Checked = true;
            btnLookup.Enabled = true;
            return true;

        }

        private int MatchEpisodes(ref List<string> files, ref List<Episode> episodes, Series series, ref int filenum, ref List<Episode> matchedEpisodes, List<FileInfo> orphanedEpisodes, bool matchwithseriesname)
        {
            int matched = 0;
            ListBoxRenameItem item;
            foreach (string file in files)
            {
                if (Configuration.IsValidVideo(file))
                {
                    filenum++;

                    FileInfo info = new FileInfo(file);
                    Episode[] ep = VideoInformation.MatchEpisode(info.FullName, episodes, series, matchwithseriesname);

                    if (ep != null && ep.Length > 0)
                    {
                        foreach (Episode e in ep)
                        {
                            matchedEpisodes.Add(e);
                            episodes.Remove(e);
                            matched++;
                        }
                    }
                    else
                    {
                        ep = VideoInformation.MatchEpisode(info.FullName, matchedEpisodes, series, matchwithseriesname);

                        if (ep != null && ep.Length > 0)
                        {
                            item = new ListBoxRenameItem(info.Directory.FullName, info.Name, "Duplicate!", series.SeriesName, "", "", "", series.FirstAired.Year.ToString(), "", "");
                            Add(item);
                        }
                        else
                            orphanedEpisodes.Add(info);
                        continue;
                    }

                    string newName = VideoInformation.GetEpisodeName(info.Name, series, ep, cboFormat.Text, filenum, Configuration.InvalidCharReplacement, Configuration.EpisodeDateFormat, Configuration.SeriesDateFormat);
                    if (ep.Length == 1)
                        item = new ListBoxRenameItem(info.Directory.FullName, info.Name, newName, series.SeriesName, ep[0].AiredSeason.ToString(), ep[0].EpisodeName, ep[0].AiredEpisodeNumber.ToString(), series.FirstAired.Year.ToString(), "", "");//"res", "thumb" 
                    else
                        item = new ListBoxRenameItem(info.Directory.FullName, info.Name, newName, series.SeriesName, ep[0].AiredSeason.ToString(), ep[0].EpisodeName + " & " + ep[1].EpisodeName, ep[0].AiredEpisodeNumber.ToString() + "-" + ep[1].AiredEpisodeNumber.ToString(), series.FirstAired.Year.ToString(), "", "");//"res", "thumb" 

                    Add(item);
                }
                else if (Configuration.IsUnwantedExtension(file))
                {
                    FileInfo info = new FileInfo(file);
                    item = new ListBoxRenameItem(info.Directory.FullName, info.Name, "Unwanted!", "", "", "", "", "", "", "");//"res", "thumb" 

                    Add(item);
                }
            }
            return matched;
        }
             

        /*
        private void InitObjectListViewFilesAndTags()
        {
            // Remember: TreeListViews must have a small image list assigned to them.
            // If they do not, the hit testing will be wildly off

            // Allow all models to be expanded and each model will show Children as its sub-branches
            //treeListViewFilesAndTags.CanExpandGetter = delegate (object x) { return true; };
            //treeListViewFilesAndTags.ChildrenGetter = delegate (object x) { return ((ModelWithChildren)x).Children; };

            this.treeListViewFilesAndTags.CanExpandGetter = delegate (object x) {
                return ((MyFileSystemInfo)x).IsDirectory;
            };

            //Only ever called if CanExpandGetter is a DirectoryInfo.
            this.treeListViewFilesAndTags.ChildrenGetter = delegate (object x) {
                try
                {
                    //ArrayList childern = new ArrayList();
                    //foreach(MyFileSystemInfo file in ((MyFileSystemInfo)x).GetFileSystemInfos())
                    //{
                    //    if (file.IsDirectory || Configuration.IsValidVideo(file.Name))
                    //        childern.Add(file);
                    //}
                    //return childern;
                    //if (((MyFileSystemInfo)x).IsDirectory || Configuration.IsValidVideo(subdir.Name))
                    return ((MyFileSystemInfo)x).GetFileSystemInfos();
                }
                catch (UnauthorizedAccessException ex)
                {
                    this.BeginInvoke((MethodInvoker)delegate () {
                        this.treeListViewFilesAndTags.Collapse(x);
                        MessageBox.Show(this, ex.Message, "ObjectListViewDemo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    });
                    return new ArrayList();
                }
            };

            // Once those two delegates are in place, the TreeListView starts working
            // after setting the Roots property.

            // List all drives as the roots of the tree
            ArrayList roots = new ArrayList();
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                if (di.IsReady)
                    roots.Add(new MyFileSystemInfo(new DirectoryInfo(di.Name)));
            }
            this.treeListViewFilesAndTags.Roots = roots;

            //this.treeListView.ChildrenGetter = delegate (object x) {
            //    var model = (MyModelClass)x;
            //    if (model.HasChildrenAlready)
            //        return model.Children;
            //    if (!model.AlreadyStartedSlowFetch)
            //    {
            //        model.AlreadyStartedSlowFetch = true;
            //        Task.Factory.StartNew(() => {
            //            model.SlowChildrenFetch();
            //            this.treeListView.RefreshObject(model);
            //        });
            //    }
            //    return new ArrayList();
            //};
            SetupColumns();
        }

        private void SetupColumns()
        {
            // The column setup here is identical to the File Explorer example tab --
            // nothing specific to the TreeListView. 

            // The only difference is that we don't setup anything to do with grouping,
            // since TreeListViews can't show groups.

            SysImageListHelper helper = new SysImageListHelper(this.treeListViewFilesAndTags);
            this.colFilename.ImageGetter = delegate (object x) {
                return helper.GetImageIndex(((MyFileSystemInfo)x).FullName);
            };
            this.colFilename.AspectGetter = delegate (object x) {
                if (((MyFileSystemInfo)x) != null)
                    return ((MyFileSystemInfo)x).Name;
                return "";
            };

            // Get the size of the file system entity. 
            // Folders and errors are represented as negative numbers
            this.colSize.AspectGetter = delegate (object x) {
                MyFileSystemInfo myFileSystemInfo = (MyFileSystemInfo)x;

                if (myFileSystemInfo.IsDirectory)
                    return (long)-1;

                try
                {
                    return myFileSystemInfo.Length;
                }
                catch (System.IO.FileNotFoundException)
                {
                    // Mono 1.2.6 throws this for hidden files
                    return (long)-2;
                }
            };

            // Show the size of files as GB, MB and KBs. By returning the actual
            // size in the AspectGetter, and doing the conversion in the 
            // AspectToStringConverter, sorting on this column will work off the
            // actual sizes, rather than the formatted string.
            this.colSize.AspectToStringConverter = delegate (object x) {
                long sizeInBytes = (long)x;
                if (sizeInBytes < 0) // folder or error
                    return "";
                return HelperFunctions.FormatFileSize(sizeInBytes);
            };

            // Show the system description for this object
            this.colFormat.AspectGetter = delegate (object x) {
                return ShellUtilities.GetFileType(((MyFileSystemInfo)x).FullName);
            };

            this.colSeries.AspectGetter = delegate (object x) {
                return VideoInformation.Series((MyFileSystemInfo)x);
            };
            this.colSeason.AspectGetter = delegate (object x) {
                return VideoInformation.Season((MyFileSystemInfo)x);
            };
            this.colEpisodeNumber.AspectGetter = delegate (object x) {
                return VideoInformation.EpisodeNumber((MyFileSystemInfo)x);
            };
            this.colEpisodeTitle.AspectGetter = delegate (object x) {
                return VideoInformation.EpisodeTitle((MyFileSystemInfo)x);
            };
            this.colResolution.AspectGetter = delegate (object x) {
                return VideoInformation.Resolution((MyFileSystemInfo)x);
            };
            this.colYear.AspectGetter = delegate (object x) {
                return VideoInformation.Year((MyFileSystemInfo)x);
            };
            this.colThumb.AspectGetter = delegate (object x) {
                return VideoInformation.Thumb((MyFileSystemInfo)x);
            };


            //// Show the file attributes for this object
            //// A FlagRenderer masks off various values and draws zero or images based 
            //// on the presence of individual bits.
            //this.olvColumnAttributes.AspectGetter = delegate (object x) {
            //    return ((MyFileSystemInfo)x).Attributes;
            //};
            //FlagRenderer attributesRenderer = new FlagRenderer();
            //attributesRenderer.ImageList = imageListSmall;
            //attributesRenderer.Add(FileAttributes.Archive, "archive");
            //attributesRenderer.Add(FileAttributes.ReadOnly, "readonly");
            //attributesRenderer.Add(FileAttributes.System, "system");
            //attributesRenderer.Add(FileAttributes.Hidden, "hidden");
            //attributesRenderer.Add(FileAttributes.Temporary, "temporary");
            //this.olvColumnAttributes.Renderer = attributesRenderer;

            //// Tell the filtering subsystem that the attributes column is a collection of flags
            //this.olvColumnAttributes.ClusteringStrategy = new FlagClusteringStrategy(typeof(FileAttributes));

            //this.colPath.AspectGetter = delegate (object x) {
            //    return ((MyFileSystemInfo)x).FullName;
            //};

        }
        */

        private void txtSeriesLookup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n' || e.KeyChar == '\r')
            {
                btnLookup_Click(sender, e);
                e.Handled = true;
            }
            
        }

        private async void btnSelect_Click(object sender, EventArgs e)
        {
            if (lstSeriesResults.Items.Count == 0)
                return;

            ListBoxItem item = (ListBoxItem)lstSeriesResults.Items[lstSeriesResults.SelectedIndex];

            SelectedSeries = item.SearchResult;

            bindingSource1.Clear();
            grdRenameData.Invalidate();
            await InitLstFileRenamerAsync(Paths);
            tabControl1.SelectedTab = tabRenamer;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool doSelect = false;
            bool value = false;

            if (checkBox1.CheckState == CheckState.Checked)
            {
                lstFileRenamer.CheckAll();
                doSelect = true;
                value = true;
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                lstFileRenamer.UncheckAll();

                doSelect = true;
                value = false;
            }

            if (doSelect)
            {
                foreach (ListBoxRenameItem item in bindingSource1)
                {
                    item.Selected = value;
                }
                grdRenameData.Invalidate();
            }
        }

        private void lstFileRenamer_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lstFileRenamer.CheckedIndices.Count == 0)
                checkBox1.CheckState = CheckState.Unchecked;
            else if (lstFileRenamer.CheckedIndices.Count == lstFileRenamer.GetItemCount())
                checkBox1.CheckState = CheckState.Checked;
            else
                checkBox1.CheckState = CheckState.Indeterminate;
        }

        BrightIdeasSoftware.OLVListSubItem lastCell = null;
        private void lstFileRenamer_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (lastCell != null)
                lastCell.BackColor = SystemColors.Window;

            e.SubItem.BackColor = SystemColors.Highlight;
           // lstFileRenamer.red

            lastCell = e.SubItem;
        }

        void Add(ListBoxRenameItem item)
        {
            this.lstFileRenamer.AddObject(item);
            bindingSource1.Add(item);
        }

        private void grdRenameData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(grdRenameData.Columns[e.ColumnIndex].DataPropertyName == "Selected")
            {
                grdRenameData.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bool allSelected = true;
                bool noneSelected = true;
                foreach (ListBoxRenameItem item in bindingSource1)
                {
                    if (!item.Selected)
                        allSelected = false;
                    if (item.Selected)
                        noneSelected = false;
                }

                if (noneSelected)
                    checkBox1.CheckState = CheckState.Unchecked;
                else if (allSelected)
                    checkBox1.CheckState = CheckState.Checked;
                else
                    checkBox1.CheckState = CheckState.Indeterminate;
            }
        }

        private void cboFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelect_Click(sender, e);
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            //chkDeleteDups.Checked = Configuration.DeleteDuplicates;
            //chkRenameAccompanyingFiles.Checked = Configuration.RenameMatchingAccompanyingFiles;
            //chkDeleteUnwantedFiles.Checked = Configuration.DeleteUnwantedFiles;
            FileInfo oldFileName;
            FileInfo newFileName;

            foreach (ListBoxRenameItem item in bindingSource1)
            {
                if (!item.Selected)
                    continue;

                try
                {
                    oldFileName = new FileInfo(item.Path + Path.DirectorySeparatorChar + item.OrigFileName);

                    if (chkDeleteDups.Checked && item.NewFileName.Equals("Duplicate!", StringComparison.InvariantCultureIgnoreCase))
                    {
                        
                        try {
                        oldFileName.Delete();
                        Logger.Instance.WriteLog("Delete Duplicate " + oldFileName.FullName);
                        } catch(Exception ex) {
                            Logger.Instance.WriteLog("Failed to Delete Duplicate! " + oldFileName.FullName + "\n" + ex.Message + "\n" + ex.StackTrace);
                        }
                        continue;
                    }
                    else if (item.NewFileName.Equals("Duplicate!", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Logger.Instance.WriteLog("Skip Duplicate " + oldFileName.FullName);
                        continue;
                    }
                    else if (chkDeleteUnwantedFiles.Checked && item.NewFileName.Equals("Unwanted!", StringComparison.InvariantCultureIgnoreCase))
                    {
                        try
                        {
                            oldFileName.Delete();
                            Logger.Instance.WriteLog("Delete Unwanted " + oldFileName.FullName);
                        }
                        catch (Exception ex)
                        {
                            Logger.Instance.WriteLog("Failed to Delete Unwanted! " + oldFileName.FullName + "\n" + ex.Message + "\n" + ex.StackTrace);
                        }

                        continue;
                    }
                    else if (item.NewFileName.Equals("Unwanted!", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Logger.Instance.WriteLog("Skip Unwanted " + oldFileName.FullName);
                        continue;
                    }
                    else if (item.OrigFileName.Equals("Missing!", StringComparison.InvariantCultureIgnoreCase) ||
                            item.NewFileName.Equals("Missing!", StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (chkMakeMissingPlaceholder.Checked)
                        {
                            FileInfo missingFi = new FileInfo(RootPath + Path.DirectorySeparatorChar + item.NewFileName + ".missing");

                            if (!Directory.Exists(missingFi.Directory.FullName))
                                Directory.CreateDirectory(missingFi.Directory.FullName);

                            //string dir = (path.Attributes & FileAttributes.Directory) == FileAttributes.Directory ? path.FullName : path.Directory.FullName;
                            if (!item.NewFileName.Equals("Missing!", StringComparison.InvariantCultureIgnoreCase))
                            {
                                try
                                {
                                    File.Create(missingFi.FullName);
                                    Logger.Instance.WriteLog("Create Missing placeholder " + missingFi.FullName);
                                }
                                catch (Exception ex)
                                {
                                    Logger.Instance.WriteLog("Failed to Create Missing placeholder! " + missingFi.FullName + "\n" + ex.Message + "\n" + ex.StackTrace);
                                }
                            }

                        }
                        //oldFileName.Delete();
                        continue;
                    }

                    if (item.NewFileName.Contains(Path.DirectorySeparatorChar))
                        newFileName = new FileInfo(RootPath + Path.DirectorySeparatorChar + item.NewFileName);
                    else
                        newFileName = new FileInfo(item.Path + Path.DirectorySeparatorChar + item.NewFileName);

                    if (newFileName.Extension == "")
                        newFileName = new FileInfo(newFileName.FullName + oldFileName.Extension);

                    if (!Directory.Exists(newFileName.Directory.FullName))
                        Directory.CreateDirectory(newFileName.Directory.FullName);

                    if (File.Exists(newFileName.FullName))
                    {
                        switch( MessageBox.Show(newFileName.FullName + " already exists!\nOverwrite?", "File Confict!", MessageBoxButtons.YesNoCancel))
                        {
                            case DialogResult.Yes:
                                 try
                                {
                                    File.Delete(newFileName.FullName);
                                    Logger.Instance.WriteLog("Overwrite " + newFileName.FullName);
                                }
                                catch (Exception ex)
                                {
                                    Logger.Instance.WriteLog("Failed to Overwrite! " + newFileName.FullName + "\n" + ex.Message + "\n" + ex.StackTrace);
                                }
                                break;
                            case DialogResult.No:
                                continue;
                            case DialogResult.Cancel:
                                return;
                        }
                    }

                    string fullname = oldFileName.FullName;
                    oldFileName.MoveTo(newFileName.FullName);
                    Logger.Instance.WriteLog("Renamed \"" + fullname + "\" to \"" + newFileName.FullName + "\"");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error processing " + item.OrigFileName + "\n" + ex.Message);
                    Logger.Instance.WriteLog("Unexpected Error processing " + item.OrigFileName + "!\n" + ex.Message + "\n" + ex.StackTrace);
                    continue;
                }

                if (chkRenameAccompanyingFiles.Checked)
                {
                    oldFileName = new FileInfo(item.Path + Path.DirectorySeparatorChar + item.OrigFileName);

                    string name;
                    name = oldFileName.Name.Substring(0, oldFileName.Name.Length - oldFileName.Extension.Length);

                    string newname = newFileName.Name.Substring(0, newFileName.Name.Length - newFileName.Extension.Length);

                    foreach (string file in Directory.EnumerateFiles(oldFileName.Directory.FullName, name + ".*"))
                    {
                        try
                        {
                            FileInfo fi = new FileInfo(file);
                            string ext = fi.Extension;
                            FileInfo fiAccomany = new FileInfo(item.Path + Path.DirectorySeparatorChar + newname + ext);
                            
                            if (!Directory.Exists(fiAccomany.Directory.FullName))
                                Directory.CreateDirectory(fiAccomany.Directory.FullName);

                            if (File.Exists(fiAccomany.FullName))
                            {
                                switch (MessageBox.Show(fiAccomany.FullName + " already exists!\nOverwrite?", "File Confict!", MessageBoxButtons.YesNoCancel))
                                {
                                    case DialogResult.Yes:
                                        File.Delete(fiAccomany.FullName);
                                        break;
                                    case DialogResult.No:
                                        continue;
                                    case DialogResult.Cancel:
                                        return;
                                }
                            }
                            fi.MoveTo(fiAccomany.FullName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error processing accomanying file " + item.OrigFileName + "\n" + ex.Message);
                            Logger.Instance.WriteLog("Unexpected Error processing accomanying file! " + item.OrigFileName + "!\n" + ex.Message + "\n" + ex.StackTrace);
                            continue;
                        }
                    }
                }

            }
            grdRenameData.Invalidate();

            this.Close();
            this.Dispose();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int repeat;

            if (!int.TryParse(txtRepeat.Text, out repeat))
                repeat = 1;

            for (int i = 0; i < repeat; i++)
            {

                if (grdRenameData.SelectedCells[0].RowIndex == 0)
                    return;

                if (grdRenameData.SelectedCells.Count > 0)
                {
                    DataGridViewRow above = grdRenameData.Rows[grdRenameData.SelectedCells[0].RowIndex - 1];
                    DataGridViewRow current = grdRenameData.Rows[grdRenameData.SelectedCells[0].RowIndex];
                    ListBoxRenameItem itemAbove = (ListBoxRenameItem)above.DataBoundItem;
                    ListBoxRenameItem itemCurrent = (ListBoxRenameItem)current.DataBoundItem;

                    //grdRenameData.SelectedRows[0]
                    if (grdRenameData.SelectedCells[0].OwningColumn.DataPropertyName == "OrigFileName" || grdRenameData.SelectedCells[0].OwningColumn.DataPropertyName == "Selected")
                    {
                        string tmpFilename = itemAbove.OrigFileName;
                        string tmpPath = itemAbove.Path;
                        itemAbove.OrigFileName = itemCurrent.OrigFileName;
                        itemAbove.Path = itemCurrent.Path;
                        itemCurrent.OrigFileName = tmpFilename;
                        itemCurrent.Path = tmpPath;
                    }
                    else
                    {
                        ListBoxRenameItem tmpItem = itemAbove.Copy();
                        itemAbove.EpisodeNumber = itemCurrent.EpisodeNumber;
                        itemAbove.EpisodeTitle = itemCurrent.EpisodeTitle;
                        itemAbove.NewFileName = itemCurrent.NewFileName;
                        //itemAbove.OrigFileName = itemCurrent.OrigFileName;
                        //itemAbove.Path = itemCurrent.Path;
                        itemAbove.Resolution = itemCurrent.Resolution;
                        itemAbove.Season = itemCurrent.Season;
                        itemAbove.Selected = itemCurrent.Selected;
                        itemAbove.Series = itemCurrent.Series;
                        itemAbove.Thumb = itemCurrent.Thumb;
                        itemAbove.Year = itemCurrent.Year;

                        itemCurrent.EpisodeNumber = tmpItem.EpisodeNumber;
                        itemCurrent.EpisodeTitle = tmpItem.EpisodeTitle;
                        itemCurrent.NewFileName = tmpItem.NewFileName;
                        //itemCurrent.OrigFileName = tmpItem.OrigFileName;
                        //itemCurrent.Path = tmpItem.Path;
                        itemCurrent.Resolution = tmpItem.Resolution;
                        itemCurrent.Season = tmpItem.Season;
                        itemCurrent.Selected = tmpItem.Selected;
                        itemCurrent.Series = tmpItem.Series;
                        itemCurrent.Thumb = tmpItem.Thumb;
                        itemCurrent.Year = tmpItem.Year;

                    }

                    grdRenameData.CurrentCell = grdRenameData.Rows[grdRenameData.SelectedCells[0].RowIndex - 1].Cells[grdRenameData.SelectedCells[0].OwningColumn.Name];

                    grdRenameData.Invalidate();
                    //grdRenameData.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int repeat;

            if (!int.TryParse(txtRepeat.Text, out repeat))
                repeat = 1;

            for (int i = 0; i < repeat; i++)
            {

                if (grdRenameData.SelectedCells[0].RowIndex == grdRenameData.RowCount - 1)
                    return;

                if (grdRenameData.SelectedCells.Count > 0)
                {
                    DataGridViewRow below = grdRenameData.Rows[grdRenameData.SelectedCells[0].RowIndex + 1];
                    DataGridViewRow current = grdRenameData.Rows[grdRenameData.SelectedCells[0].RowIndex];
                    ListBoxRenameItem itemBelow = (ListBoxRenameItem)below.DataBoundItem;
                    ListBoxRenameItem itemCurrent = (ListBoxRenameItem)current.DataBoundItem;

                    //grdRenameData.SelectedRows[0]
                    if (grdRenameData.SelectedCells[0].OwningColumn.DataPropertyName == "OrigFileName" || grdRenameData.SelectedCells[0].OwningColumn.DataPropertyName == "Selected")
                    {
                        string tmpFilename = itemBelow.OrigFileName;
                        string tmpPath = itemBelow.Path;
                        itemBelow.OrigFileName = itemCurrent.OrigFileName;
                        itemBelow.Path = itemCurrent.Path;
                        itemCurrent.OrigFileName = tmpFilename;
                        itemCurrent.Path = tmpPath;
                    }
                    else
                    {
                        ListBoxRenameItem tmpItem = itemBelow.Copy();
                        itemBelow.EpisodeNumber = itemCurrent.EpisodeNumber;
                        itemBelow.EpisodeTitle = itemCurrent.EpisodeTitle;
                        itemBelow.NewFileName = itemCurrent.NewFileName;
                        //itemAbove.OrigFileName = itemCurrent.OrigFileName;
                        //itemBelow.Path = itemCurrent.Path;
                        itemBelow.Resolution = itemCurrent.Resolution;
                        itemBelow.Season = itemCurrent.Season;
                        itemBelow.Selected = itemCurrent.Selected;
                        itemBelow.Series = itemCurrent.Series;
                        itemBelow.Thumb = itemCurrent.Thumb;
                        itemBelow.Year = itemCurrent.Year;

                        itemCurrent.EpisodeNumber = tmpItem.EpisodeNumber;
                        itemCurrent.EpisodeTitle = tmpItem.EpisodeTitle;
                        itemCurrent.NewFileName = tmpItem.NewFileName;
                        //itemCurrent.OrigFileName = tmpItem.OrigFileName;
                        //itemCurrent.Path = tmpItem.Path;
                        itemCurrent.Resolution = tmpItem.Resolution;
                        itemCurrent.Season = tmpItem.Season;
                        itemCurrent.Selected = tmpItem.Selected;
                        itemCurrent.Series = tmpItem.Series;
                        itemCurrent.Thumb = tmpItem.Thumb;
                        itemCurrent.Year = tmpItem.Year;

                    }

                    grdRenameData.CurrentCell = grdRenameData.Rows[grdRenameData.SelectedCells[0].RowIndex + 1].Cells[grdRenameData.SelectedCells[0].OwningColumn.Name];

                    grdRenameData.Invalidate();
                    //grdRenameData.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        private void chkDeleteDups_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.DeleteDuplicates = chkDeleteDups.Checked;
        }

        private void chkRenameAccompanyingFiles_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.RenameMatchingAccompanyingFiles = chkRenameAccompanyingFiles.Checked;
        }

        private void chkDeleteUnwantedFiles_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.DeleteUnwantedFiles = chkDeleteUnwantedFiles.Checked;
        }

        private void chkMakeMissingPlaceholder_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.MakeMissingPlaceholder = chkMakeMissingPlaceholder.Checked;
        }
        
        private void txtRepeat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }


    public class ListBoxItem
    {
        public SeriesSearchResult SearchResult { get; set; }

        public ListBoxItem(SeriesSearchResult result)
        {
            SearchResult = result;
        }

        public override string ToString()
        {
            if (SearchResult != null)
                return SearchResult.SeriesName;
            else
                return "";
        }
    }

    public class ListBoxRenameItem
    {
        public bool Selected { get; set; } = true;
        public string Path { get; set; }
        public string OrigFileName { get; set; }
        public string NewFileName { get; set; }
        public string Series { get; set; }
        public string Season { get; set; }
        public string EpisodeTitle { get; set; }
        public string EpisodeNumber { get; set; }
        public string Year { get; set; }
        public string Resolution { get; set; }
        public Image Thumb { get; set; }

        public ListBoxRenameItem(string path, string oldname, string newname, string series, string season, string eptitle, string epnum, string year, string res, string img)
        {
            Path = path;
            OrigFileName = oldname;
            NewFileName = newname;
            Series = series;
            Season = season;
            EpisodeTitle = eptitle;
            EpisodeNumber = epnum;
            Year = year;
            Resolution = res;
            //Thumb = img;
        }

        internal ListBoxRenameItem Copy()
        {
            ListBoxRenameItem theCopy = new ListBoxRenameItem(String.Copy(Path), String.Copy(OrigFileName), String.Copy(NewFileName), String.Copy(Series), String.Copy(Season), String.Copy(EpisodeTitle), String.Copy(EpisodeNumber), String.Copy(Year), String.Copy(Resolution), null);
            return theCopy;
        }
    }
}
