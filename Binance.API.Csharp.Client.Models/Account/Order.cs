using Newtonsoft.Json;

namespace Binance.API.Csharp.Client.Models.Account
{
    public class Order
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("orderId")]
        public int OrderId { get; set; }
        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("origQty")]
        public decimal OrigQty { get; set; }
        [JsonProperty("executedQty")]
        public decimal ExecutedQty { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("timeInForce")]
        public string TimeInForce { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("side")]
        public string Side { get; set; }
        [JsonProperty("stopPrice")]
        public decimal StopPrice { get; set; }
        [JsonProperty("icebergQty")]
        public decimal IcebergQty { get; set; }
        [JsonProperty("time")]
        public long Time { get; set; }
    }
}
