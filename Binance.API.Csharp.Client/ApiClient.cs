﻿using Binance.API.Csharp.Client.Domain.Abstract;
using Binance.API.Csharp.Client.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Binance.API.Csharp.Client.Utils;
using Binance.API.Csharp.Client.Models.Enums;
using WebSocketSharp;
using Binance.API.Csharp.Client.Models.WebSocket;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Binance.API.Csharp.Client
{
    public class ApiClient : ApiClientAbstract, IApiClient
    {

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="apiKey">Key used to authenticate within the API.</param>
        /// <param name="apiSecret">API secret used to signed API calls.</param>
        /// <param name="apiUrl">API base url.</param>
        public ApiClient(string apiKey, string apiSecret, string apiUrl = @"https://us.binance.com", string webSocketEndpoint = @"wss://stream.binance.com:9443/ws/", bool addDefaultHeaders = true) : base(apiKey, apiSecret, apiUrl, webSocketEndpoint, addDefaultHeaders)
        {
        }


        /// <summary>
        /// Calls API Methods.
        /// </summary>
        /// <typeparam name="T">Type to which the response content will be converted.</typeparam>
        /// <param name="method">HTTPMethod (POST-GET-PUT-DELETE)</param>
        /// <param name="endpoint">Url endpoing.</param>
        /// <param name="isSigned">Specifies if the request needs a signature.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns></returns>
        public async Task<T> CallAsync<T>(ApiMethod method, string endpoint, bool isSigned = false, string parameters = null)
        {
            var finalEndpoint = endpoint + (string.IsNullOrWhiteSpace(parameters) ? "" : $"?{parameters}");

            if (isSigned)
            {
                // Joining provided parameters
                parameters += (!string.IsNullOrWhiteSpace(parameters) ? "&timestamp=" : "timestamp=") + (Utilities.GenerateTimeStamp(DateTime.Now.ToUniversalTime()));

                // Creating request signature
                var signature = Utilities.GenerateSignature(_apiSecret, parameters);
                finalEndpoint = $"{endpoint}?{parameters}&signature={signature}";
            }

            var request = new HttpRequestMessage(Utilities.CreateHttpMethod(method.ToString()), finalEndpoint);
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                // Api return is OK
                response.EnsureSuccessStatusCode();

                // Get the result
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                // Serialize and return result
                return JsonConvert.DeserializeObject<T>(result);
            }

            // We received an error
            if (response.StatusCode == HttpStatusCode.GatewayTimeout)
            {
                throw new Exception("Api Request Timeout.");
            }

            // Get te error code and message
            var e = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            // Error Values
            var eCode = 0;
            string eMsg = "";
            if (e.IsValidJson())
            {
                try
                {
                    var i = JObject.Parse(e);

                    eCode = i["code"]?.Value<int>() ?? 0;
                    eMsg = i["msg"]?.Value<string>();
                }
                catch { }
            }
            throw new Exception(string.Format("Api Error Code: {0} Message: {1}", eCode, eMsg));
        }

        /// <summary>
        /// Connects to a Websocket endpoint.
        /// </summary>
        /// <typeparam name="T">Type used to parsed the response message.</typeparam>
        /// <param name="parameters">Paremeters to send to the Websocket.</param>
        /// <param name="messageDelegate">Deletage to callback after receive a message.</param>
        /// <param name="useCustomParser">Specifies if needs to use a custom parser for the response message.</param>
        public WebSocket ConnectToWebSocket<T>(string parameters, MessageHandler<T> messageHandler, Action<CloseEventArgs> onClose = null, bool useCustomParser = false)
        {
            var finalEndpoint = _webSocketEndpoint + parameters;

            var ws = new WebSocket(finalEndpoint);

            ws.OnMessage += (sender, e) =>
            {
                dynamic eventData = null;

                if (useCustomParser)
                {
                    var customParser = new CustomParser();
                    var datum = JsonConvert.DeserializeObject<dynamic>(e.Data);
                    if (datum is JObject jobject)
                    {
                        if (jobject["lastUpdateId"] != null)
                            eventData = customParser.GetParsedDepthPartialMessage(jobject);
                        else
                            eventData = customParser.GetParsedDepthMessage(jobject);
                    }
                }
                else
                {
                    eventData = JsonConvert.DeserializeObject<T>(e.Data);
                }

                messageHandler(eventData);
            };

            ws.OnClose += (sender, e) =>
            {
                _openSockets.Remove(ws);
                onClose?.Invoke(e);
            };

            ws.OnError += (sender, e) =>
            { 
                if (ws.ReadyState != WebSocketState.Open)
                    _openSockets.Remove(ws);
            };
            ws.OnOpen += (s, e) => _openSockets.Add(ws);
            ws.Connect();
            return ws;
        }

        /// <summary>
        /// Connects to a UserData Websocket endpoint.
        /// </summary>
        /// <param name="parameters">Paremeters to send to the Websocket.</param>
        /// <param name="accountHandler">Deletage to callback after receive a account info message.</param>
        /// <param name="tradeHandler">Deletage to callback after receive a trade message.</param>
        /// <param name="orderHandler">Deletage to callback after receive a order message.</param>
        public WebSocket ConnectToUserDataWebSocket(string parameters, MessageHandler<AccountUpdatedMessage> accountHandler, MessageHandler<OrderOrTradeUpdatedMessage> tradeHandler, MessageHandler<OrderOrTradeUpdatedMessage> orderHandler, Action<CloseEventArgs> onClose = null)
        {
            var finalEndpoint = _webSocketEndpoint + parameters;

            var ws = new WebSocket(finalEndpoint);

            ws.OnMessage += (sender, e) =>
            {
                var eventData = JsonConvert.DeserializeObject<dynamic>(e.Data);

                switch ((string)eventData.e.Value)
                {
                    case "outboundAccountInfo":
                        accountHandler(JsonConvert.DeserializeObject<AccountUpdatedMessage>(e.Data));
                        break;
                    case "executionReport":
                        var isTrade = ((string)eventData.x).ToLower() == "trade";

                        if (isTrade)
                        {
                            tradeHandler(JsonConvert.DeserializeObject<OrderOrTradeUpdatedMessage>(e.Data));
                        }
                        else
                        {
                            orderHandler(JsonConvert.DeserializeObject<OrderOrTradeUpdatedMessage>(e.Data));
                        }
                        break;
                }
            };

            ws.OnClose += (sender, e) =>
            {
                _openSockets.Remove(ws);
                onClose?.Invoke(e);
            };

            ws.OnError += (sender, e) =>
            {
                if (ws.ReadyState != WebSocketState.Open)
                    _openSockets.Remove(ws);
            };
            ws.OnOpen += (s, e) => _openSockets.Add(ws);
            ws.Connect();
            return ws;
        }
    }
}
