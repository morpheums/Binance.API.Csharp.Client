using Newtonsoft.Json;

namespace Binance.API.Csharp.Client.Models.WebSocket
{
    public class AggregateTradeMessage
    {
        [JsonProperty("e")]
        public string EventType { get; set; }
        [JsonProperty("E")]
        public long EventTime { get; set; }
        [JsonProperty("s")]
        public string Symbol { get; set; }
        [JsonProperty("a")]
        public int AggregatedTradeId { get; set; }
        [JsonProperty("p")]
        public decimal Price { get; set; }
        [JsonProperty("q")]
        public decimal Quantity { get; set; }
        [JsonProperty("f")]
        public int FirstBreakdownTradeId { get; set; }
        [JsonProperty("l")]
        public int LastBreakdownTradeId { get; set; }
        [JsonProperty("T")]
        public long TradeTime { get; set; }
        [JsonProperty("m")]
        public bool BuyerIsMaker { get; set; }
    }
}
