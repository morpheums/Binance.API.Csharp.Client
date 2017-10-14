using Binance.API.Csharp.Client.Domain.Interfaces;
using Binance.API.Csharp.Client.Models.Enums;

namespace Binance.API.Csharp.Client.Domain.Abstract
{
    public abstract class BinanceClientConstructor
    {
        /// <summary>
        /// Client to be used to call the API.
        /// </summary>
        public readonly IApiClient _apiClient;

        /// <summary>
        /// Defines the constructor of the Binance client.
        /// </summary>
        /// <param name="apiClient">API client to be used for API calls.</param>
        public BinanceClientConstructor(IApiClient apiClient) {
            _apiClient = apiClient;
        }
    }
}
