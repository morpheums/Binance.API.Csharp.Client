using Binance.API.Csharp.Client.Domain.Interfaces;

namespace Binance.API.Csharp.Client.Domain.Abstract
{
    public abstract class BinanceClientAbstract
    {
        /// <summary>
        /// Client to be used to call the API.
        /// </summary>
        public readonly IApiClient _apiClient;

        /// <summary>
        /// Defines the constructor of the Binance client.
        /// </summary>
        /// <param name="apiClient">API client to be used for API calls.</param>
        public BinanceClientAbstract(IApiClient apiClient) {
            _apiClient = apiClient;
        }
    }
}
