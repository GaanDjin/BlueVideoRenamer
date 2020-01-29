using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections;
using BrightIdeasSoftware;

namespace Blue_Video_Renamer
{
    /// <summary>
    /// Initial window and file browser to select the series to rename. 
    /// 
    /// TODO: Bind the left hand pane to the file list view so it'll auto expand to selected folder on right hand pane.
    /// </summary>
    public partial class TagAndRenameVideos : Form
    {
        /// <summary>
        /// 
        /// </summary>
        bool _restart;

        public TagAndRenameVideos()
        {
            InitializeComponent();
        }

        private void TagAndRenameVideos_Load(object sender, EventArgs e)
        {
            InitRootTree();
            InitObjectListViewFilesAndTags();
            NavigateTree();

            VideoInformation.ThetvDB = new TheTVDB_API_v2.TheTVDB();

            Task<bool> t;

            if (Configuration.TheTVDBApiKey != null && Configuration.TheTVDBApiKey.Trim().Length > 0)
            {
                t = VideoInformation.ThetvDB.AuthenticateAsync(Configuration.TheTVDBApiKey);

            }
            else
            {
                FrmSettings settings = new FrmSettings();
                settings.SelectTheTVDBApiKey();
                settings.ShowDialog();
                t = VideoInformation.ThetvDB.AuthenticateAsync(Configuration.TheTVDBApiKey);
                //t = VideoInformation.ThetvDB.AuthenticateAsync(apiKey);
            }
            
            t.GetAwaiter().OnCompleted(() => {
                if (!t.Result)
                {
                    //t = tvDB.AuthenticateAsync(apiKey);
                    MessageBox.Show("Failed to Authenticate to the TV DB!\nPlease check your API Key settings.");
                }
            });
            
        }

        /// <summary>
        /// Navigates to the last selected folder.
        /// </summary>
        private void NavigateTree()
        {
            string lastPath = Configuration.LastRootPath;

            if (lastPath != null)
            {
                string[] lastpathparts = lastPath.Split(new char[] { Path.DirectorySeparatorChar });

                ListViewItem item = this.treeListViewRootPath.FindItemWithText(lastpathparts[0], false, 0);

                if (item != null)
                {
                    TreeListView.Branch branch = treeListViewRootPath.TreeModel.GetBranch(treeListViewRootPath.GetModelObject(item.Index));
                    treeListViewRootPath.Expand(branch.Model);
                    for (int X = 1; X <= lastpathparts.Length - 1; X++)
                    {
                        int newModelChild = -1;
                        for (int child = 0; child <= branch.ChildBranches.Count - 1; child++)
                        {
                            if (((MyFileSystemInfo)branch.ChildBranches[child].Model).Name == lastpathparts[X])
                            {
                                treeListViewRootPath.Expand(branch.ChildBranches[child].Model); //*Expand this branch/child
                                newModelChild = child; //*Gives place in ArrayList that is the branch-directory that was just expanded
                                
                                treeListViewRootPath.SelectedObject = branch.ChildBranches[child].Model; //Select the folders as we go down.
                                break;
                            }
                        }
                        if (newModelChild == -1)
                            break;
                        branch = treeListViewRootPath.TreeModel.GetBranch(branch.ChildBranches[newModelChild].Model); //*New branch to go into loop with
                    }
                }
            }
        }

        private void InitRootTree()
        {
            this.treeListViewRootPath.CanExpandGetter = delegate (object x) {
                return ((MyFileSystemInfo)x).IsDirectory;
            };
            //Only ever called if CanExpandGetter is a DirectoryInfo.
            this.treeListViewRootPath.ChildrenGetter = delegate (object x) {
                try
                {
                    return ((MyFileSystemInfo)x).GetFileSystemInfos(FileAttributes.Directory);
                }
                catch (UnauthorizedAccessException ex)
                {
                    this.BeginInvoke((MethodInvoker)delegate () {
                        this.treeListViewRootPath.Collapse(x);
                        MessageBox.Show(this, ex.Message, "ObjectListViewDemo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    });
                    return new ArrayList();
                }
            };

            //.
            SysImageListHelper helper = new SysImageListHelper(this.treeListViewRootPath);
            this.colPathRoot.ImageGetter = delegate (object x) {
                return helper.GetImageIndex(((MyFileSystemInfo)x).FullName);
            };
            this.colPathRoot.AspectGetter = delegate (object x) {
                return ((MyFileSystemInfo)x).Name;
            };


            ArrayList roots = new ArrayList();
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                if (di.IsReady)
                    roots.Add(new MyFileSystemInfo(new DirectoryInfo(di.Name)));
            }
            this.treeListViewRootPath.Roots = roots;

            
        }

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
                if (x == null)
                    return null;
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
                if (x == null)
                    return "";

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
                if (x == null)
                    return "";

                long sizeInBytes = (long)x;
                if (sizeInBytes < 0) // folder or error
                    return "";
                return HelperFunctions.FormatFileSize(sizeInBytes);
            };

            // Show the system description for this object
            this.colFormat.AspectGetter = delegate (object x) {
                if (x == null)
                    return "";

                return ShellUtilities.GetFileType(((MyFileSystemInfo)x).FullName);
            };

            //this.colSeries.AspectGetter = delegate (object x) {
            //    return VideoInformation.Series((MyFileSystemInfo)x);
            //};
            //this.colSeason.AspectGetter = delegate (object x) {
            //    return VideoInformation.Season((MyFileSystemInfo)x);
            //};
            //this.colEpisodeNumber.AspectGetter = delegate (object x) {
            //    return VideoInformation.EpisodeNumber((MyFileSystemInfo)x);
            //};
            //this.colEpisodeTitle.AspectGetter = delegate (object x) {
            //    return VideoInformation.EpisodeTitle((MyFileSystemInfo)x);
            //};
            //this.colResolution.AspectGetter = delegate (object x) {
            //    return VideoInformation.Resolution((MyFileSystemInfo)x);
            //};
            //this.colYear.AspectGetter = delegate (object x) {
            //    return VideoInformation.Year((MyFileSystemInfo)x);
            //};
            //this.colThumb.AspectGetter = delegate (object x) {
            //    return VideoInformation.Thumb((MyFileSystemInfo)x);
            //};


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

            this.colPath.AspectGetter = delegate (object x) {
                if (x != null)
                    return ((MyFileSystemInfo)x).FullName;
                else
                    return "";
            };

        }


