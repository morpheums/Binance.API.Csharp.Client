# Account Methods
## Post new order
Send in a new order
### Examples:

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
### Method Signature:

```c#
     public async Task<NewOrder> PostNewOrder(string symbol, decimal quantity, decimal price, OrderSide side, OrderType orderType = OrderType.LIMIT, TimeInForce timeInForce = TimeInForce.GTC, decimal icebergQty = 0m, long recvWindow = 5000)
```

## Post test order 
Test new order creation and signature/recvWindow long. Creates and validates a new order but does not send it into the matching engine.
### Example:
 
```c#
    var testOrder = binanceClient.PostNewOrderTest("ethbtc", 1m, 0.1m, OrderSide.BUY, OrderType.LIMIT).Result;
```
### Method Signature:

```c#
     public async Task<dynamic> PostNewOrderTest(string symbol, decimal quantity, decimal price, OrderSide side, OrderType orderType = OrderType.LIMIT, TimeInForce timeInForce = TimeInForce.GTC, decimal icebergQty = 0m, long recvWindow = 5000)
```

## Get order
Check an order's status.
### Example:
 
```c#
    var order = binanceClient.GetOrder("ethbtc", 8982811).Result;
```
### Method Signature:

```c#
    public async Task<Order> GetOrder(string symbol, long? orderId = null, string origClientOrderId = null, long recvWindow = 6000000)
```

## Cancel order 
Cancel an active order.
### Example:
 
```c#
    var canceledOrder = binanceClient.CancelOrder("ethbtc", 9137796).Result;
```
### Method Signature:

```c#
    public async Task<CanceledOrder> CancelOrder(string symbol, long? orderId = null, string origClientOrderId = null, long recvWindow = 6000000)
```

## Get current open orders
Get all open orders on a symbol.
### Example:
 
```c#
    var openOrders = binanceClient.GetCurrentOpenOrders("ethbtc").Result;
```
### Method Signature:

```c#
    public async Task<IEnumerable<Order>> GetCurrentOpenOrders(string symbol, long recvWindow = 6000000)
```

## Get all orders
Get all account orders; active, canceled, or filled.
### Example:
 
```c#
    var allOrders = binanceClient.GetAllOrders("ethbtc").Result;
```
### Method Signature:

```c#
    public async Task<IEnumerable<Order>> GetAllOrders(string symbol, long? orderId = null, int limit = 500, long recvWindow = 6000000)
```

## Get account info
Get current account information.
### Example:
 
```c#
    var accountInfo = binanceClient.GetAccountInfo().Result;
```
### Method Signature:

```c#
    public async Task<AccountInfo> GetAccountInfo(long recvWindow = 6000000)
```

## Get account trade list
Get trades for a specific account and symbol.
### Example:
 
```c#
    var tradeList = binanceClient.GetTradeList("ethbtc").Result;
```
### Method Signature:

```c#
    public async Task<IEnumerable<Trade>> GetTradeList(string symbol, long recvWindow = 6000000)
```

## Withdraw
Submit a withdraw request.
### Example:
 
```c#
     var withdrawResult = binanceClient.Withdraw("eth", 100m, "@YourDepositAddress").Result;
```
### Method Signature:

```c#
    public async Task<WithdrawResponse> Withdraw(string asset, decimal amount, string address, string addressName = "", long recvWindow = 6000000)
```

## Get deposit history
Fetch deposit history.
### Example:
 
```c#
     var depositHistory = binanceClient.GetDepositHistory("neo", DepositStatus.Success).Result;
```
### Method Signature:

```c#
    public async Task<DepositHistory> GetDepositHistory(string asset, DepositStatus? status = null, DateTime? startTime = null, DateTime? endTime = null, long recvWindow = 6000000)
```

## Get withdraw history
Fetch withdraw history.
### Example:
 
```c#
     var withdrawHistory = binanceClient.GetWithdrawHistory("neo").Result;
```
### Method Signature:

```c#
    public async Task<WithdrawHistory> GetWithdrawHistory(string asset, WithdrawStatus? status = null, DateTime? startTime = null, DateTime? endTime = null, long recvWindow = 6000000)
```
