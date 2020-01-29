using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTVDB_API_v2;

namespace Blue_Video_Renamer
{
    public partial class frmTheTVDBTest : Form
    {
        TheTVDB api;

        public frmTheTVDBTest()
        {
            InitializeComponent();
        }

        private void frmTheTVDBTest_Load(object sender, EventArgs e)
        {
            api = new TheTVDB();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtAPIKey.Text == null || txtAPIKey.Text.Trim().Length == 0)
            {
                MessageBox.Show("API Key cannot be null!");
                return;
            }

            bool result = await api.AuthenticateAsync(txtAPIKey.Text);

            if (result)
            {
                MessageBox.Show("Authenticated!");
                btnLookupSeries.Enabled = true;

                await api.SearchSeriesParams();
                txtResult.Text = api.LastResponseRaw;
            }
            else
            {
                MessageBox.Show("Error Authenticating!\n" + api.LastError);
                btnLookupSeries.Enabled = false;
            }
        }

        private async void btnLookupSeries_Click(object sender, EventArgs e)
        {
            SeriesSearchResult[] result = await api.SearchSeries(txtSeriesName.Text);

            if (result == null)
            {
                txtResult.Text = "Error!\n" + api.LastError;
            }
            else if (result.Length == 0)
            {
                txtResult.Text = "No results";
            }
            else
            {
                txtResult.Text = api.LastResponseRaw;
                picBanner.ImageLocation = result[0].Banner;
            }
        }

        private async void btnFetchLanguages_Click(object sender, EventArgs e)
        {
            lstLanguages.Items.Clear();

            Language[] langs = await api.GetLanguages();

            if (langs == null)
            {
                MessageBox.Show(api.LastError);
                return;
            }

            foreach(Language lang in langs)
            {
                lstLanguages.Items.Add(lang.Name + " [" + lang.EnglishName + "] " + lang.Abbreviation);
            }
        }
    }
}
