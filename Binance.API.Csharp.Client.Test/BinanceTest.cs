using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binance.API.Csharp.Client;
using Binance.API.Csharp.Client.Models.Enums;

namespace binance_api_csharp_helper.Test
{
    [TestClass]
    public class BinanceTest
    {
        private static ApiClient apiClient = new ApiClient("@YourApiKey", "YourApiSecret");
        private static BinanceClient binanceClient = new BinanceClient(apiClient);

        #region General
        [TestMethod]
        public void TestConnectivity()
        {
            var test = binanceClient.TestConnectivity().Result;
        }

        [TestMethod]
        public void GetServerTime()
        {
            var serverTime = binanceClient.GetServerTime().Result;
        }
        #endregion

        #region Market Data
        [TestMethod]
        public void GetOrderBook()
        {
            var orderBook = binanceClient.GetOrderBook("ethbtc").Result;
        }

        [TestMethod]
        public void GetCandleSticks()
        {
            var candlestick = binanceClient.GetCandleSticks("ethbtc", TimeInterval.Minutes_15).Result;
        }

        [TestMethod]
        public void GetAggregateTrades()
        {
            var aggregateTrades = binanceClient.GetAggregateTrades("ethbtc").Result;
        }

        [TestMethod]
        public void GetPriceChange24H()
        {
            var priceChangeInfo = binanceClient.GetPriceChange24H("ethbtc").Result;
        }

        [TestMethod]
        public void GetAllPrices()
        {
            var tickerPrices = binanceClient.GetAllPrices().Result;
        }

        [TestMethod]
        public void GetOrderBookTicker()
        {
            var orderBookTickers = binanceClient.GetOrderBookTicker().Result;
        }
        #endregion

        #region Account Information
        [TestMethod]
        public void PostLimitOrder()
        {
            var buyOrder = binanceClient.PostNewOrder("ethbtc", 1m, 0.045m, OrderSide.BUY).Result;
            var sellOrder = binanceClient.PostNewOrder("ethbtc", 1m, 0.04m, OrderSide.SELL).Result;
        }


        [TestMethod]
        public void PostMarketOrder()
        {
            var buyOrder = binanceClient.PostNewOrder("ethbtc", 0.32m, 0m, OrderSide.BUY, OrderType.MARKET).Result;
            var sellOrder = binanceClient.PostNewOrder("ethbtc", 0.1m, 0m, OrderSide.SELL, OrderType.MARKET).Result;
        }

        [TestMethod]
        public void PostStopOrder()
        {
            var stopOrder = binanceClient.PostNewOrder("ethbtc", 0.5m, 0.01m, OrderSide.BUY, stopPrice: 0.5m).Result;
        }

        [TestMethod]
        public void PostIcebergOrder()
        {
            var icebergOrder = binanceClient.PostNewOrder("ethbtc", 2m, 0.01m, OrderSide.BUY, icebergQty: 5m).Result;
        }

        [TestMethod]
        public void PostNewLimitOrderTest()
        {
            var testOrder = binanceClient.PostNewOrderTest("ethbtc", 1m, 0.1m, OrderSide.BUY).Result;
        }

        [TestMethod]
        public void CancelOrder()
        {
            var canceledOrder = binanceClient.CancelOrder("ethbtc", 9137796).Result;
        }

        [TestMethod]
        public void GetCurrentOpenOrders()
        {
            var openOrders = binanceClient.GetCurrentOpenOrders("ethbtc").Result;
        }

        [TestMethod]
        public void GetOrder()
        {
            var order = binanceClient.GetOrder("ethbtc", 8982811).Result;
        }

        [TestMethod]
        public void GetAllOrders()
        {
            var allOrders = binanceClient.GetAllOrders("ethbtc").Result;
        }

        [TestMethod]
        public void GetAccountInfo()
        {
            var accountInfo = binanceClient.GetAccountInfo().Result;
        }

        [TestMethod]
        public void GetTradeList()
        {
            var tradeList = binanceClient.GetTradeList("ethbtc").Result;
        }

        #endregion

        #region User stream
        [TestMethod]
        public void StartUserStream()
        {
            var listenKey = binanceClient.StartUserStream().Result.ListenKey;
        }

        [TestMethod]
        public void KeepAliveUserStream()
        {
            var ping = binanceClient.KeepAliveUserStream("@ListenKey").Result;
        }

        [TestMethod]
        public void CloseUserStream()
        {
            var resut = binanceClient.CloseUserStream("@ListenKey").Result;
        }
        #endregion
    }
}
