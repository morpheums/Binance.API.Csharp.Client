using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Csharp.Client.Models.Account
{
    public class WithdrawResponse
    {
        [JsonProperty("msg")]
        public string Msg { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
