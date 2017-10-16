using Newtonsoft.Json;

namespace Binance.API.Csharp.Client.Models.WebSocket
{
    public class KlineMessage
    {
        [JsonProperty("e")]
        public string EventType { get; set; }
        [JsonProperty("E")]
        public long EventTime { get; set; }
        [JsonProperty("s")]
        public string Symbol { get; set; }
        [JsonProperty("k")]
        public KlineData KlineInfo { get; set; }

        public class KlineData
        {
            [JsonProperty("t")]
            public long StartTime { get; set; }
            [JsonProperty("T")]
            public long EndTime { get; set; }
            [JsonProperty("s")]
            public string Symbol { get; set; }
            [JsonProperty("i")]
            public string Interval { get; set; }
            [JsonProperty("f")]
            public int FirstTradeId { get; set; }
            [JsonProperty("L")]
            public int LastTradeId { get; set; }
            [JsonProperty("o")]
            public decimal Open { get; set; }
            [JsonProperty("c")]
            public decimal Close { get; set; }
            [JsonProperty("h")]
            public decimal High { get; set; }
            [JsonProperty("l")]
            public decimal Low { get; set; }
            [JsonProperty("v")]
            public decimal Volume { get; set; }
            [JsonProperty("n")]
            public int NumberOfTrades { get; set; }
            [JsonProperty("x")]
            public bool IsFinal { get; set; }
            [JsonProperty("q")]
            public decimal QuoteVolume { get; set; }
            [JsonProperty("V")]
            public decimal ActiveBuyVolume { get; set; }
            [JsonProperty("Q")]
            public decimal ActiveBuyQuoteVolume { get; set; }
        }
    }
}