        //private void PopulateTreeVeiwWithfoldersAndfiles(string path)
        //{
        //    //objectListViewFilesAndTags

        //    if (bgWkrPopulateFolderView.IsBusy)
        //    {
        //        bgWkrPopulateFolderView.CancelAsync();
        //        _restart = true;
        //    }

        //    if (bgWkrPopulateFolderView.IsBusy != true)
        //    {
        //        // Start the asynchronous operation.
        //        bgWkrPopulateFolderView.RunWorkerAsync();
        //    }
        //}

        private void bgWkrPopulateFolderView_DoWork(object sender, DoWorkEventArgs e)
        {
            treeListViewFilesAndTags.ClearObjects();

            if (bgWkrPopulateFolderView.CancellationPending)
            {
                e.Cancel = true;
                //break;
            }
            _restart = false;
        }

        private void bgWkrPopulateFolderView_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_restart)
            {
                bgWkrPopulateFolderView.RunWorkerAsync();
                _restart = false;
            }
        }

        private void treeListViewFilesAndTags_ItemActivate(object sender, EventArgs e)
        {
            Object model = this.treeListViewFilesAndTags.SelectedObject;
            if (model != null)
                this.treeListViewFilesAndTags.ToggleExpansion(model);
        }

        private void treeListViewRootPath_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void treeListViewRootPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList roots = new ArrayList();

            OLVListItem selectedItem = ((TreeListView)sender).SelectedItem;
            if (selectedItem != null && selectedItem.RowObject != null)
            {
                MyFileSystemInfo dir = ((MyFileSystemInfo)((TreeListView)sender).SelectedItem.RowObject);
                Configuration.LastRootPath = dir.FullName;
                foreach (MyFileSystemInfo subdir in dir.GetFileSystemInfos())
                {
                    if (subdir.IsDirectory || Configuration.IsValidVideo(subdir.Name))
                        roots.Add(subdir);
                }
            }
            this.treeListViewFilesAndTags.Roots = roots;
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            FrmLookup lookupForm = null;

            List<string> paths = new List<string>();
            string root = null;

            if (treeListViewRootPath.SelectedObject == null && treeListViewFilesAndTags.SelectedObjects.Count == 0)
            {
                MessageBox.Show("No root path selected!");
                return;
            }

            foreach (object obj in treeListViewFilesAndTags.SelectedObjects)
            {
                paths.Add(((MyFileSystemInfo)obj).FullName);
            }

            if (paths.Count == 0)
            {
                MessageBox.Show("Nothing Selected!");
                return;

            }

            FileInfo fi = new FileInfo(paths[0]);
            if ((fi.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                root = fi.FullName;
            else
                root = fi.Directory.FullName;

            lookupForm = new FrmLookup(root, paths);
            lookupForm.ShowDialog();

            //treeListViewRootPath_SelectedIndexChanged(treeListViewRootPath, null);
            treeListViewFilesAndTags.Invalidate();
            treeListViewFilesAndTags.RebuildAll(true);

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FrmSettings settings = new FrmSettings();
            settings.SelectTheTVDBApiKey();
            settings.ShowDialog();

            Task<bool> t;
            t = VideoInformation.ThetvDB.AuthenticateAsync(Configuration.TheTVDBApiKey);

            t.GetAwaiter().OnCompleted(() =>
            {
                if (!t.Result)
                {
                    //t = tvDB.AuthenticateAsync(apiKey);
                    MessageBox.Show("Failed to Authenticate to the TV DB!\nPlease check your API Key settings.");
                }
            });
        }
    }
}
