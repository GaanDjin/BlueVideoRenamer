using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blue_Video_Renamer
{
    public partial class FrmSettings : Form
    {
        bool isDirty = false;
        bool isLoading = true;
        private bool focusOnTheTVDBApiKey;

        private BindingSource bsGrdRenameFormats = new BindingSource();
        private BindingSource bsGrdVideoFileExtensions = new BindingSource();
        private BindingSource bsGrdUnwantedFiles = new BindingSource();
        private BindingSource bsGrdReplaceChars = new BindingSource();

        #region Setup Grid Views
        void SetupGrdRenameFormats()
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Value";
            column.Name = "Rename Tmplate";
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdRenameFormats.Columns.Add(column);

            grdRenameFormats.AutoGenerateColumns = false;
            grdRenameFormats.DataSource = bsGrdRenameFormats;

            foreach(string val in Configuration.RenameFormats)
            {
                GridViewItem item = new GridViewItem();
                item.Value = val;
                bsGrdRenameFormats.Add(item);
            }
        }

        void SetupGrdVideoFileExtensions()
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Value";
            column.Name = "Video File Extentions";
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdVideoFileExtensions.Columns.Add(column);

            grdVideoFileExtensions.AutoGenerateColumns = false;
            grdVideoFileExtensions.DataSource = bsGrdVideoFileExtensions;
            
            foreach (string val in Configuration.VideoFileExtensions)
            {
                GridViewItem item = new GridViewItem();
                item.Value = val;
                bsGrdVideoFileExtensions.Add(item);
            }

        }

        void SetupGrdUnwantedFiles()
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Value";
            column.Name = "Unwanted Files";
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdUnwantedFiles.Columns.Add(column);

            grdUnwantedFiles.AutoGenerateColumns = false;
            grdUnwantedFiles.DataSource = bsGrdUnwantedFiles;
            
            foreach (string val in Configuration.UnwantedFiles)
            {
                GridViewItem item = new GridViewItem();
                item.Value = val;
                bsGrdUnwantedFiles.Add(item);
            }

        }

        void SetupGrdReplaceChars()
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "OldValue";
            column.Name = "Old Value";
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdReplaceChars.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Value";
            column.Name = "New Value";
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdReplaceChars.Columns.Add(column);

            grdReplaceChars.AutoGenerateColumns = false;
            grdReplaceChars.DataSource = bsGrdReplaceChars;
            
            foreach (KeyValuePair<string, string> val in Configuration.ReplaceChars)
            {
                GridViewItem item = new GridViewItem();
                item.OldValue = val.Key;
                item.Value = val.Value;
                bsGrdReplaceChars.Add(item);
            }
        }
        #endregion

        public FrmSettings()
        {
            InitializeComponent();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            chkDeleteDuplicates.Checked = Configuration.DeleteDuplicates;
            chkDeleteUnwantedFiles.Checked = Configuration.DeleteUnwantedFiles;
            chkMakeMissingPlaceholder.Checked = Configuration.MakeMissingPlaceholder;
            chkRenameMatchingAccompanyingFiles.Checked = Configuration.RenameMatchingAccompanyingFiles;
            txtInvalidCharReplacement.Text = "" + Configuration.InvalidCharReplacement;

            txtEpisodeDateFormat.Text = Configuration.EpisodeDateFormat;
            txtSeriesDateFormat.Text = Configuration.SeriesDateFormat;
            txtLastRootPath.Text = Configuration.LastRootPath;
            txtTheTVDBApiKey.Text = Configuration.TheTVDBApiKey;

            //grdRenameFormats =  Configuration.RenameFormats;
            //grdReplaceChars =  Configuration.ReplaceChars;
            //grdUnwantedFiles   = Configuration.UnwantedFiles;
            //grdVideoFileExtensions = Configuration.VideoFileExtensions;

            SetupGrdRenameFormats();
            SetupGrdVideoFileExtensions();
            SetupGrdUnwantedFiles();
            SetupGrdReplaceChars();

            isLoading = false;
            FormClosing += FrmSettings_FormClosing;

            if (!File.Exists(Configuration.SavePath))
                isDirty = true;
        }

        private void FrmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDirty)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Save?", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    btnOK_Click(sender, e);
                    if (isDirty)
                        e.Cancel = true;
                }
                else
                {
                }
            }
        }

        #region Settings have changed so we should check before closed if isDirty and should be saved. 

        private void txtSeriesDateFormat_TextChanged(object sender, EventArgs e)
        {
            if (txtSeriesDateFormat.Text.Length > 0)
            {
                try {
                    lblSeriesDateExample.Text = "Example: " + DateTime.Now.ToString(txtSeriesDateFormat.Text);

                    if(!isLoading)
                        isDirty = true;
                } catch (FormatException) { lblSeriesDateExample.Text = "Invalid Date Format"; }
                
            }
        }

        private void txtEpisodeDateFormat_TextChanged(object sender, EventArgs e)
        {
            if (txtEpisodeDateFormat.Text.Length > 0)
            {
                try
                {
                    lblEpisodeDateExample.Text = "Example: " + DateTime.Now.ToString(txtEpisodeDateFormat.Text);
                    if (!isLoading)
                        isDirty = true;
                }
                catch (FormatException) { lblEpisodeDateExample.Text = "Invalid Date Format"; }
            }
        }
        
        private void txtInvalidCharReplacement_TextChanged(object sender, EventArgs e)
        {
            if (txtInvalidCharReplacement.Text.Length > 0)
            {
                char c = txtInvalidCharReplacement.Text[0];

                if (c == '*' || c == '?')
                {
                    MessageBox.Show("I'm sorry but " + c + " is not allowed in filenames");
                    txtInvalidCharReplacement.Text = "_";
                }
                else if (Path.GetInvalidPathChars().Contains(c))
                {
                    MessageBox.Show("I'm sorry but " + c + " is not allowed in filenames");
                    txtInvalidCharReplacement.Text = "_";
                }
                else if (Path.GetInvalidFileNameChars().Contains(c))
                {
                    MessageBox.Show("I'm sorry but " + c + " is not allowed in filenames");
                    txtInvalidCharReplacement.Text = "_";
                }
                else
                {
                    if (!isLoading)
                        isDirty = true;
                   // Configuration.InvalidCharReplacement = c;
                }
            }

        }

        private void chkRenameMatchingAccompanyingFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
                isDirty = true;
            //Configuration.RenameMatchingAccompanyingFiles = chkRenameMatchingAccompanyingFiles.Checked;
        }

        private void chkDeleteDuplicates_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
                isDirty = true;
        }

        private void chkDeleteUnwantedFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
                isDirty = true;
        }

        private void chkMakeMissingPlaceholder_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoading)
                isDirty = true;
        }

        private void txtTheTVDBApiKey_TextChanged(object sender, EventArgs e)
        {
            if (!isLoading)
                isDirty = true;
        }

        private void grdRenameFormats_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isLoading)
                isDirty = true;
        }

        private void grdVideoFileExtensions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isLoading)
                isDirty = true;
        }

        private void grdUnwantedFiles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isLoading)
                isDirty = true;
        }

        private void grdReplaceChars_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isLoading)
                isDirty = true;
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isDirty)
            {
                if (bsGrdRenameFormats.Count == 0)
                {
                    tabRenameTemplates.Select();
                    MessageBox.Show("Invalid Rename Template. Cannot be empty and must contain at least one template value. Also note the templates are case sensitive!");
                    grdRenameFormats.Focus();
                    //grdRenameFormats.CurrentCell = grdRenameFormats.Rows[i].Cells[0];
                    return;
                }


                int i = 0;
                foreach (GridViewItem item in bsGrdRenameFormats)
                {
                    if (item.Value.Trim().Length == 0 || !IsValidTemplate(item.Value))
                    {
                        tabRenameTemplates.Select();
                        MessageBox.Show("Invalid Rename Template. Cannot be empty and must contain at least one template value. Also note the templates are case sensitive!");
                        grdRenameFormats.Focus();
                        grdRenameFormats.CurrentCell = grdRenameFormats.Rows[i].Cells[0];
                        return;

                    }
                    i++;
                }

                if (bsGrdVideoFileExtensions.Count == 0)
                {
                    tabViedoFiles.Select();
                    MessageBox.Show("No Video file types! If you're meaning all files then please use:\n.+");
                    grdVideoFileExtensions.Focus();
                    //grdVideoFileExtensions.CurrentCell = grdVideoFileExtensions.Rows[i].Cells[0];
                    return;

                }
                i = 0;
                foreach (GridViewItem item in bsGrdVideoFileExtensions)
                {
                    if (!HelperFunctions.IsValidRegex(item.Value))
                    {

                        tabViedoFiles.Select();
                        MessageBox.Show("Invalid Regex value in Video Files!");
                        grdVideoFileExtensions.Focus();
                        grdVideoFileExtensions.CurrentCell = grdVideoFileExtensions.Rows[i].Cells[0];
                        return;

                    }
                    i++;
                }

                if (bsGrdUnwantedFiles.Count > 0)
                {
                    i = 0;
                    foreach (GridViewItem item in bsGrdUnwantedFiles)
                    {
                        if (!HelperFunctions.IsValidRegex(item.Value))
                        {

                            tabRenameTemplates.Select();
                            MessageBox.Show("Invalid Rexex value in Unwanted Files!");
                            grdRenameFormats.Focus();
                            grdRenameFormats.CurrentCell = grdRenameFormats.Rows[i].Cells[0];
                            return;

                        }
                        i++;
                    }

                }

                if (txtInvalidCharReplacement.Text.Length == 0)
                {
                    DialogResult result = MessageBox.Show("Missing Invalid Char Replacement.\nUse default? '_'", "Save?", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                        txtInvalidCharReplacement.Text = "_";
                    else
                    {
                        return;
                    }
                }


                if (lblEpisodeDateExample.Text.Equals("Invalid Date Format"))
                {
                    tabDateFormats.Select();
                    MessageBox.Show("Invalid Episode date format!");
                    txtEpisodeDateFormat.Focus();
                    return;
                }

                if (lblSeriesDateExample.Text.Equals("Invalid Date Format"))
                {
                    tabDateFormats.Select();
                    MessageBox.Show("Invalid Series date format!");
                    txtSeriesDateFormat.Focus();
                    return;
                }

                TheTVDB_API_v2.TheTVDB newApiKey = null;
                if (txtTheTVDBApiKey.Text.Trim().Length > 0)
                {
                    newApiKey = new TheTVDB_API_v2.TheTVDB();

                    if (!(Task.Run(async () => { return await newApiKey.AuthenticateAsync(txtTheTVDBApiKey.Text.Trim()); }).Result))
                    {
                        tabTheTVDB.Select();
                        MessageBox.Show("Invalid API Key! Unable to authenticate!\n" + newApiKey.LastError);
                        txtTheTVDBApiKey.Focus();
                        return;
                    }
                }
                else
                {
                    tabTheTVDB.Select();
                    MessageBox.Show("The TV DB API Key is empty! Unable to authenticate!");
                    txtTheTVDBApiKey.Focus();
                    return;

                    //newApiKey = new TheTVDB_API_v2.TheTVDB();

                    //if (!(Task.Run(async () => { return await newApiKey.AuthenticateAsync(Configuration.TheTVDBApiKey); }).Result))
                    //{
                    //    tabTheTVDB.Select();
                    //    DialogResult result = MessageBox.Show("Unable to authenticate using internal API Key!\n" + newApiKey.LastError + "\nSave anyway?", "", MessageBoxButtons.YesNo);

                    //    if (result == DialogResult.No)
                    //    {
                    //        txtTheTVDBApiKey.Focus();
                    //        return;
                    //    }
                    //}
                }

                List<string> renameFormats = new List<string>();
                List<string> videoFileExtensions = new List<string>();
                List<string> unwantedFiles = new List<string>();
                Dictionary<string, string> replaceChars = new Dictionary<string, string>();

                foreach (GridViewItem item in bsGrdRenameFormats)
                {
                    if (item.Value.Trim().Length > 0)
                        renameFormats.Add(item.Value);
                }

                foreach (GridViewItem item in bsGrdVideoFileExtensions)
                {
                    if (item.Value.Trim().Length > 0)
                        videoFileExtensions.Add(item.Value);
                }

                foreach (GridViewItem item in bsGrdUnwantedFiles)
                {
                    if (item.Value.Trim().Length > 0)
                        unwantedFiles.Add(item.Value);
                }

                foreach (GridViewItem item in bsGrdReplaceChars)
                {
                    if (item.OldValue.Trim().Length > 0)
                        replaceChars.Add(item.OldValue, item.Value);
                }


                // txtLastRootPath.Text = Configuration.LastRootPath;
                if (txtTheTVDBApiKey.Text.Trim().Length > 0)
                {
                    Configuration.TheTVDBApiKey = txtTheTVDBApiKey.Text.Trim();
                }
                else
                    Configuration.TheTVDBApiKey = null;

                if (newApiKey.Token != null && newApiKey.Token.Length > 0)
                {
                    VideoInformation.ThetvDB = newApiKey;
                }

                Configuration.DeleteDuplicates = chkDeleteDuplicates.Checked;
                Configuration.DeleteUnwantedFiles = chkDeleteUnwantedFiles.Checked;
                Configuration.MakeMissingPlaceholder = chkMakeMissingPlaceholder.Checked;
                Configuration.RenameMatchingAccompanyingFiles = chkRenameMatchingAccompanyingFiles.Checked;
                Configuration.InvalidCharReplacement = txtInvalidCharReplacement.Text[0];
                Configuration.EpisodeDateFormat = txtEpisodeDateFormat.Text.Trim();
                Configuration.SeriesDateFormat = txtSeriesDateFormat.Text.Trim();

                Configuration.RenameFormats = renameFormats.ToArray();
                Configuration.VideoFileExtensions = videoFileExtensions.ToArray();
                Configuration.UnwantedFiles = unwantedFiles.ToArray();
                Configuration.ReplaceChars = replaceChars;

                isDirty = false;

                Configuration.Instance.Save();

                this.Close();
                this.Dispose();
            }
            else
            {
                //DialogResult result = MessageBox.Show("No changes detected. Close Anyway?", "No Changes Made", MessageBoxButtons.YesNo);

                //if (result == DialogResult.Yes)
                //{
                    this.Close();
                    this.Dispose();
                //}
            }
        }

        internal void SelectTheTVDBApiKey()
        {
            focusOnTheTVDBApiKey = true;
        }

        private bool IsValidTemplate(string value)
        {
           foreach (string val in Configuration.RenameFormatValues)
            {
                if (value.Contains(val))
                {
                    return true;
                }
            }
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (isDirty)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Save?", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Cancel)
                    return;
                else if (result == DialogResult.Yes)
                    btnOK_Click(sender, e);
                else
                {
                    isDirty = false;
                    this.Close();
                    this.Dispose();
                }
            }
            else
            {
                isDirty = false;
                this.Close();
                this.Dispose();
            }
        }

        private void FrmSettings_Shown(object sender, EventArgs e)
        {

            if (focusOnTheTVDBApiKey)
            {
                tabTheTVDB.Select();
                tabControlOptions.SelectedTab = tabTheTVDB;
                //this.ActiveControl = tabTheTVDB;
                txtTheTVDBApiKey.Focus();
                this.ActiveControl = txtTheTVDBApiKey;
            }
        }
    }


    public class GridViewItem
    {
        public string OldValue { get; set; }
        public string Value { get; set; }
    }
}
