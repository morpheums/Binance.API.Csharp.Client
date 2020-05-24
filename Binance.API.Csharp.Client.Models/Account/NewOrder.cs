using Newtonsoft.Json;

namespace Binance.API.Csharp.Client.Models.Account
{
    public class NewOrder
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("orderId")]
        public long OrderId { get; set; }
        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }
        [JsonProperty("transactTime")]
        public long TransactTime { get; set; }
    }
}
