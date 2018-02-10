using Microsoft.VisualStudio.TestTools.UnitTesting;
using Binance.API.Csharp.Client.Models.Enums;
using System.Threading;
using Binance.API.Csharp.Client.Models.WebSocket;

namespace Binance.API.Csharp.Client.Test
{
    [TestClass]
    public class BinanceTest
    {
        private static ApiClient apiClient = new ApiClient("@YourApiKey", "@YourApiSecret");
        private static BinanceClient binanceClient = new BinanceClient(apiClient,false);

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

        [TestMethod]
        public void GetSystemStatus()
        {
            var systemStatus = binanceClient.GetSystemStatus().Result;
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
            var candlestick = binanceClient.GetCandleSticks("ethbtc", TimeInterval.Minutes_15, new System.DateTime(2017,11,24), new System.DateTime(2017, 11, 26)).Result;
        }

        [TestMethod]
        public void GetAggregateTrades()
        {
            var aggregateTrades = binanceClient.GetAggregateTrades("ethbtc").Result;
        }

        [TestMethod]
        public void GetPriceChange24H()
        {
            var singleTickerInfo = binanceClient.GetPriceChange24H("ETHBTC").Result;

            var allTickersInfo = binanceClient.GetPriceChange24H().Result;
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
            var buyOrder = binanceClient.PostNewOrder("KNCETH", 100m, 0.005m, OrderSide.BUY).Result;
            var sellOrder = binanceClient.PostNewOrder("KNCETH", 1000m, 1m, OrderSide.SELL).Result;
        }

        [TestMethod]
        public void PostMarketOrder()
        {
            var buyMarketOrder = binanceClient.PostNewOrder("ethbtc", 0.01m, 0m, OrderSide.BUY, OrderType.MARKET).Result;
            var sellMarketOrder = binanceClient.PostNewOrder("ethbtc", 0.01m, 0m, OrderSide.SELL, OrderType.MARKET).Result;
        }

        [TestMethod]
        public void PostIcebergOrder()
        {
            var icebergOrder = binanceClient.PostNewOrder("ethbtc", 0.01m, 0m, OrderSide.BUY, OrderType.MARKET, icebergQty: 2m).Result;
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

        [TestMethod]
        public void Withdraw()
        {
            var withdrawResult = binanceClient.Withdraw("AST", 100m, "@YourDepositAddress").Result;
        }

        [TestMethod]
        public void GetDepositHistory()
        {
            var depositHistory = binanceClient.GetDepositHistory("neo", DepositStatus.Success).Result;
        }

        [TestMethod]
        public void GetWithdrawHistory()
        {
            var withdrawHistory = binanceClient.GetWithdrawHistory("neo").Result;
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

        #region WebSocket

        #region Depth
        private void DepthHandler(DepthMessage messageData)
        {
            var depthData = messageData;
        }

        [TestMethod]
        public void TestDepthEndpoint()
        {
            binanceClient.ListenDepthEndpoint("ethbtc", DepthHandler);
            Thread.Sleep(50000);
        }

        #endregion

        #region Kline
        private void KlineHandler(KlineMessage messageData)
        {
            var klineData = messageData;
        }

        [TestMethod]
        public void TestKlineEndpoint()
        {
            binanceClient.ListenKlineEndpoint("ethbtc", TimeInterval.Minutes_1, KlineHandler);
            Thread.Sleep(50000);
        }
        #endregion

        #region AggregateTrade
        private void AggregateTradesHandler(AggregateTradeMessage messageData)
        {
            var aggregateTrades = messageData;
        }

        [TestMethod]
        public void AggregateTestTradesEndpoint()
        {
            binanceClient.ListenTradeEndpoint("ethbtc", AggregateTradesHandler);
            Thread.Sleep(50000);
        }

        #endregion

        #region User Info
        private void AccountHandler(AccountUpdatedMessage messageData)
        {
            var accountData = messageData;
        }

        private void TradesHandler(OrderOrTradeUpdatedMessage messageData)
        {
            var tradesData = messageData;
        }

        private void OrdersHandler(OrderOrTradeUpdatedMessage messageData)
        {
            var ordersData = messageData;
        }

        [TestMethod]
        public void TestUserDataEndpoint()
        {
            binanceClient.ListenUserDataEndpoint(AccountHandler, TradesHandler, OrdersHandler);
            Thread.Sleep(50000);
        }
        #endregion

        #endregion
    }
}
