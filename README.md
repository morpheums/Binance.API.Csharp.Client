# Binance API Csharp Client
C#.NET client for Binance API.

## Getting Started
Create an instance of the **APIClient** which receive the following parameters:

* **ApiKey** - *Key used to authenticate within the API.*
* **ApiSecret** - *API secret used to signed some API calls.*
* **ApiUrl (Optional)** - *Base URL of the API.*
```
    var apiClient = new ApiClient("@Your-API-Key", "@Your-API-Secret");
```

Create an instance of the **BinanceClient** which will receive the previously created APIClient
 
```
    var binanceClient = new BinanceClient(apiClient);
```

## General Methods
### Test connectivity
Test connectivity to the Rest API.
```
    var test = binanceClient.TestConnectivity().Result;
```
### Check server time
Test connectivity to the Rest API and get the current server time.
```
    var serverTime = binanceClient.GetServerTime().Result;
```
## Market Data Methods
### Get order book
```
    var orderBook = binanceClient.GetOrderBook("ethbtc").Result;
```
### Get compressed/aggregate trades list
Get compressed, aggregate trades. Trades that fill at the time, from the same order, with the same price will have the quantity aggregated.
```
    var aggregateTrades = binanceClient.GetAggregateTrades("ethbtc").Result;
```
### Get kline/candlesticks
Kline/candlestick bars for a symbol. Klines are uniquely identified by their open time.
```
    var candlestick = binanceClient.GetCandleSticks("ethbtc", TimeInterval.Minutes_15).Result;
```
### Get 24hr ticker price change statistics
24 hour price change statistics.
```
    var priceChangeInfo = binanceClient.GetPriceChange24H("ethbtc").Result;
```
### Get symbols price ticker
Latest price for all symbols.
```
    var tickerPrices = binanceClient.GetAllPrices().Result;
```
### Get symbols order book ticker
Best price/qty on the order book for all symbols.
```
    var orderBookTickers = binanceClient.GetOrderBookTicker().Result;
```
## Account Methods
### Post new buy order (LIMIT)
Send in a new order
```
    var newOrder = binanceClient.PostNewOrder("ethbtc", 1m, 0.04m, OrderType.LIMIT, OrderSide.BUY).Result;
```
### Post new buy order (MARKET)
Send in a new order
```
    var newOrder = binanceClient.PostNewOrder("ethbtc", 1m, 0.04m, OrderType.MARKET, OrderSide.BUY).Result;
```
### Post new sell order (LIMIT)
Send in a new order
```
    var newOrder = binanceClient.PostNewOrder("ethbtc", 1m, 0.04m, OrderType.LIMIT, OrderSide.SELL).Result;
```
### Post new sell order (MARKET)
Send in a new order
```
    var newOrder = binanceClient.PostNewOrder("ethbtc", 1m, 0.04m, OrderType.MARKET, OrderSide.SELL).Result;
```
### Post test order 
Test new order creation and signature/recvWindow long. Creates and validates a new order but does not send it into the matching engine.
```
    var testOrder = binanceClient.PostNewOrderTest("ethbtc", 1m, 0.1m, OrderType.LIMIT, OrderSide.BUY).Result;
```
### Get order
Check an order's status.
```
    var order = binanceClient.GetOrder("ethbtc", 8982811).Result;
```
 
### Cancel order 
Cancel an active order.
```
    var canceledOrder = binanceClient.CancelOrder("ethbtc", 9137796).Result;
```
### Get current open orders
Get all open orders on a symbol.
```
    var openOrders = binanceClient.GetCurrentOpenOrders("ethbtc").Result;
```
### Get all orders
Get all account orders; active, canceled, or filled.
```
    var allOrders = binanceClient.GetAllOrders("ethbtc").Result;
```
### Get account info
Get current account information.
```
    var accountInfo = binanceClient.GetAccountInfo().Result;
```
### Get account trade list
Get trades for a specific account and symbol.
```
    var tradeList = binanceClient.GetTradeList("ethbtc").Result;
```
## User Stream Methods
### Start user stream
Start a new user data stream.
```
    var listenKey = binanceClient.StartUserStream().Result.ListenKey;
```
### Keep alive user data stream
PING a user data stream to prevent a time out.
```
    var ping = binanceClient.KeepAliveUserStream("@ListenKey").Result;
```
### Close user data stream
Close out a user data stream.
```
    var resut = binanceClient.CloseUserStream("@ListenKey").Result;
```
