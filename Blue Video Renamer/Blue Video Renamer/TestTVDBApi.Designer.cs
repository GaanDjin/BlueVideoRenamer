namespace Blue_Video_Renamer
{
    partial class frmTheTVDBTest
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAuthenticate = new System.Windows.Forms.TabPage();
            this.tabLanguages = new System.Windows.Forms.TabPage();
            this.tabSeries = new System.Windows.Forms.TabPage();
            this.tabEpisodes = new System.Windows.Forms.TabPage();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.tabUpdates = new System.Windows.Forms.TabPage();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.grpAuthentication = new System.Windows.Forms.GroupBox();
            this.lblAPIKey = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtAPIKey = new System.Windows.Forms.TextBox();
            this.grpSeriesSearch = new System.Windows.Forms.GroupBox();
            this.lblSeriesName = new System.Windows.Forms.Label();
            this.btnLookupSeries = new System.Windows.Forms.Button();
            this.txtSeriesName = new System.Windows.Forms.TextBox();
            this.picBanner = new System.Windows.Forms.PictureBox();
            this.lstLanguages = new System.Windows.Forms.ListBox();
            this.btnFetchLanguages = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabAuthenticate.SuspendLayout();
            this.tabLanguages.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.grpAuthentication.SuspendLayout();
            this.grpSeriesSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.AcceptsReturn = true;
            this.txtResult.Location = new System.Drawing.Point(21, 380);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(1229, 280);
            this.txtResult.TabIndex = 2;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(18, 360);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(52, 17);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "Result:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAuthenticate);
            this.tabControl1.Controls.Add(this.tabLanguages);
            this.tabControl1.Controls.Add(this.tabSeries);
            this.tabControl1.Controls.Add(this.tabEpisodes);
            this.tabControl1.Controls.Add(this.tabSearch);
            this.tabControl1.Controls.Add(this.tabUpdates);
            this.tabControl1.Controls.Add(this.tabUsers);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1242, 345);
            this.tabControl1.TabIndex = 8;
            // 
            // tabAuthenticate
            // 
            this.tabAuthenticate.Controls.Add(this.grpAuthentication);
            this.tabAuthenticate.Location = new System.Drawing.Point(4, 25);
            this.tabAuthenticate.Name = "tabAuthenticate";
            this.tabAuthenticate.Padding = new System.Windows.Forms.Padding(3);
            this.tabAuthenticate.Size = new System.Drawing.Size(1234, 316);
            this.tabAuthenticate.TabIndex = 0;
            this.tabAuthenticate.Text = "Authenticate";
            this.tabAuthenticate.UseVisualStyleBackColor = true;
            // 
            // tabLanguages
            // 
            this.tabLanguages.Controls.Add(this.btnFetchLanguages);
            this.tabLanguages.Controls.Add(this.lstLanguages);
            this.tabLanguages.Location = new System.Drawing.Point(4, 25);
            this.tabLanguages.Name = "tabLanguages";
            this.tabLanguages.Padding = new System.Windows.Forms.Padding(3);
            this.tabLanguages.Size = new System.Drawing.Size(1234, 316);
            this.tabLanguages.TabIndex = 1;
            this.tabLanguages.Text = "Languages";
            this.tabLanguages.UseVisualStyleBackColor = true;
            // 
            // tabSeries
            // 
            this.tabSeries.Location = new System.Drawing.Point(4, 25);
            this.tabSeries.Name = "tabSeries";
            this.tabSeries.Size = new System.Drawing.Size(1234, 316);
            this.tabSeries.TabIndex = 2;
            this.tabSeries.Text = "Series";
            this.tabSeries.UseVisualStyleBackColor = true;
            // 
            // tabEpisodes
            // 
            this.tabEpisodes.Location = new System.Drawing.Point(4, 25);
            this.tabEpisodes.Name = "tabEpisodes";
            this.tabEpisodes.Size = new System.Drawing.Size(1234, 316);
            this.tabEpisodes.TabIndex = 3;
            this.tabEpisodes.Text = "Episodes";
            this.tabEpisodes.UseVisualStyleBackColor = true;
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.picBanner);
            this.tabSearch.Controls.Add(this.grpSeriesSearch);
            this.tabSearch.Location = new System.Drawing.Point(4, 25);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new System.Drawing.Size(1234, 316);
            this.tabSearch.TabIndex = 4;
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // tabUpdates
            // 
            this.tabUpdates.Location = new System.Drawing.Point(4, 25);
            this.tabUpdates.Name = "tabUpdates";
            this.tabUpdates.Size = new System.Drawing.Size(358, 381);
            this.tabUpdates.TabIndex = 5;
            this.tabUpdates.Text = "Updates";
            this.tabUpdates.UseVisualStyleBackColor = true;
            // 
            // tabUsers
            // 
            this.tabUsers.Location = new System.Drawing.Point(4, 25);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Size = new System.Drawing.Size(358, 381);
            this.tabUsers.TabIndex = 6;
            this.tabUsers.Text = "Users";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // grpAuthentication
            // 
            this.grpAuthentication.Controls.Add(this.lblAPIKey);
            this.grpAuthentication.Controls.Add(this.btnLogin);
            this.grpAuthentication.Controls.Add(this.txtAPIKey);
            this.grpAuthentication.Location = new System.Drawing.Point(6, 6);
            this.grpAuthentication.Name = "grpAuthentication";
            this.grpAuthentication.Size = new System.Drawing.Size(518, 88);
            this.grpAuthentication.TabIndex = 4;
            this.grpAuthentication.TabStop = false;
            this.grpAuthentication.Text = "Authentication";
            // 
            // lblAPIKey
            // 
            this.lblAPIKey.AutoSize = true;
            this.lblAPIKey.Location = new System.Drawing.Point(6, 24);
            this.lblAPIKey.Name = "lblAPIKey";
            this.lblAPIKey.Size = new System.Drawing.Size(61, 17);
            this.lblAPIKey.TabIndex = 4;
            this.lblAPIKey.Text = "API Key:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(105, 49);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtAPIKey
            // 
            this.txtAPIKey.Location = new System.Drawing.Point(105, 21);
            this.txtAPIKey.Name = "txtAPIKey";
            this.txtAPIKey.Size = new System.Drawing.Size(407, 22);
            this.txtAPIKey.TabIndex = 2;
            // 
            // grpSeriesSearch
            // 
            this.grpSeriesSearch.Controls.Add(this.lblSeriesName);
            this.grpSeriesSearch.Controls.Add(this.btnLookupSeries);
            this.grpSeriesSearch.Controls.Add(this.txtSeriesName);
            this.grpSeriesSearch.Location = new System.Drawing.Point(3, 3);
            this.grpSeriesSearch.Name = "grpSeriesSearch";
            this.grpSeriesSearch.Size = new System.Drawing.Size(518, 88);
            this.grpSeriesSearch.TabIndex = 7;
            this.grpSeriesSearch.TabStop = false;
            this.grpSeriesSearch.Text = "Series Search";
            // 
            // lblSeriesName
            // 
            this.lblSeriesName.AutoSize = true;
            this.lblSeriesName.Location = new System.Drawing.Point(6, 24);
            this.lblSeriesName.Name = "lblSeriesName";
            this.lblSeriesName.Size = new System.Drawing.Size(93, 17);
            this.lblSeriesName.TabIndex = 4;
            this.lblSeriesName.Text = "Series Name:";
            // 
            // btnLookupSeries
            // 
            this.btnLookupSeries.Location = new System.Drawing.Point(105, 49);
            this.btnLookupSeries.Name = "btnLookupSeries";
            this.btnLookupSeries.Size = new System.Drawing.Size(75, 23);
            this.btnLookupSeries.TabIndex = 3;
            this.btnLookupSeries.Text = "Search";
            this.btnLookupSeries.UseVisualStyleBackColor = true;
            this.btnLookupSeries.Click += new System.EventHandler(this.btnLookupSeries_Click);
            // 
            // txtSeriesName
            // 
            this.txtSeriesName.Location = new System.Drawing.Point(105, 21);
            this.txtSeriesName.Name = "txtSeriesName";
            this.txtSeriesName.Size = new System.Drawing.Size(407, 22);
            this.txtSeriesName.TabIndex = 2;
            this.txtSeriesName.Text = "Gravity Falls";
            // 
            // picBanner
            // 
            this.picBanner.Location = new System.Drawing.Point(12, 97);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(758, 140);
            this.picBanner.TabIndex = 8;
            this.picBanner.TabStop = false;
            // 
            // lstLanguages
            // 
            this.lstLanguages.FormattingEnabled = true;
            this.lstLanguages.ItemHeight = 16;
            this.lstLanguages.Location = new System.Drawing.Point(6, 38);
            this.lstLanguages.Name = "lstLanguages";
            this.lstLanguages.Size = new System.Drawing.Size(519, 260);
            this.lstLanguages.TabIndex = 0;
            // 
            // btnFetchLanguages
            // 
            this.btnFetchLanguages.Location = new System.Drawing.Point(7, 9);
            this.btnFetchLanguages.Name = "btnFetchLanguages";
            this.btnFetchLanguages.Size = new System.Drawing.Size(75, 23);
            this.btnFetchLanguages.TabIndex = 1;
            this.btnFetchLanguages.Text = "Fetch";
            this.btnFetchLanguages.UseVisualStyleBackColor = true;
            this.btnFetchLanguages.Click += new System.EventHandler(this.btnFetchLanguages_Click);
            // 
            // frmTheTVDBTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 672);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtResult);
            this.Name = "frmTheTVDBTest";
            this.Text = "The TVDB TestApp";
            this.Load += new System.EventHandler(this.frmTheTVDBTest_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabAuthenticate.ResumeLayout(false);
            this.tabLanguages.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.grpAuthentication.ResumeLayout(false);
            this.grpAuthentication.PerformLayout();
            this.grpSeriesSearch.ResumeLayout(false);
            this.grpSeriesSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAuthenticate;
        private System.Windows.Forms.TabPage tabLanguages;
        private System.Windows.Forms.GroupBox grpAuthentication;
        private System.Windows.Forms.Label lblAPIKey;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtAPIKey;
        private System.Windows.Forms.TabPage tabSeries;
        private System.Windows.Forms.TabPage tabEpisodes;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.GroupBox grpSeriesSearch;
        private System.Windows.Forms.Label lblSeriesName;
        private System.Windows.Forms.Button btnLookupSeries;
        private System.Windows.Forms.TextBox txtSeriesName;
        private System.Windows.Forms.TabPage tabUpdates;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.PictureBox picBanner;
        private System.Windows.Forms.Button btnFetchLanguages;
        private System.Windows.Forms.ListBox lstLanguages;
    }
}

