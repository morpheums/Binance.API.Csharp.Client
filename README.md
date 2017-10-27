# Binance API Csharp Client ![Icon](https://github.com/morpheums/Binance.API.Csharp.Client/blob/master/Binance.API.Csharp.Client/BinanceLogo.png?raw=true)
### C#.NET client for Binance Exchange API.
[![GitHub last commit](https://img.shields.io/github/last-commit/morpheums/Binance.API.Csharp.Client.svg?style=plastic)]()
[![NuGet](https://img.shields.io/nuget/v/Binance.API.Csharp.Client.svg?style=plastic)](https://www.nuget.org/packages/Binance.API.Csharp.Client)
[![NuGet](https://img.shields.io/nuget/dt/Binance.API.Csharp.Client.svg?style=plastic)](https://www.nuget.org/packages/Binance.API.Csharp.Client)

## Features
- **Very easy** to understand and get started.
- **Complete implementation** of the Binance API and WebSockets.
- Validates transactions using the **[Binance Trading Rules](https://support.binance.com/hc/en-us/articles/115000594711-Trading-Rule)**
- API results **deserialized** to concrete objects for ease of usage.
- Includes a **ready to go** test project with **all possible API calls**, just provide your API Key and Secret.

## Installation

**Nuget Package Manager**
```
PM> Install-Package Binance.API.Csharp.Client
```
**.NET CLI**
```
dotnet add package Binance.API.Csharp.Client
```
## Getting Started
In order to use signed methods you need to [create a Binance account](https://www.binance.com/register.html?ref=10200312), if you already have one, go to your account and create a new API private key.

Create an instance of the **APIClient** which receive the following parameters:

* **ApiKey** - *Key used to authenticate within the API.*
* **ApiSecret** - *API secret used for signed API calls.*
* **ApiUrl (Optional)** - *Base URL of the API.*
* **WebSocketEndpoint (Optional)** - *URL of the WebSockets.* 
```c#
    var apiClient = new ApiClient("@Your-API-Key", "@Your-API-Secret");
```

Create an instance of the **BinanceClient** which will receive the previously created APIClient
 
```c#
    var binanceClient = new BinanceClient(apiClient);
```

## Documentation and Examples
- [General Methods](/Documentation/GeneralMethods.md)
- [Market Methods](/Documentation/MarketMethods.md)
- [Account Methods](/Documentation/AccountMethods.md)
- [User Stream Methods](/Documentation/UserStreamMethods.md)
- [WebSocket Methods](/Documentation/WebSocketMethods.md)

## License
Binance.API.Csharp.Client is open-sourced software licensed under the [MIT license](http://opensource.org/licenses/MIT)

## Code of Conduct
Please read and follow our [Code of Conduct](CODE_OF_CONDUCT.md).
