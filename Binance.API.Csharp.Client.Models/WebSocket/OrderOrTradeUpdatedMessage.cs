using Newtonsoft.Json;

namespace Binance.API.Csharp.Client.Models.WebSocket
{
    public class OrderOrTradeUpdatedMessage
    {
        [JsonProperty("e")]
        public string OrderOrTradeReport { get; set; }
        [JsonProperty("E")]
        public long EventTime { get; set; }
        [JsonProperty("s")]
        public string Symbol { get; set; }
        [JsonProperty("c")]
        public string NewClientOrderId { get; set; } 
        [JsonProperty("S")]
        public string Side { get; set; }
        [JsonProperty("o")]
        public string Type { get; set; }
        [JsonProperty("f")]
        public string TimeInForce { get; set; }
        [JsonProperty("q")]
        public decimal OriginalQuantity { get; set; }
        [JsonProperty("p")]
        public decimal Price { get; set; }
        [JsonProperty("P")]
        public decimal StopPrice { get; set; }
        [JsonProperty("F")]
        public decimal IcebergQuantity { get; set; }
        [JsonProperty("g")]
        public int g { get; set; }

        [JsonProperty("C")]
        public string OriginalClientOrderId { get; set; }
        [JsonProperty("x")]
        public string ExecutionType { get; set; }
        [JsonProperty("X")]
        public string Status { get; set; }
        [JsonProperty("r")]
        public string RejectReason { get; set; }
        [JsonProperty("i")]
        public int OrderId { get; set; }
        [JsonProperty("l")]
        public decimal LastFilledTradeQuantity { get; set; }
        [JsonProperty("z")]
        public decimal FilledTradesAccumulatedQuantity { get; set; }
        [JsonProperty("L")]
        public decimal LastFilledTradePrice { get; set; }
        [JsonProperty("n")]
        public decimal Commission { get; set; }
        [JsonProperty("N")]
        public string CommissionAsset { get; set; }
        [JsonProperty("T")]
        public long TradeTime { get; set; }
        [JsonProperty("t")]
        public int TradeId { get; set; }
        [JsonProperty("I")]
        public int I { get; set; }
        [JsonProperty("w")]
        public bool IsOrderWorking { get; set; }
        [JsonProperty("m")]
        public bool BuyerIsMaker { get; set; }
        [JsonProperty("M")]
        public bool M { get; set; }
        [JsonProperty("O")]
        public int O { get; set; }
        [JsonProperty("Z")]
        public decimal Z { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
