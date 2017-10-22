# Market Data Methods
## Get order book
Get order book for a particular symbol.
### Example:
 
```c#
    var orderBook = binanceClient.GetOrderBook("ethbtc").Result;
```
### Method Signature:

```c#
    public async Task<OrderBook> GetOrderBook(string symbol, int limit = 100)
```

## Get compressed/aggregate trades list
Get compressed, aggregate trades. Trades that fill at the time, from the same order, with the same price will have the quantity aggregated.
### Example:
 
```c#
    var aggregateTrades = binanceClient.GetAggregateTrades("ethbtc").Result;
```
### Method Signature:

```c#
    public async Task<IEnumerable<AggregateTrade>> GetAggregateTrades(string symbol, int limit = 500)
```

## Get kline/candlesticks
Kline/candlestick bars for a symbol. Klines are uniquely identified by their open time.
### Example:
 
```c#
    var candlestick = binanceClient.GetCandleSticks("ethbtc", TimeInterval.Minutes_15).Result;
```
### Method Signature:

```c#
    public async Task<IEnumerable<Candlestick>> GetCandleSticks(string symbol, TimeInterval interval, int limit = 500)
```

## Get 24hr ticker price change statistics
24 hour price change statistics.
### Example:
 
```c#
    var priceChangeInfo = binanceClient.GetPriceChange24H("ethbtc").Result;
```
### Method Signature:

```c#
    public async Task<PriceChangeInfo> GetPriceChange24H(string symbol)
```

## Get symbols price ticker
Latest price for all symbols.
### Example:
 
```c#
    var tickerPrices = binanceClient.GetAllPrices().Result;
```
### Method Signature:

```c#
    public async Task<IEnumerable<SymbolPrice>> GetAllPrices()
```

## Get symbols order book ticker
Best price/qty on the order book for all symbols.
### Example:
 
```c#
    var orderBookTickers = binanceClient.GetOrderBookTicker().Result;
```
### Method Signature:

```c#
    public async Task<IEnumerable<OrderBookTicker>> GetOrderBookTicker()
```
