# General Methods
## Test connectivity
Test connectivity to the Rest API.
### Example:
 
```c#
    var test = binanceClient.TestConnectivity().Result;
```
### Method Signature:

```c#
    public async Task<dynamic> TestConnectivity()
```

## Check server time
Test connectivity to the Rest API and get the current server time.
### Example:
 
```c#
    var serverTime = binanceClient.GetServerTime().Result;
```
### Method Signature:

```c#
    public async Task<ServerInfo> GetServerTime()
```