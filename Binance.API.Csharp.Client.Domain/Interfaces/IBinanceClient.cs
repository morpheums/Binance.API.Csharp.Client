using Binance.API.Csharp.Client.Models.Account;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.General;
using Binance.API.Csharp.Client.Models.Market;
using Binance.API.Csharp.Client.Models.UserStream;
using Binance.API.Csharp.Client.Models.WebSocket;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Binance.API.Csharp.Client.Domain.Abstract.ApiClientAbstract;

namespace Binance.API.Csharp.Client.Domain.Interfaces
{
    public interface IBinanceClient
    {
        #region General
        /// <summary>
        /// Test connectivity to the Rest API.
        /// </summary>
        /// <returns></returns>
        Task<dynamic> TestConnectivity();

        /// <summary>
        /// Test connectivity to the Rest API and get the current server time.
        /// </summary>
        /// <returns></returns>
        Task<ServerInfo> GetServerTime();
        #endregion

        #region Market Data
        /// <summary>
        /// Get order book for a particular symbol.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="limit">Limit of records to retrieve.</param>
        /// <returns></returns>
        Task<OrderBook> GetOrderBook(string symbol, int limit = 100);

        /// <summary>
        /// Get compressed, aggregate trades. Trades that fill at the time, from the same order, with the same price will have the quantity aggregated.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="limit">Limit of records to retrieve.</param>
        /// <returns></returns>
        Task<IEnumerable<AggregateTrade>> GetAggregateTrades(string symbol, int limit = 500);

        /// <summary>
        /// Kline/candlestick bars for a symbol. Klines are uniquely identified by their open time.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="interval">Time interval to retreive.</param>
        /// <param name="limit">Limit of records to retrieve.</param>
        /// <returns></returns>
        Task<IEnumerable<Candlestick>> GetCandleSticks(string symbol, TimeInterval interval, DateTime? startTime = null, DateTime? endTime = null, int limit = 500);

        /// <summary>
        /// 24 hour price change statistics.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <returns></returns>
        Task<IEnumerable<PriceChangeInfo>> GetPriceChange24H(string symbol);

        /// <summary>
        /// Latest price for all symbols.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SymbolPrice>> GetAllPrices();

        /// <summary>
        /// Best price/qty on the order book for all symbols.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<OrderBookTicker>> GetOrderBookTicker();
        #endregion

        #region Account Information
        /// <summary>
        /// Send in a new order.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="quantity">Quantity to transaction.</param>
        /// <param name="price">Price of the transaction.</param>
        /// <param name="orderType">Order type (LIMIT-MARKET).</param>
        /// <param name="side">Order side (BUY-SELL).</param>
        /// <param name="timeInForce">Indicates how long an order will remain active before it is executed or expires.</param>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        Task<NewOrder> PostNewOrder(string symbol, decimal quantity, decimal price, OrderSide side, OrderType orderType = OrderType.LIMIT, TimeInForce timeInForce = TimeInForce.GTC, decimal icebergQty = 0m, long recvWindow = 6000000);

        /// <summary>
        /// Test new order creation and signature/recvWindow long. Creates and validates a new order but does not send it into the matching engine.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="quantity">Quantity to transaction.</param>
        /// <param name="price">Price of the transaction.</param>
        /// <param name="orderType">Order type (LIMIT-MARKET).</param>
        /// <param name="side">Order side (BUY-SELL).</param>
        /// <param name="timeInForce">Indicates how long an order will remain active before it is executed or expires.</param>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        Task<dynamic> PostNewOrderTest(string symbol, decimal quantity, decimal price, OrderSide side, OrderType orderType = OrderType.LIMIT, TimeInForce timeInForce = TimeInForce.GTC, decimal icebergQty = 0m, long recvWindow = 6000000);

        /// <summary>
        /// Check an order's status.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="orderId">Id of the order to retrieve.</param>
        /// <param name="origClientOrderId">origClientOrderId of the order to retrieve.</param>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        Task<Order> GetOrder(string symbol, long? orderId = null, string origClientOrderId = null, long recvWindow = 6000000);

        /// <summary>
        /// Cancel an active order.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="orderId">Id of the order to cancel.</param>
        /// <param name="origClientOrderId">origClientOrderId of the order to cancel.</param>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        Task<CanceledOrder> CancelOrder(string symbol, long? orderId = null, string origClientOrderId = null, long recvWindow = 6000000);

