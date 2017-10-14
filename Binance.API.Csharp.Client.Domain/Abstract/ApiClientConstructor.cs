using System;
using System.Net.Http;

namespace Binance.API.Csharp.Client.Domain.Abstract
{
    public abstract class ApiClientConstructor
    {
        /// <summary>
        /// Secret used to authenticate within the API.
        /// </summary>
        public readonly string _apiUrl = "";
        
        /// <summary>
        /// Key used to authenticate within the API.
        /// </summary>
        public readonly string _apiKey = "";

        /// <summary>
        /// API secret used to signed API calls.
        /// </summary>
        public readonly string _apiSecret = "";

        /// <summary>
        /// HttpClient to be used to call the API.
        /// </summary>
        public readonly HttpClient _httpClient;

        /// <summary>
        /// Defines the constructor of the Api Client.
        /// </summary>
        /// <param name="apiKey">Key used to authenticate within the API.</param>
        /// <param name="apiSecret">API secret used to signed API calls.</param>
        /// <param name="apiUrl">API based url.</param>
        public ApiClientConstructor(string apiKey, string apiSecret, string apiUrl = @"https://www.binance.com")
        {
            _apiUrl = apiUrl;
            _apiKey = apiKey;
            _apiSecret = apiSecret;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_apiUrl)
            };
            ConfigureHttpClient();
        }

        /// <summary>
        /// Configures the HTTPClient.
        /// </summary>
        private void ConfigureHttpClient() {
            _httpClient.DefaultRequestHeaders
                 .Add("X-MBX-APIKEY", _apiKey);

            _httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
