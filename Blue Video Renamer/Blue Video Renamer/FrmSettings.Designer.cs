namespace Blue_Video_Renamer
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.lblInvalidCharReplacement = new System.Windows.Forms.Label();
            this.txtInvalidCharReplacement = new System.Windows.Forms.TextBox();
            this.chkRenameMatchingAccompanyingFiles = new System.Windows.Forms.CheckBox();
            this.chkMakeMissingPlaceholder = new System.Windows.Forms.CheckBox();
            this.chkDeleteUnwantedFiles = new System.Windows.Forms.CheckBox();
            this.chkDeleteDuplicates = new System.Windows.Forms.CheckBox();
            this.tabDateFormats = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblEpisodeDateExample = new System.Windows.Forms.Label();
            this.lblSeriesDateExample = new System.Windows.Forms.Label();
            this.txtEpisodeDateFormat = new System.Windows.Forms.TextBox();
            this.txtSeriesDateFormat = new System.Windows.Forms.TextBox();
            this.lblEpisodeDateFormat = new System.Windows.Forms.Label();
            this.lblSeriesDateFormat = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabTheTVDB = new System.Windows.Forms.TabPage();
            this.lblTheTVDBApiKey = new System.Windows.Forms.Label();
            this.txtTheTVDBApiKey = new System.Windows.Forms.TextBox();
            this.tabRenameTemplates = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.grdRenameFormats = new System.Windows.Forms.DataGridView();
            this.tabViedoFiles = new System.Windows.Forms.TabPage();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.grdVideoFileExtensions = new System.Windows.Forms.DataGridView();
            this.tabUnwantedFilesAndChars = new System.Windows.Forms.TabPage();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.pnlUnwantedFiles = new System.Windows.Forms.Panel();
            this.grdUnwantedFiles = new System.Windows.Forms.DataGridView();
            this.tabReplaceStrings = new System.Windows.Forms.TabPage();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.grdReplaceChars = new System.Windows.Forms.DataGridView();
            this.tabMisc = new System.Windows.Forms.TabPage();
            this.lblLastRootPath = new System.Windows.Forms.Label();
            this.txtLastRootPath = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControlOptions.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabDateFormats.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabTheTVDB.SuspendLayout();
            this.tabRenameTemplates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRenameFormats)).BeginInit();
            this.tabViedoFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVideoFileExtensions)).BeginInit();
            this.tabUnwantedFilesAndChars.SuspendLayout();
            this.pnlUnwantedFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnwantedFiles)).BeginInit();
            this.tabReplaceStrings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReplaceChars)).BeginInit();
            this.tabMisc.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Controls.Add(this.tabGeneral);
            this.tabControlOptions.Controls.Add(this.tabDateFormats);
            this.tabControlOptions.Controls.Add(this.tabTheTVDB);
            this.tabControlOptions.Controls.Add(this.tabRenameTemplates);
            this.tabControlOptions.Controls.Add(this.tabViedoFiles);
            this.tabControlOptions.Controls.Add(this.tabUnwantedFilesAndChars);
            this.tabControlOptions.Controls.Add(this.tabReplaceStrings);
            this.tabControlOptions.Controls.Add(this.tabMisc);
            this.tabControlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlOptions.Location = new System.Drawing.Point(0, 0);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(1132, 398);
            this.tabControlOptions.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.lblInvalidCharReplacement);
            this.tabGeneral.Controls.Add(this.txtInvalidCharReplacement);
            this.tabGeneral.Controls.Add(this.chkRenameMatchingAccompanyingFiles);
            this.tabGeneral.Controls.Add(this.chkMakeMissingPlaceholder);
            this.tabGeneral.Controls.Add(this.chkDeleteUnwantedFiles);
            this.tabGeneral.Controls.Add(this.chkDeleteDuplicates);
            this.tabGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(1124, 369);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // lblInvalidCharReplacement
            // 
            this.lblInvalidCharReplacement.AutoSize = true;
            this.lblInvalidCharReplacement.Location = new System.Drawing.Point(36, 117);
            this.lblInvalidCharReplacement.Name = "lblInvalidCharReplacement";
            this.lblInvalidCharReplacement.Size = new System.Drawing.Size(169, 17);
            this.lblInvalidCharReplacement.TabIndex = 2;
            this.lblInvalidCharReplacement.Text = "Invalid Char Replacement";
            // 
            // txtInvalidCharReplacement
            // 
            this.txtInvalidCharReplacement.Location = new System.Drawing.Point(8, 114);
            this.txtInvalidCharReplacement.MaxLength = 1;
            this.txtInvalidCharReplacement.Name = "txtInvalidCharReplacement";
            this.txtInvalidCharReplacement.Size = new System.Drawing.Size(22, 22);
            this.txtInvalidCharReplacement.TabIndex = 1;
            this.txtInvalidCharReplacement.TextChanged += new System.EventHandler(this.txtInvalidCharReplacement_TextChanged);
            // 
            // chkRenameMatchingAccompanyingFiles
            // 
            this.chkRenameMatchingAccompanyingFiles.AutoSize = true;
            this.chkRenameMatchingAccompanyingFiles.Location = new System.Drawing.Point(8, 87);
            this.chkRenameMatchingAccompanyingFiles.Name = "chkRenameMatchingAccompanyingFiles";
            this.chkRenameMatchingAccompanyingFiles.Size = new System.Drawing.Size(273, 21);
            this.chkRenameMatchingAccompanyingFiles.TabIndex = 0;
            this.chkRenameMatchingAccompanyingFiles.Text = "Rename Matching Accompanying Files";
            this.chkRenameMatchingAccompanyingFiles.UseVisualStyleBackColor = true;
            this.chkRenameMatchingAccompanyingFiles.CheckedChanged += new System.EventHandler(this.chkRenameMatchingAccompanyingFiles_CheckedChanged);
            // 
            // chkMakeMissingPlaceholder
            // 
            this.chkMakeMissingPlaceholder.AutoSize = true;
            this.chkMakeMissingPlaceholder.Location = new System.Drawing.Point(8, 60);
            this.chkMakeMissingPlaceholder.Name = "chkMakeMissingPlaceholder";
            this.chkMakeMissingPlaceholder.Size = new System.Drawing.Size(194, 21);
            this.chkMakeMissingPlaceholder.TabIndex = 0;
            this.chkMakeMissingPlaceholder.Text = "Make Missing Placeholder";
            this.chkMakeMissingPlaceholder.UseVisualStyleBackColor = true;
            this.chkMakeMissingPlaceholder.CheckedChanged += new System.EventHandler(this.chkMakeMissingPlaceholder_CheckedChanged);
            // 
            // chkDeleteUnwantedFiles
            // 
            this.chkDeleteUnwantedFiles.AutoSize = true;
            this.chkDeleteUnwantedFiles.Location = new System.Drawing.Point(8, 33);
            this.chkDeleteUnwantedFiles.Name = "chkDeleteUnwantedFiles";
            this.chkDeleteUnwantedFiles.Size = new System.Drawing.Size(171, 21);
            this.chkDeleteUnwantedFiles.TabIndex = 0;
            this.chkDeleteUnwantedFiles.Text = "Delete Unwanted Files";
            this.chkDeleteUnwantedFiles.UseVisualStyleBackColor = true;
            this.chkDeleteUnwantedFiles.CheckedChanged += new System.EventHandler(this.chkDeleteUnwantedFiles_CheckedChanged);
            // 
            // chkDeleteDuplicates
            // 
            this.chkDeleteDuplicates.AutoSize = true;
            this.chkDeleteDuplicates.Location = new System.Drawing.Point(8, 6);
            this.chkDeleteDuplicates.Name = "chkDeleteDuplicates";
            this.chkDeleteDuplicates.Size = new System.Drawing.Size(141, 21);
            this.chkDeleteDuplicates.TabIndex = 0;
            this.chkDeleteDuplicates.Text = "Delete Duplicates";
            this.chkDeleteDuplicates.UseVisualStyleBackColor = true;
            this.chkDeleteDuplicates.CheckedChanged += new System.EventHandler(this.chkDeleteDuplicates_CheckedChanged);
            // 
            // tabDateFormats
            // 
            this.tabDateFormats.Controls.Add(this.richTextBox1);
            this.tabDateFormats.Controls.Add(this.panel3);
            this.tabDateFormats.Location = new System.Drawing.Point(4, 25);
            this.tabDateFormats.Name = "tabDateFormats";
            this.tabDateFormats.Padding = new System.Windows.Forms.Padding(3);
            this.tabDateFormats.Size = new System.Drawing.Size(1124, 369);
            this.tabDateFormats.TabIndex = 1;
            this.tabDateFormats.Text = "Date Formats";
            this.tabDateFormats.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblEpisodeDateExample);
            this.panel3.Controls.Add(this.lblSeriesDateExample);
            this.panel3.Controls.Add(this.txtEpisodeDateFormat);
            this.panel3.Controls.Add(this.txtSeriesDateFormat);
            this.panel3.Controls.Add(this.lblEpisodeDateFormat);
            this.panel3.Controls.Add(this.lblSeriesDateFormat);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1118, 63);
            this.panel3.TabIndex = 3;
            // 
            // lblEpisodeDateExample
            // 
            this.lblEpisodeDateExample.AutoSize = true;
            this.lblEpisodeDateExample.Location = new System.Drawing.Point(262, 36);
            this.lblEpisodeDateExample.Name = "lblEpisodeDateExample";
            this.lblEpisodeDateExample.Size = new System.Drawing.Size(0, 17);
            this.lblEpisodeDateExample.TabIndex = 2;
            // 
            // lblSeriesDateExample
            // 
            this.lblSeriesDateExample.AutoSize = true;
            this.lblSeriesDateExample.Location = new System.Drawing.Point(262, 8);
            this.lblSeriesDateExample.Name = "lblSeriesDateExample";
            this.lblSeriesDateExample.Size = new System.Drawing.Size(0, 17);
            this.lblSeriesDateExample.TabIndex = 2;
            // 
            // txtEpisodeDateFormat
            // 
            this.txtEpisodeDateFormat.Location = new System.Drawing.Point(156, 33);
            this.txtEpisodeDateFormat.Name = "txtEpisodeDateFormat";
            this.txtEpisodeDateFormat.Size = new System.Drawing.Size(100, 22);
            this.txtEpisodeDateFormat.TabIndex = 0;
            this.txtEpisodeDateFormat.TextChanged += new System.EventHandler(this.txtEpisodeDateFormat_TextChanged);
            // 
            // txtSeriesDateFormat
            // 
            this.txtSeriesDateFormat.Location = new System.Drawing.Point(156, 5);
            this.txtSeriesDateFormat.Name = "txtSeriesDateFormat";
            this.txtSeriesDateFormat.Size = new System.Drawing.Size(100, 22);
            this.txtSeriesDateFormat.TabIndex = 0;
            this.txtSeriesDateFormat.TextChanged += new System.EventHandler(this.txtSeriesDateFormat_TextChanged);
            // 
            // lblEpisodeDateFormat
            // 
            this.lblEpisodeDateFormat.AutoSize = true;
            this.lblEpisodeDateFormat.Location = new System.Drawing.Point(5, 36);
            this.lblEpisodeDateFormat.Name = "lblEpisodeDateFormat";
            this.lblEpisodeDateFormat.Size = new System.Drawing.Size(145, 17);
            this.lblEpisodeDateFormat.TabIndex = 1;
            this.lblEpisodeDateFormat.Text = "Episode Date Format:";
            // 
            // lblSeriesDateFormat
            // 
            this.lblSeriesDateFormat.AutoSize = true;
            this.lblSeriesDateFormat.Location = new System.Drawing.Point(16, 8);
            this.lblSeriesDateFormat.Name = "lblSeriesDateFormat";
            this.lblSeriesDateFormat.Size = new System.Drawing.Size(134, 17);
            this.lblSeriesDateFormat.TabIndex = 1;
            this.lblSeriesDateFormat.Text = "Series Date Format:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 66);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1118, 300);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // tabTheTVDB
            // 
            this.tabTheTVDB.Controls.Add(this.lblTheTVDBApiKey);
            this.tabTheTVDB.Controls.Add(this.txtTheTVDBApiKey);
            this.tabTheTVDB.Location = new System.Drawing.Point(4, 25);
            this.tabTheTVDB.Name = "tabTheTVDB";
            this.tabTheTVDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabTheTVDB.Size = new System.Drawing.Size(1124, 369);
            this.tabTheTVDB.TabIndex = 2;
            this.tabTheTVDB.Text = "The TVDB Api";
            this.tabTheTVDB.UseVisualStyleBackColor = true;
            // 
            // lblTheTVDBApiKey
            // 
            this.lblTheTVDBApiKey.AutoSize = true;
            this.lblTheTVDBApiKey.Location = new System.Drawing.Point(8, 9);
            this.lblTheTVDBApiKey.Name = "lblTheTVDBApiKey";
            this.lblTheTVDBApiKey.Size = new System.Drawing.Size(118, 17);
            this.lblTheTVDBApiKey.TabIndex = 3;
            this.lblTheTVDBApiKey.Text = "TheTVDBApiKey:";
            // 
            // txtTheTVDBApiKey
            // 
            this.txtTheTVDBApiKey.Location = new System.Drawing.Point(132, 6);
            this.txtTheTVDBApiKey.Name = "txtTheTVDBApiKey";
            this.txtTheTVDBApiKey.Size = new System.Drawing.Size(350, 22);
            this.txtTheTVDBApiKey.TabIndex = 2;
            this.txtTheTVDBApiKey.TextChanged += new System.EventHandler(this.txtTheTVDBApiKey_TextChanged);
            // 
            // tabRenameTemplates
            // 
            this.tabRenameTemplates.Controls.Add(this.richTextBox2);
            this.tabRenameTemplates.Controls.Add(this.grdRenameFormats);
            this.tabRenameTemplates.Location = new System.Drawing.Point(4, 25);
            this.tabRenameTemplates.Name = "tabRenameTemplates";
            this.tabRenameTemplates.Padding = new System.Windows.Forms.Padding(3);
            this.tabRenameTemplates.Size = new System.Drawing.Size(1124, 369);
            this.tabRenameTemplates.TabIndex = 3;
            this.tabRenameTemplates.Text = "Renaming Templates";
            this.tabRenameTemplates.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(363, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(758, 363);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = resources.GetString("richTextBox2.Text");
            // 
            // grdRenameFormats
            // 
            this.grdRenameFormats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRenameFormats.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdRenameFormats.Location = new System.Drawing.Point(3, 3);
            this.grdRenameFormats.Name = "grdRenameFormats";
            this.grdRenameFormats.RowHeadersWidth = 51;
            this.grdRenameFormats.RowTemplate.Height = 24;
            this.grdRenameFormats.Size = new System.Drawing.Size(360, 363);
            this.grdRenameFormats.TabIndex = 0;
            this.grdRenameFormats.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRenameFormats_CellValueChanged);
            // 
            // tabViedoFiles
            // 
            this.tabViedoFiles.Controls.Add(this.richTextBox3);
            this.tabViedoFiles.Controls.Add(this.grdVideoFileExtensions);
            this.tabViedoFiles.Location = new System.Drawing.Point(4, 25);
            this.tabViedoFiles.Name = "tabViedoFiles";
            this.tabViedoFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabViedoFiles.Size = new System.Drawing.Size(1124, 369);
            this.tabViedoFiles.TabIndex = 4;
            this.tabViedoFiles.Text = "Video Files";
            this.tabViedoFiles.UseVisualStyleBackColor = true;
            // 
            // richTextBox3
            // 
            this.richTextBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox3.Location = new System.Drawing.Point(363, 3);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(758, 363);
            this.richTextBox3.TabIndex = 1;
            this.richTextBox3.Text = resources.GetString("richTextBox3.Text");
            // 
            // grdVideoFileExtensions
            // 
            this.grdVideoFileExtensions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVideoFileExtensions.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdVideoFileExtensions.Location = new System.Drawing.Point(3, 3);
            this.grdVideoFileExtensions.Name = "grdVideoFileExtensions";
            this.grdVideoFileExtensions.RowHeadersWidth = 51;
            this.grdVideoFileExtensions.RowTemplate.Height = 24;
            this.grdVideoFileExtensions.Size = new System.Drawing.Size(360, 363);
            this.grdVideoFileExtensions.TabIndex = 0;
            this.grdVideoFileExtensions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVideoFileExtensions_CellValueChanged);
            // 
            // tabUnwantedFilesAndChars
            // 
            this.tabUnwantedFilesAndChars.Controls.Add(this.richTextBox5);
            this.tabUnwantedFilesAndChars.Controls.Add(this.pnlUnwantedFiles);
            this.tabUnwantedFilesAndChars.Location = new System.Drawing.Point(4, 25);
            this.tabUnwantedFilesAndChars.Name = "tabUnwantedFilesAndChars";
            this.tabUnwantedFilesAndChars.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnwantedFilesAndChars.Size = new System.Drawing.Size(1124, 369);
            this.tabUnwantedFilesAndChars.TabIndex = 5;
            this.tabUnwantedFilesAndChars.Text = "Unwanted Files";
            this.tabUnwantedFilesAndChars.UseVisualStyleBackColor = true;
            // 
            // richTextBox5
            // 
            this.richTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox5.Location = new System.Drawing.Point(387, 3);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.Size = new System.Drawing.Size(734, 363);
            this.richTextBox5.TabIndex = 7;
            this.richTextBox5.Text = resources.GetString("richTextBox5.Text");
            // 
            // pnlUnwantedFiles
            // 
            this.pnlUnwantedFiles.Controls.Add(this.grdUnwantedFiles);
            this.pnlUnwantedFiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUnwantedFiles.Location = new System.Drawing.Point(3, 3);
            this.pnlUnwantedFiles.Name = "pnlUnwantedFiles";
            this.pnlUnwantedFiles.Size = new System.Drawing.Size(384, 363);
            this.pnlUnwantedFiles.TabIndex = 6;
            // 
            // grdUnwantedFiles
            // 
            this.grdUnwantedFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUnwantedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUnwantedFiles.Location = new System.Drawing.Point(0, 0);
            this.grdUnwantedFiles.Name = "grdUnwantedFiles";
            this.grdUnwantedFiles.RowHeadersWidth = 51;
            this.grdUnwantedFiles.RowTemplate.Height = 24;
            this.grdUnwantedFiles.Size = new System.Drawing.Size(384, 363);
            this.grdUnwantedFiles.TabIndex = 5;
            this.grdUnwantedFiles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUnwantedFiles_CellValueChanged);
            // 
            // tabReplaceStrings
            // 
            this.tabReplaceStrings.Controls.Add(this.richTextBox4);
            this.tabReplaceStrings.Controls.Add(this.grdReplaceChars);
            this.tabReplaceStrings.Location = new System.Drawing.Point(4, 25);
            this.tabReplaceStrings.Name = "tabReplaceStrings";
            this.tabReplaceStrings.Padding = new System.Windows.Forms.Padding(3);
            this.tabReplaceStrings.Size = new System.Drawing.Size(1124, 369);
            this.tabReplaceStrings.TabIndex = 7;
            this.tabReplaceStrings.Text = "Replace Strings";
            this.tabReplaceStrings.UseVisualStyleBackColor = true;
            // 
            // richTextBox4
            // 
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox4.Location = new System.Drawing.Point(363, 3);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(758, 363);
            this.richTextBox4.TabIndex = 5;
            this.richTextBox4.Text = "Once a template is applied any strings in this list will be replaced. \nIf the rem" +
    "placement has an invalid character it\'ll be replaced by the default character in" +
    " the General tab.";
            // 
            // grdReplaceChars
            // 
            this.grdReplaceChars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdReplaceChars.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdReplaceChars.Location = new System.Drawing.Point(3, 3);
            this.grdReplaceChars.Name = "grdReplaceChars";
            this.grdReplaceChars.RowHeadersWidth = 51;
            this.grdReplaceChars.RowTemplate.Height = 24;
            this.grdReplaceChars.Size = new System.Drawing.Size(360, 363);
            this.grdReplaceChars.TabIndex = 4;
            this.grdReplaceChars.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdReplaceChars_CellValueChanged);
            // 
            // tabMisc
            // 
            this.tabMisc.Controls.Add(this.lblLastRootPath);
            this.tabMisc.Controls.Add(this.txtLastRootPath);
            this.tabMisc.Location = new System.Drawing.Point(4, 25);
            this.tabMisc.Name = "tabMisc";
            this.tabMisc.Padding = new System.Windows.Forms.Padding(3);
            this.tabMisc.Size = new System.Drawing.Size(1124, 369);
            this.tabMisc.TabIndex = 6;
            this.tabMisc.Text = "Misc";
            this.tabMisc.UseVisualStyleBackColor = true;
            // 
            // lblLastRootPath
            // 
            this.lblLastRootPath.AutoSize = true;
            this.lblLastRootPath.Location = new System.Drawing.Point(9, 9);
            this.lblLastRootPath.Name = "lblLastRootPath";
            this.lblLastRootPath.Size = new System.Drawing.Size(106, 17);
            this.lblLastRootPath.TabIndex = 3;
            this.lblLastRootPath.Text = "Last Root Path:";
            // 
            // txtLastRootPath
            // 
            this.txtLastRootPath.Location = new System.Drawing.Point(121, 6);
            this.txtLastRootPath.Name = "txtLastRootPath";
            this.txtLastRootPath.ReadOnly = true;
            this.txtLastRootPath.Size = new System.Drawing.Size(350, 22);
            this.txtLastRootPath.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(932, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(100, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 100);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 100);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&OK";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 398);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1132, 100);
            this.panel2.TabIndex = 4;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 498);
            this.Controls.Add(this.tabControlOptions);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.Shown += new System.EventHandler(this.FrmSettings_Shown);
            this.tabControlOptions.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabDateFormats.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabTheTVDB.ResumeLayout(false);
            this.tabTheTVDB.PerformLayout();
            this.tabRenameTemplates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRenameFormats)).EndInit();
            this.tabViedoFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVideoFileExtensions)).EndInit();
            this.tabUnwantedFilesAndChars.ResumeLayout(false);
            this.pnlUnwantedFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUnwantedFiles)).EndInit();
            this.tabReplaceStrings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReplaceChars)).EndInit();
            this.tabMisc.ResumeLayout(false);
            this.tabMisc.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabDateFormats;
        private System.Windows.Forms.CheckBox chkDeleteDuplicates;
        private System.Windows.Forms.CheckBox chkDeleteUnwantedFiles;
        private System.Windows.Forms.CheckBox chkMakeMissingPlaceholder;
        private System.Windows.Forms.CheckBox chkRenameMatchingAccompanyingFiles;
        private System.Windows.Forms.TextBox txtInvalidCharReplacement;
        private System.Windows.Forms.TextBox txtEpisodeDateFormat;
        private System.Windows.Forms.TextBox txtSeriesDateFormat;
        private System.Windows.Forms.Label lblInvalidCharReplacement;
        private System.Windows.Forms.Label lblSeriesDateFormat;
        private System.Windows.Forms.Label lblEpisodeDateFormat;
        private System.Windows.Forms.TabPage tabTheTVDB;
        private System.Windows.Forms.Label lblTheTVDBApiKey;
        private System.Windows.Forms.TextBox txtTheTVDBApiKey;
        private System.Windows.Forms.TabPage tabRenameTemplates;
        private System.Windows.Forms.TabPage tabViedoFiles;
        private System.Windows.Forms.TabPage tabUnwantedFilesAndChars;
        private System.Windows.Forms.TabPage tabMisc;
        private System.Windows.Forms.Label lblLastRootPath;
        private System.Windows.Forms.TextBox txtLastRootPath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView grdRenameFormats;
        private System.Windows.Forms.DataGridView grdVideoFileExtensions;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel pnlUnwantedFiles;
        private System.Windows.Forms.DataGridView grdUnwantedFiles;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.TabPage tabReplaceStrings;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.DataGridView grdReplaceChars;
        private System.Windows.Forms.Label lblEpisodeDateExample;
        private System.Windows.Forms.Label lblSeriesDateExample;
    }
}