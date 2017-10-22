# User Stream Methods
## Start user stream
Start a new user data stream.
### Example:
 
```c#
    var listenKey = binanceClient.StartUserStream().Result.ListenKey;
```
### Method Signature:

```c#
    public async Task<UserStreamInfo> StartUserStream()
```

## Keep alive user data stream
PING a user data stream to prevent a time out.
### Example:
 
```c#
    var ping = binanceClient.KeepAliveUserStream("@ListenKey").Result;
```
### Method Signature:

```c#
    public async Task<dynamic> KeepAliveUserStream(string listenKey)
```

## Close user data stream
Close out a user data stream.
### Example:
 
```c#
    var resut = binanceClient.CloseUserStream("@ListenKey").Result;
```
### Method Signature:

```c#
    public async Task<dynamic> CloseUserStream(string listenKey)
```
