﻿using Binance.API.Csharp.Client.Models.Market;
using Binance.API.Csharp.Client.Models.WebSocket;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Binance.API.Csharp.Client.Utils
{
    /// <summary>
    /// Class to parse some specific entities.
    /// </summary>
    public class CustomParser
    {
        /// <summary>
        /// Gets the orderbook data and generates an OrderBook object.
        /// </summary>
        /// <param name="orderBookData">Dynamic containing the orderbook data.</param>
        /// <returns></returns>
        public OrderBook GetParsedOrderBook(dynamic orderBookData)
        {
            var result = new OrderBook
            {
                LastUpdateId = orderBookData.lastUpdateId.Value
            };

            var bids = new List<OrderBookOffer>();
            var asks = new List<OrderBookOffer>();

            foreach (JToken item in ((JArray)orderBookData.bids).ToArray())
            {
	            bids.Add(new OrderBookOffer
	            {
		            Price = decimal.Parse(item[0].ToString(), CultureInfo.InvariantCulture),
		            Quantity = decimal.Parse(item[1].ToString(), CultureInfo.InvariantCulture)
	            });
            }

            foreach (JToken item in ((JArray)orderBookData.asks).ToArray())
            {
	            asks.Add(new OrderBookOffer
	            {
		            Price = decimal.Parse(item[0].ToString(), CultureInfo.InvariantCulture),
		            Quantity = decimal.Parse(item[1].ToString(), CultureInfo.InvariantCulture)
	            });
            }

            result.Bids = bids;
            result.Asks = asks;

            return result;
        }

        /// <summary>
        /// Gets the candlestick data and generates an Candlestick object.
        /// </summary>
        /// <param name="candlestickData">Dynamic containing the candlestick data.</param>
        /// <returns></returns>
        public IEnumerable<Candlestick> GetParsedCandlestick(dynamic candlestickData)
        {
            var result = new List<Candlestick>();

            foreach (JToken item in ((JArray)candlestickData).ToArray())
            {
                result.Add(new Candlestick()
                {
                    OpenTime = long.Parse(item[0].ToString()),
                    Open = decimal.Parse(item[1].ToString(), CultureInfo.InvariantCulture),
                    High = decimal.Parse(item[2].ToString(), CultureInfo.InvariantCulture),
                    Low = decimal.Parse(item[3].ToString(), CultureInfo.InvariantCulture),
                    Close = decimal.Parse(item[4].ToString(), CultureInfo.InvariantCulture),
                    Volume = decimal.Parse(item[5].ToString(), CultureInfo.InvariantCulture),
                    CloseTime = long.Parse(item[6].ToString()),
                    QuoteAssetVolume = decimal.Parse(item[7].ToString(), CultureInfo.InvariantCulture),
                    NumberOfTrades = int.Parse(item[8].ToString()),
                    TakerBuyBaseAssetVolume = decimal.Parse(item[9].ToString(), CultureInfo.InvariantCulture),
                    TakerBuyQuoteAssetVolume = decimal.Parse(item[10].ToString(), CultureInfo.InvariantCulture)
                });
            }

            return result;
        }

        public DepthMessage GetParsedDepthMessage(dynamic messageData)
        {
            var result = new DepthMessage
            {
                EventType = messageData.e,
                EventTime = messageData.E,
                Symbol = messageData.s,
                UpdateId = messageData.u
            };

            var bids = new List<OrderBookOffer>();
            var asks = new List<OrderBookOffer>();

            foreach (JToken item in ((JArray)messageData.b).ToArray())
            {
	            bids.Add(new OrderBookOffer
	            {
		            Price = decimal.Parse(item[0].ToString(), CultureInfo.InvariantCulture),
		            Quantity = decimal.Parse(item[1].ToString(), CultureInfo.InvariantCulture)
	            });
            }

            foreach (JToken item in ((JArray)messageData.a).ToArray())
            {
	            asks.Add(new OrderBookOffer
	            {
		            Price = decimal.Parse(item[0].ToString(), CultureInfo.InvariantCulture),
		            Quantity = decimal.Parse(item[1].ToString(), CultureInfo.InvariantCulture)
	            });
            }

            result.Bids = bids;
            result.Asks = asks;

            return result;
        }

        public DepthPartialMessage GetParsedDepthPartialMessage(dynamic messageData)
        {
            var result = new DepthPartialMessage
            { 
                UpdateId = messageData.lastUpdateId
            };

            var bids = new List<OrderBookOffer>();
            var asks = new List<OrderBookOffer>();

            foreach (JToken item in ((JArray)messageData.bids).ToArray())
            {
	            bids.Add(new OrderBookOffer()
	            {
		            Price = decimal.Parse(item[0].ToString(), CultureInfo.InvariantCulture),
		            Quantity = decimal.Parse(item[1].ToString(), CultureInfo.InvariantCulture)
	            });
            }

            foreach (JToken item in ((JArray)messageData.asks).ToArray())
            {
	            asks.Add(new OrderBookOffer()
	            {
		            Price = decimal.Parse(item[0].ToString(), CultureInfo.InvariantCulture),
		            Quantity = decimal.Parse(item[1].ToString(), CultureInfo.InvariantCulture)
	            });
            }

            result.Bids = bids;
            result.Asks = asks;

            return result;
        }
    }
}
