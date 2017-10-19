using Binance.API.Csharp.Client.Tester.Market;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binance.API.Csharp.Client.Tester
{
    public partial class frmMainMenu : Form
    {
        private static ApiClient _apiClient;
        private static BinanceClient _binanceClient;

        public frmMainMenu()
        {
            InitializeComponent();

            var apiKey = ConfigurationManager.AppSettings["ApiKey"];
            var apiSecret = ConfigurationManager.AppSettings["ApiSecret"];

            _apiClient = new ApiClient(apiKey, apiSecret);
            _binanceClient = new BinanceClient(_apiClient);
        }

        private void aggregateTradesListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async void CheckServerTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await _binanceClient.GetServerTime().ConfigureAwait(false);
                MessageBox.Show($"Server time is: {result.ServerTime}", $"Check Server Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void TestConnectivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await _binanceClient.TestConnectivity().ConfigureAwait(false);
                MessageBox.Show($"Connectivity test successful!", $"Test Connectivity", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TickerPriceChangeStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var newForm = new FrmTickerPriceChangeStatistics(this);
                newForm.Show();
                newForm.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
