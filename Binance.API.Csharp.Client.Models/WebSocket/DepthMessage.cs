using Binance.API.Csharp.Client.Models.Market;
using System.Collections.Generic;

namespace Binance.API.Csharp.Client.Models.WebSocket
{
    public class DepthMessage
    {
        public string EventType { get; set; }
        public long EventTime { get; set; }
        public string Symbol { get; set; }
        public int UpdateId { get; set; }
        public IEnumerable<OrderBookOffer> Bids { get; set; }
        public IEnumerable<OrderBookOffer> Asks { get; set; }
    }
}
