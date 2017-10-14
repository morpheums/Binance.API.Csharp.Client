using Newtonsoft.Json;

namespace Binance.API.Csharp.Client.Models.UserStream
{
    public class UserStreamInfo
    {
        [JsonProperty("listenKey")]
        public string ListenKey { get; set; }
    }
}
