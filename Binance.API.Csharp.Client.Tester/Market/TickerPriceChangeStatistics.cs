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

namespace Binance.API.Csharp.Client.Tester.Market
{
    public partial class FrmTickerPriceChangeStatistics : FrmBase
    {
        public FrmTickerPriceChangeStatistics() {
            InitializeComponent();
        }

        public FrmTickerPriceChangeStatistics(Form mdiParent) : base(mdiParent)
        {
            InitializeComponent();
            txtEndpoint.Text = ConfigurationManager.AppSettings["ApiBaseURL"] + Utils.EndPoints.TickerPriceChange24H;
        }
    }
}
