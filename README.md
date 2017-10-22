# Binance API Csharp Client ![Icon](https://github.com/morpheums/Binance.API.Csharp.Client/blob/master/Binance.API.Csharp.Client/BinanceLogo.png?raw=true)
### C#.NET client for Binance Exchange API.
[![NuGet](https://img.shields.io/badge/nuget-v1.1.0-blue.svg?style=plastic)](https://www.nuget.org/packages/Binance.API.Csharp.Client)
[![NuGet](https://img.shields.io/nuget/dt/Binance.API.Csharp.Client.svg?style=plastic)](https://www.nuget.org/packages/Binance.API.Csharp.Client)

## Features
- Complete implementation of the Binance API.
- Binance WebSockets implementation.
- Transactions validation using [Binance Trading Rules](https://support.binance.com/hc/en-us/articles/115000594711-Trading-Rule)
- API results parsed to concrete objects for better ease of usage.
- Test project included with all posible API calls.

## Installation

**Nuget Package Manager**
```
PM> Install-Package Binance.API.Csharp.Client
```
**.NET CLI**
```
dotnet add package Binance.API.Csharp.Client
```
## Getting Started
Create an instance of the **APIClient** which receive the following parameters:

* **ApiKey** - *Key used to authenticate within the API.*
* **ApiSecret** - *API secret used to signed some API calls.*
* **ApiUrl (Optional)** - *Base URL of the API.*
```c#
    var apiClient = new ApiClient("@Your-API-Key", "@Your-API-Secret");
```

Create an instance of the **BinanceClient** which will receive the previously created APIClient
 
```c#
    var binanceClient = new BinanceClient(apiClient);
```

## General Methods
### Test connectivity
Test connectivity to the Rest API.
<details>
 <summary>Example</summary>
 
```c#
    var test = binanceClient.TestConnectivity().Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<dynamic> TestConnectivity()
```
</details>

### Check server time
Test connectivity to the Rest API and get the current server time.
<details>
 <summary>Example</summary>
 
```c#
    var serverTime = binanceClient.GetServerTime().Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<ServerInfo> GetServerTime()
```
</details>

## Market Data Methods
### Get order book
Get order book for a particular symbol.
<details>
 <summary>Example</summary>
 
```c#
    var orderBook = binanceClient.GetOrderBook("ethbtc").Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<OrderBook> GetOrderBook(string symbol, int limit = 100)
```
</details>

### Get compressed/aggregate trades list
Get compressed, aggregate trades. Trades that fill at the time, from the same order, with the same price will have the quantity aggregated.
<details>
 <summary>Example</summary>
 
```c#
    var aggregateTrades = binanceClient.GetAggregateTrades("ethbtc").Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<IEnumerable<AggregateTrade>> GetAggregateTrades(string symbol, int limit = 500)
```
</details>

### Get kline/candlesticks
Kline/candlestick bars for a symbol. Klines are uniquely identified by their open time.
<details>
 <summary>Example</summary>
 
```c#
    var candlestick = binanceClient.GetCandleSticks("ethbtc", TimeInterval.Minutes_15).Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<IEnumerable<Candlestick>> GetCandleSticks(string symbol, TimeInterval interval, int limit = 500)
```
</details>

### Get 24hr ticker price change statistics
24 hour price change statistics.
<details>
 <summary>Example</summary>
 
```c#
    var priceChangeInfo = binanceClient.GetPriceChange24H("ethbtc").Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<PriceChangeInfo> GetPriceChange24H(string symbol)
```
</details>

### Get symbols price ticker
Latest price for all symbols.
<details>
 <summary>Example</summary>
 
```c#
    var tickerPrices = binanceClient.GetAllPrices().Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<IEnumerable<SymbolPrice>> GetAllPrices()
```
</details>

### Get symbols order book ticker
Best price/qty on the order book for all symbols.
<details>
 <summary>Example</summary>
 
```c#
    var orderBookTickers = binanceClient.GetOrderBookTicker().Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<IEnumerable<OrderBookTicker>> GetOrderBookTicker()
```
</details>

## Account Methods
### Post new order
Send in a new order
<details>
 <summary>Examples</summary>

Post new order (LIMIT)
```c#
    var buyOrder = binanceClient.PostNewOrder("ethbtc", 1m, 0.045m, OrderSide.BUY).Result;
    var sellOrder = binanceClient.PostNewOrder("ethbtc", 1m, 0.04m, OrderSide.SELL).Result;
```
Post new order (MARKET)
```c#
    var buyMarketOrder = binanceClient.PostNewOrder("ethbtc", 0.01m, 0m, OrderSide.BUY, OrderType.MARKET).Result;
    var sellMarketOrder = binanceClient.PostNewOrder("ethbtc", 0.01m, 0m, OrderSide.SELL, OrderType.MARKET).Result;
```
Post new iceberg order
```c#
    var icebergOrder = binanceClient.PostNewOrder("ethbtc", 0.01m, 0m, OrderSide.BUY, OrderType.MARKET, icebergQty: 2m).Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<NewOrder> PostNewOrder(string symbol, decimal quantity, decimal price, OrderType orderType, OrderSide side, TimeInForce timeInForce = TimeInForce.GTC, long recvWindow = 6000000)
```
</details>

### Post test order 
Test new order creation and signature/recvWindow long. Creates and validates a new order but does not send it into the matching engine.
<details>
 <summary>Example</summary>
 
```c#
    var testOrder = binanceClient.PostNewOrderTest("ethbtc", 1m, 0.1m, OrderType.LIMIT, OrderSide.BUY).Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<dynamic> PostNewOrderTest(string symbol, decimal quantity, decimal price, OrderType orderType, OrderSide side, TimeInForce timeInForce = TimeInForce.GTC, long recvWindow = 6000000)
```
</details>

### Get order
Check an order's status.
<details>
 <summary>Example</summary>
 
```c#
    var order = binanceClient.GetOrder("ethbtc", 8982811).Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<Order> GetOrder(string symbol, long? orderId = null, string origClientOrderId = null, long recvWindow = 6000000)
```
</details>

 ### Cancel order 
Cancel an active order.
<details>
 <summary>Example</summary>
 
```c#
    var canceledOrder = binanceClient.CancelOrder("ethbtc", 9137796).Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<CanceledOrder> CancelOrder(string symbol, long? orderId = null, string origClientOrderId = null, long recvWindow = 6000000)
```
</details>

### Get current open orders
Get all open orders on a symbol.
<details>
 <summary>Example</summary>
 
```c#
    var openOrders = binanceClient.GetCurrentOpenOrders("ethbtc").Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<IEnumerable<Order>> GetCurrentOpenOrders(string symbol, long recvWindow = 6000000)
```
</details>

### Get all orders
Get all account orders; active, canceled, or filled.
<details>
 <summary>Example</summary>
 
```c#
    var allOrders = binanceClient.GetAllOrders("ethbtc").Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<IEnumerable<Order>> GetAllOrders(string symbol, long? orderId = null, int limit = 500, long recvWindow = 6000000)
```
</details>

### Get account info
Get current account information.
<details>
 <summary>Example</summary>
 
```c#
    var accountInfo = binanceClient.GetAccountInfo().Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<AccountInfo> GetAccountInfo(long recvWindow = 6000000)
```
</details>

### Get account trade list
Get trades for a specific account and symbol.
<details>
 <summary>Example</summary>
 
```c#
    var tradeList = binanceClient.GetTradeList("ethbtc").Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<IEnumerable<Trade>> GetTradeList(string symbol, long recvWindow = 6000000)
```
</details>

### Withdraw
Submit a withdraw request.
<details>
 <summary>Example</summary>
 
```c#
     var withdrawResult = binanceClient.Withdraw("eth", 100m, "@YourDepositAddress").Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<WithdrawResponse> Withdraw(string asset, decimal amount, string address, string addressName = "", long recvWindow = 6000000)
```
</details>

### Get deposit history
Fetch deposit history.
<details>
 <summary>Example</summary>
 
```c#
     var depositHistory = binanceClient.GetDepositHistory("neo", DepositStatus.Success).Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<DepositHistory> GetDepositHistory(string asset, DepositStatus? status = null, DateTime? startTime = null, DateTime? endTime = null, long recvWindow = 6000000)
```
</details>

### Get withdraw history
Fetch withdraw history.
<details>
 <summary>Example</summary>
 
```c#
     var withdrawHistory = binanceClient.GetWithdrawHistory("neo").Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<WithdrawHistory> GetWithdrawHistory(string asset, WithdrawStatus? status = null, DateTime? startTime = null, DateTime? endTime = null, long recvWindow = 6000000)
```
</details>

## User Stream Methods
### Start user stream
Start a new user data stream.
<details>
 <summary>Example</summary>
 
```c#
    var listenKey = binanceClient.StartUserStream().Result.ListenKey;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<UserStreamInfo> StartUserStream()
```
</details>

### Keep alive user data stream
PING a user data stream to prevent a time out.
<details>
 <summary>Example</summary>
 
```c#
    var ping = binanceClient.KeepAliveUserStream("@ListenKey").Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<dynamic> KeepAliveUserStream(string listenKey)
```
</details>

### Close user data stream
Close out a user data stream.
<details>
 <summary>Example</summary>
 
```c#
    var resut = binanceClient.CloseUserStream("@ListenKey").Result;
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public async Task<dynamic> CloseUserStream(string listenKey)
```
</details>

## Websocket Methods
### Depth messages
Listen to the Depth endpoint.
<details>
 <summary>Example</summary>
 
```c#
    private void DepthHandler(DepthMessage messageData)
    {
        var depthData = messageData;
    }

    public void TestDepthEndpoint()
    {
        binanceClient.ListenDepthEndpoint("ethbtc", DepthHandler);
        Thread.Sleep(50000);
    }
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public void ListenDepthEndpoint(string symbol, MessageHandler<DepthMessage> depthHandler)
```
</details>

### KLine messages
Listen to the Kline endpoint.
<details>
 <summary>Example</summary>
 
```c#
    private void KlineHandler(KlineMessage messageData)
    {
        var klineData = messageData;
    }

    public void TestKlineEndpoint()
    {
        binanceClient.ListenKlineEndpoint("ethbtc", TimeInterval.Minutes_1, KlineHandler);
        Thread.Sleep(50000);
    }
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public void ListenKlineEndpoint(string symbol, TimeInterval interval, MessageHandler<KlineMessage> klineHandler)
```
</details>

### Trades messages
Listen to the Trades endpoint.
<details>
 <summary>Example</summary>
 
```c#
    private void AggregateTradesHandler(AggregateTradeMessage messageData)
    {
        var aggregateTrades = messageData;
    }

    public void AggregateTestTradesEndpoint()
    {
        binanceClient.ListenTradeEndpoint("ethbtc", AggregateTradesHandler);
        Thread.Sleep(50000);
    }
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public void ListenTradeEndpoint(string symbol, MessageHandler<AggregateTradeMessage> tradeHandler)
```
</details>

### User Data messages
Listen to the User Data endpoint.
<details>
 <summary>Example</summary>
 
```c#
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

    public void TestUserDataEndpoint()
    {
        binanceClient.ListenUserDataEndpoint(AccountHandler, TradesHandler, OrdersHandler);
        Thread.Sleep(50000);
    }
```
</details>
<details>
 <summary>Method Signature</summary>

```c#
    public string ListenUserDataEndpoint(MessageHandler<AccountUpdatedMessage> accountInfoHandler, MessageHandler<OrderOrTradeUpdatedMessage> tradesHandler, MessageHandler<OrderOrTradeUpdatedMessage> ordersHandler)
```
</details>


## License

Binance.API.Csharp.Client is open-sourced software licensed under the [MIT license](http://opensource.org/licenses/MIT)
