using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Csharp.Client.Models.Market.TradingRules
{
    public class Symbol
    {
        [JsonProperty("symbol")]
        public string SymbolName { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("baseAsset")]
        public string BaseAsset { get; set; }
        [JsonProperty("baseAssetPrecision")]
        public int BaseAssetPrecision { get; set; }
        [JsonProperty("quoteAsset")]
        public string QuoteAsset { get; set; }
        [JsonProperty("quotePrecision")]
        public int QuotePrecision { get; set; }
        [JsonProperty("orderTypes")]
        public IEnumerable<string> OrderTypes { get; set; }
        [JsonProperty("icebergAllowed")]
        public bool IcebergAllowed { get; set; }
        [JsonProperty("filters")]
        public IEnumerable<Filter> Filters { get; set; }
    }
}
