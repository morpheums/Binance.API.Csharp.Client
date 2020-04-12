using Newtonsoft.Json;
using System.Collections.Generic;

namespace Binance.API.Csharp.Client.Models.Account
{
    public class Deposit
    {
        [JsonProperty("insertTime")]
        public long InsertTime { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("asset")]
        public string Asset { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("addressTag")]
        public string AddressTag { get; set; }
        [JsonProperty("txId")]
        public string TxId { get; set; }
    }

    public class DepositHistory
    {
        [JsonProperty("depositList")]
        public IEnumerable<Deposit> DepositList { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
    }

}
