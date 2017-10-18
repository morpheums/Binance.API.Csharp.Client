using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Csharp.Client.Utils
{
    public class TradingRules
    {
        private List<TickerInfo> _tickersInfo;
        public List<TickerInfo> TickersInfo { get { return _tickersInfo; } }

        public TradingRules()
        {
            _tickersInfo = new List<TickerInfo>()
                {
                    //BTC
                    new TickerInfo(){Ticker="ETHBTC",MinUnitPrice=0.000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="LTCBTC",MinUnitPrice=0.000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="BNBBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="NEOBTC",MinUnitPrice=0.000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="GASBTC",MinUnitPrice=0.000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="BCCBTC",MinUnitPrice=0.000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="MCOBTC",MinUnitPrice=0.000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="WTCBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="QTUMBTC",MinUnitPrice=0.000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="OMGBTC",MinUnitPrice=0.000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="ZRXBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="STRATBTC",MinUnitPrice=0.000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="SNGLSBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="BQXBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="KNCBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="FUNBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="SNMBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="LINKBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="XVGBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="CTRBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="SALTBTC",MinUnitPrice=0.000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="IOTABTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="MDABTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="MTLBTC",MinUnitPrice=0.000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="SUBBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="EOSBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="SNTBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="ETCBTC",MinUnitPrice=0.000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="MTHBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="ENGBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="DNTBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},
                    new TickerInfo(){Ticker="BNTBTC",MinUnitPrice=0.00000001m,MinOrderPrice=0.001m},

                    //ETH
                    new TickerInfo(){Ticker="BNBETH",MinUnitPrice=0.00000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="QTUMETH",MinUnitPrice=0.000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="SNTETH",MinUnitPrice=0.00000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="BNTETH",MinUnitPrice=0.000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="EOSETH",MinUnitPrice=0.000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="OAXETH",MinUnitPrice=0.000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="DNTETH",MinUnitPrice=0.00000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="MCOETH",MinUnitPrice=0.000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="ICNETH",MinUnitPrice=0.000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="WTCETH",MinUnitPrice=0.000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="OMGETH",MinUnitPrice=0.000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="ZRXETH",MinUnitPrice=0.00000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="STRATETH",MinUnitPrice=0.000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="SNGLSETH",MinUnitPrice=0.00000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="BQXETH",MinUnitPrice=0.0000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="KNCETH",MinUnitPrice=0.0000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="FUNETH",MinUnitPrice=0.00000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="SNMETH",MinUnitPrice=0.00000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="NEOETH",MinUnitPrice=0.00000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="LINKETH",MinUnitPrice=0.00000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="XVGETH",MinUnitPrice=0.00000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="CTRETH",MinUnitPrice=0.0000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="SALTETH",MinUnitPrice=0.000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="IOTAETH",MinUnitPrice=0.00000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="MDAETH",MinUnitPrice=0.0000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="MTLETH",MinUnitPrice=0.000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="SUBETH",MinUnitPrice=0.00000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="ETCETH",MinUnitPrice=0.000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="MTHETH",MinUnitPrice=0.00000001m,MinOrderPrice=0.01m},
                    new TickerInfo(){Ticker="ENGETH",MinUnitPrice=0.0000001m,MinOrderPrice=0.01m},

                    //USDT
                    new TickerInfo(){Ticker="BTCUSDT",MinUnitPrice=0.01m,MinOrderPrice=1m},
                    new TickerInfo(){Ticker="ETHUSDT",MinUnitPrice=0.01m,MinOrderPrice=1}
                };
        }
    }

    public class TickerInfo
    {
        public string Ticker { get; set; }
        public decimal MinUnitPrice { get; set; }
        public decimal MinOrderPrice { get; set; }
    }
}
