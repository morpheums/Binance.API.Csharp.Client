using Newtonsoft.Json;
using System.Collections.Generic;

namespace Binance.API.Csharp.Client.Models.Account
{
    public class WithdrawHistory
    {
        [JsonProperty("withdrawList")]
        public IEnumerable<Deposit> WithdrawList { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
    }

    public class Withdraw
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("txId")]
        public string TxId { get; set; }
        [JsonProperty("asset")]
        public string Asset { get; set; }
        [JsonProperty("applyTime")]
        public long ApplyTime { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
