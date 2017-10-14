using Newtonsoft.Json;

namespace Binance.API.Csharp.Client.Models.Account
{
    public class CanceledOrder
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("orderId")]
        public int OrderId { get; set; }
        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }
        [JsonProperty("origClientOrderId ")]
        public string OrigClientOrderId { get; set; }
    }
}
