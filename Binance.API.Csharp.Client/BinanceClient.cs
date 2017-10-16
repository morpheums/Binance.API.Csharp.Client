using Binance.API.Csharp.Client.Domain.Abstract;
using Binance.API.Csharp.Client.Domain.Interfaces;
using Binance.API.Csharp.Client.Models.Account;
using Binance.API.Csharp.Client.Models.Enums;
using Binance.API.Csharp.Client.Models.General;
using Binance.API.Csharp.Client.Models.Market;
using Binance.API.Csharp.Client.Models.UserStream;
using Binance.API.Csharp.Client.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Binance.API.Csharp.Client
{
    public class BinanceClient : BinanceClientConstructor, IBinanceClient
    {
        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="apiClient">API client to be used for API calls.</param>
        public BinanceClient(IApiClient apiClient) : base(apiClient)
        {
        }

        #region General
        /// Test connectivity to the Rest API.
        /// </summary>
        /// <returns></returns>
        public async Task<dynamic> TestConnectivity()
        {
            var result = await _apiClient.CallAsync<dynamic>(ApiMethod.GET, EndPoints.TestConnectivity, false);

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }
        /// <summary>
        /// Test connectivity to the Rest API and get the current server time.
        /// </summary>
        /// <returns></returns>
        public async Task<ServerInfo> GetServerTime()
        {
            var result = await _apiClient.CallAsync<ServerInfo>(ApiMethod.GET, EndPoints.CheckServerTime, false);

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }
        #endregion

        #region Market Data
        /// <summary>
        /// Get order book for a particular symbol.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="limit">Limit of records to retrieve.</param>
        /// <returns></returns>
        public async Task<OrderBook> GetOrderBook(string symbol, int limit = 100)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("symbol cannot be empty. ", "symbol");
            }

            var result = await _apiClient.CallAsync<dynamic>(ApiMethod.GET, EndPoints.OrderBook, false, $"symbol={symbol.ToUpper()}&limit={limit}");

            if (result == null)
            {
                throw new Exception();
            }

            var parser = new CustomParser();
            var parsedResult = parser.GetParsedOrderBook(result);

            return parsedResult;
        }

        /// <summary>
        /// Get compressed, aggregate trades. Trades that fill at the time, from the same order, with the same price will have the quantity aggregated.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="limit">Limit of records to retrieve.</param>
        /// <returns></returns>
        public async Task<IEnumerable<AggregateTrade>> GetAggregateTrades(string symbol, int limit = 500)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("symbol cannot be empty. ", "symbol");
            }

            var result = await _apiClient.CallAsync<IEnumerable<AggregateTrade>>(ApiMethod.GET, EndPoints.AggregateTrades, false, $"symbol={symbol.ToUpper()}&limit={limit}");

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        /// <summary>
        /// Kline/candlestick bars for a symbol. Klines are uniquely identified by their open time.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="interval">Time interval to retreive.</param>
        /// <param name="limit">Limit of records to retrieve.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Candlestick>> GetCandleSticks(string symbol, TimeInterval interval, int limit = 500)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("symbol cannot be empty. ", "symbol");
            }

            var result = await _apiClient.CallAsync<dynamic>(ApiMethod.GET, EndPoints.Candlesticks, false, $"symbol={symbol.ToUpper()}&interval={interval.GetDescription()}&limit={limit}");

            if (result == null)
            {
                throw new Exception();
            }

            var parser = new CustomParser();
            var parsedResult = parser.GetParsedCandlestick(result);

            return parsedResult;
        }

        /// <summary>
        /// 24 hour price change statistics.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <returns></returns>
        public async Task<PriceChangeInfo> GetPriceChange24H(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("symbol cannot be empty. ", "symbol");
            }

            var result = await _apiClient.CallAsync<PriceChangeInfo>(ApiMethod.GET, EndPoints.TickerPriceChange24H, false, $"symbol={symbol.ToUpper()}");

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        /// <summary>
        /// Latest price for all symbols.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SymbolPrice>> GetAllPrices()
        {
            var result = await _apiClient.CallAsync<IEnumerable<SymbolPrice>>(ApiMethod.GET, EndPoints.AllPrices, false);

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        /// <summary>
        /// Best price/qty on the order book for all symbols.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<OrderBookTicker>> GetOrderBookTicker()
        {
            var result = await _apiClient.CallAsync<IEnumerable<OrderBookTicker>>(ApiMethod.GET, EndPoints.OrderBookTicker, false);

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }
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
        public async Task<NewOrder> PostNewOrder(string symbol, decimal quantity, decimal price, OrderSide side, OrderType orderType = OrderType.LIMIT, decimal stopPrice = 0m, decimal icebergQty = 0m, TimeInForce timeInForce = TimeInForce.GTC, long recvWindow = 6000000)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("symbol cannot be empty. ", "symbol");
            }
            if (quantity <= 0m)
            {
                throw new ArgumentException("quantity must be greater than zero.", "quantity");
            }
            if (orderType == OrderType.LIMIT && price <= 0m)
            {
                throw new ArgumentException("price must be greater than zero.", "price");
            }

            var args = $"symbol={symbol.ToUpper()}&side={side}&type={orderType}&timeInForce={timeInForce}&quantity={quantity}&price={price}" + (stopPrice > 0m ? $"&stopPrice={stopPrice}" : "") + (icebergQty > 0m ? $"&icebergQty={icebergQty}" : "") + $"&recvWindow={recvWindow}";
            var result = await _apiClient.CallAsync<NewOrder>(ApiMethod.POST, EndPoints.NewOrder, true, args);

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

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
        public async Task<dynamic> PostNewOrderTest(string symbol, decimal quantity, decimal price, OrderSide side, OrderType orderType = OrderType.LIMIT, decimal stopPrice = 0m, decimal icebergQty = 0m, TimeInForce timeInForce = TimeInForce.GTC, long recvWindow = 6000000)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("symbol cannot be empty. ", "symbol");
            }
            if (quantity <= 0)
            {
                throw new ArgumentException("quantity must be greater than zero.", "quantity");
            }
            if (price <= 0)
            {
                throw new ArgumentException("price must be greater than zero.", "price");
            }

            var args = $"symbol={symbol.ToUpper()}&side={side}&type={orderType}&timeInForce={timeInForce}&quantity={quantity}&price={price}" + (stopPrice > 0m ? $"&stopPrice={stopPrice}" : "") + (icebergQty > 0m ? $"&icebergQty={icebergQty}" : "") + $"&recvWindow={recvWindow}";
            var result = await _apiClient.CallAsync<dynamic>(ApiMethod.POST, EndPoints.NewOrderTest, true, args);

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        /// <summary>
        /// Check an order's status.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="orderId">Id of the order to retrieve.</param>
        /// <param name="origClientOrderId">origClientOrderId of the order to retrieve.</param>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        public async Task<Order> GetOrder(string symbol, long? orderId = null, string origClientOrderId = null, long recvWindow = 6000000)
        {
            var args = $"symbol={symbol.ToUpper()}&recvWindow={recvWindow}";

            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("symbol cannot be empty. ", "symbol");
            }

            if (orderId.HasValue)
            {
                args += $"&orderId={orderId.Value}";
            }
            else if (!string.IsNullOrWhiteSpace(origClientOrderId))
            {
                args += $"&origClientOrderId={origClientOrderId}";
            }
            else
            {
                throw new ArgumentException("Either orderId or origClientOrderId must be sent.");
            }

            var result = await _apiClient.CallAsync<Order>(ApiMethod.GET, EndPoints.QueryOrder, true, args);

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        /// <summary>
        /// Cancel an active order.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="orderId">Id of the order to cancel.</param>
        /// <param name="origClientOrderId">origClientOrderId of the order to cancel.</param>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        public async Task<CanceledOrder> CancelOrder(string symbol, long? orderId = null, string origClientOrderId = null, long recvWindow = 6000000)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("symbol cannot be empty. ", "symbol");
            }

            var args = $"symbol={symbol.ToUpper()}&recvWindow={recvWindow}";

            if (orderId.HasValue)
            {
                args += $"&orderId={orderId.Value}";
            }
            else if (string.IsNullOrWhiteSpace(origClientOrderId))
            {
                args += $"&origClientOrderId={origClientOrderId}";
            }
            else
            {
                throw new ArgumentException("Either orderId or origClientOrderId must be sent.");
            }

            var result = await _apiClient.CallAsync<CanceledOrder>(ApiMethod.DELETE, EndPoints.CancelOrder, true, args);

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        /// <summary>
        /// Get all open orders on a symbol.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> GetCurrentOpenOrders(string symbol, long recvWindow = 6000000)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("symbol cannot be empty. ", "symbol");
            }

            var result = await _apiClient.CallAsync<IEnumerable<Order>>(ApiMethod.GET, EndPoints.CurrentOpenOrders, true, $"symbol={symbol.ToUpper()}&recvWindow={recvWindow}");

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        /// <summary>
        /// Get all account orders; active, canceled, or filled.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="orderId">If is set, it will get orders >= that orderId. Otherwise most recent orders are returned.</param>
        /// <param name="limit">Limit of records to retrieve.</param>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> GetAllOrders(string symbol, long? orderId = null, int limit = 500, long recvWindow = 6000000)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("symbol cannot be empty. ", "symbol");
            }

            var result = await _apiClient.CallAsync<IEnumerable<Order>>(ApiMethod.GET, EndPoints.AllOrders, true, $"symbol={symbol.ToUpper()}&limit={limit}&recvWindow={recvWindow}" + (orderId.HasValue ? $"&orderId={orderId.Value}" : ""));

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        /// <summary>
        /// Get current account information.
        /// </summary>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        public async Task<AccountInfo> GetAccountInfo(long recvWindow = 6000000)
        {
            var result = await _apiClient.CallAsync<AccountInfo>(ApiMethod.GET, EndPoints.AccountInformation, true, $"recvWindow={recvWindow}");

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        /// <summary>
        /// Get trades for a specific account and symbol.
        /// </summary>
        /// <param name="symbol">Ticker symbol.</param>
        /// <param name="recvWindow">Specific number of milliseconds the request is valid for.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Trade>> GetTradeList(string symbol, long recvWindow = 6000000)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("symbol cannot be empty. ", "symbol");
            }

            var result = await _apiClient.CallAsync<IEnumerable<Trade>>(ApiMethod.GET, EndPoints.TradeList, true, $"symbol={symbol.ToUpper()}&recvWindow={recvWindow}");

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }
        #endregion

        #region User Stream
        /// <summary>
        /// Start a new user data stream.
        /// </summary>
        /// <returns></returns>
        public async Task<UserStreamInfo> StartUserStream()
        {
            var result = await _apiClient.CallAsync<UserStreamInfo>(ApiMethod.POST, EndPoints.StartUserStream, false);

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        /// <summary>
        /// PING a user data stream to prevent a time out.
        /// </summary>
        /// <param name="listenKey">Listenkey of the user stream to keep alive.</param>
        /// <returns></returns>
        public async Task<dynamic> KeepAliveUserStream(string listenKey)
        {
            if (string.IsNullOrWhiteSpace(listenKey))
            {
                throw new ArgumentException("listenKey cannot be empty. ", "listenKey");
            }

            var result = await _apiClient.CallAsync<dynamic>(ApiMethod.PUT, EndPoints.KeepAliveUserStream, false, $"listenKey={listenKey}");

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        /// <summary>
        /// Close out a user data stream.
        /// </summary>
        /// <param name="listenKey">Listenkey of the user stream to close.</param>
        /// <returns></returns>
        public async Task<dynamic> CloseUserStream(string listenKey)
        {
            if (string.IsNullOrWhiteSpace(listenKey))
            {
                throw new ArgumentException("listenKey cannot be empty. ", "listenKey");
            }

            var result = await _apiClient.CallAsync<dynamic>(ApiMethod.DELETE, EndPoints.CloseUserStream, false, $"listenKey={listenKey}");

            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }
        #endregion
    }
}
