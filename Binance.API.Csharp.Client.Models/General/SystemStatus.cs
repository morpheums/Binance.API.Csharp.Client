using Binance.API.Csharp.Client.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Csharp.Client.Models.General
{
    public class SystemStatus
    {

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}