        /// <summary>
        /// Get all open orders on a symbol.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        Task<IEnumerable<Order>> GetCurrentOpenOrders(string symbol, long recvWindow = 6000000);

        /// <summary>
        /// Get all account orders; active, canceled, or filled.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="orderId">If is set, it will get orders >= that orderId. Otherwise most recent orders are returned.</param>
        /// <param name="limit">Limit of records to retrieve.</param>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        Task<IEnumerable<Order>> GetAllOrders(string symbol, long? orderId = null, int limit = 500, long recvWindow = 6000000);

        /// <summary>
        /// Get current account information.
        /// </summary>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        Task<AccountInfo> GetAccountInfo(long recvWindow = 6000000);

        /// <summary>
        /// Get trades for a specific account and symbol.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        Task<IEnumerable<Trade>> GetTradeList(string symbol, long recvWindow = 6000000);

        /// <summary>
        /// Submit a withdraw request.
        /// </summary>
        /// <param name="asset">Asset to withdraw.</param>
        /// <param name="amount">Amount to withdraw.</param>
        /// <param name="address">Address where the asset will be deposited.</param>
        /// <param name="addressName">Address name.</param>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        Task<WithdrawResponse> Withdraw(string asset, decimal amount, string address, string addressName = "", long recvWindow = 6000000);

        /// <summary>
        /// Fetch deposit history.
        /// </summary>
        /// <param name="asset">Asset you want to see the information for.</param>
        /// <param name="status">Deposit status.</param>
        /// <param name="startTime">Start time. </param>
        /// <param name="endTime">End time.</param>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        Task<DepositHistory> GetDepositHistory(string asset, DepositStatus? status = null, DateTime? startTime = null, DateTime? endTime = null, long recvWindow = 6000000);

        /// <summary>
        /// Fetch withdraw history.
        /// </summary>
        /// <param name="asset">Asset you want to see the information for.</param>
        /// <param name="status">Withdraw status.</param>
        /// <param name="startTime">Start time. </param>
        /// <param name="endTime">End time.</param>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        Task<WithdrawHistory> GetWithdrawHistory(string asset, WithdrawStatus? status = null, DateTime? startTime = null, DateTime? endTime = null, long recvWindow = 6000000);
        #endregion

        #region User Stream 
        /// <summary>
        /// Start a new user data stream.
        /// </summary>
        /// <returns></returns>
        Task<UserStreamInfo> StartUserStream();

        /// <summary>
        /// PING a user data stream to prevent a time out.
        /// </summary>
        /// <param name="listenKey">Listenkey of the user stream to keep alive.</param>
        /// <returns></returns>
        Task<dynamic> KeepAliveUserStream(string listenKey);

        /// <summary>
        /// Close out a user data stream.
        /// </summary>
        /// <param name="listenKey">Listenkey of the user stream to close.</param>
        /// <returns></returns>
        Task<dynamic> CloseUserStream(string listenKey);
        #endregion

        #region WebSocket
        /// <summary>
        /// Listen to the Depth endpoint.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="depthHandler">Handler to be used when a message is received.</param>
        void ListenDepthEndpoint(string symbol, MessageHandler<DepthMessage> messageHandler);

        /// <summary>
        /// Listen to the Kline endpoint.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="interval">Time interval to retreive.</param>
        /// <param name="klineHandler">Handler to be used when a message is received.</param>
        void ListenKlineEndpoint(string symbol, TimeInterval interval, MessageHandler<KlineMessage> messageHandler);

        /// <summary>
        /// Listen to the Trades endpoint.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="tradeHandler">Handler to be used when a message is received.</param>
        void ListenTradeEndpoint(string symbol, MessageHandler<AggregateTradeMessage> messageHandler);

        /// <summary>
        /// Listen to the User Data endpoint.
        /// </summary>
        /// <param name="accountInfoHandler">Handler to be used when a account message is received.</param>
        /// <param name="tradesHandler">Handler to be used when a trade message is received.</param>
        /// <param name="ordersHandler">Handler to be used when a order message is received.</param>
        /// <returns></returns>
        string ListenUserDataEndpoint(MessageHandler<AccountUpdatedMessage> accountInfoHandler, MessageHandler<OrderOrTradeUpdatedMessage> tradesHandler, MessageHandler<OrderOrTradeUpdatedMessage> ordersHandler);
        #endregion
    }
}
