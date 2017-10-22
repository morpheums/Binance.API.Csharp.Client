# Websocket Methods
## Depth messages
Listen to the Depth endpoint.
### Example:
 
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
### Method Signature:

```c#
    public void ListenDepthEndpoint(string symbol, MessageHandler<DepthMessage> depthHandler)
```

## KLine messages
Listen to the Kline endpoint.
### Example:
 
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
### Method Signature:

```c#
    public void ListenKlineEndpoint(string symbol, TimeInterval interval, MessageHandler<KlineMessage> klineHandler)
```

## Trades messages
Listen to the Trades endpoint.
### Example:
 
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
### Method Signature:

```c#
    public void ListenTradeEndpoint(string symbol, MessageHandler<AggregateTradeMessage> tradeHandler)
```

## User Data messages
Listen to the User Data endpoint.
### Example:
 
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
### Method Signature:

```c#
    public string ListenUserDataEndpoint(MessageHandler<AccountUpdatedMessage> accountInfoHandler, MessageHandler<OrderOrTradeUpdatedMessage> tradesHandler, MessageHandler<OrderOrTradeUpdatedMessage> ordersHandler)
```
