# TdAmeritrade.Net

### NB: Archiving due to TdAmeritrade accounts moving to Schwab

![Build status](https://github.com/viceroypenguin/TdAmeritrade.Net/actions/workflows/build.yml/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/TdAmeritrade.Net.svg?style=plastic)](https://www.nuget.org/packages/TdAmeritrade.Net/)
---

## What is TdAmeritrade.Net?
TdAmeritrade.Net is an unofficial library for interacting with 
[Td Ameritrade's](https://developer.tdameritrade.com/) APIs. 
It is supported for .net core 3.1, and .net 5.0+.

### Where can I get it?
TdAmeritrade.Net is available at [nuget.org](https://www.nuget.org/packages/TdAmeritrade.Net).

Package Manager `PM > Install-Package TdAmeritrade.Net`

### How it works?
You can make all calls to Td Ameritrade's API via the `TdAmeritrade.TdAmeritradeApi` class.

```c#
var client = new TdAmeritradeApi(
	clientId: "<client id>");

// Retrieving a user's recent transactions.
var result = await client.GetTransactions(
	refreshToken: "<refreshToken>",
	accountId: "<account_id>");
```

#### Usage
The `TdAmeritradeApi` class is expected in general to be a short-lived 
object provided by the DI system on a unit-of-work basis. The access token 
generated from a refresh token is cached externally using an `IMemoryCache` 
provided by the DI system. 

If the object is used in a short-lived console application, then a single
instance can be held for the lifetime of the application. For all other uses,
it is expected to use the DI system.

### .NET Core Configuration Options

#### Easy to use:
There are three ways to add `TdAmeritradeApi` to the DI system:
* `services.AddTdAmeritradeApi()`: In this version, `Func<string, TdAmeritradeApi>`
and `Func<string, string, TdAmeritradeApi>` are added to the DI system. In this
version, either the client ID or both the client ID and the refresh token can be
provided to generate a `TdAmeritradeApi` instance for the given values. 
* `services.AddTdAmeritradeApi(string clientId)`: In this version, `TdAmeritradeApi`
and `Func<string, TdAmeritradeApi>` are added to the DI system. In this version,
the client ID is fixed for all instance, and the refresh token may be added
additionally for each `TdAmeritradeApi` instance.
* `services.AddTdAmeritradeApi(string clientId, string refreshToken)`: In this 
version, only `TdAmeritradeApi` is added to the DI system. All instances will be
fixed to the provided client ID and refresh token.

#### IHttpClientFactory

Going.Plaid supports the `IHttpClientFactory` for correct usage of `HttpClient`, as described [here](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests).
If you choose not to call `.AddTdAmeritradeApi()`, because you need to customize your DI structure, it is recommended that you call
`services.AddITdAmeritradeApiRefitClient()` to properly configure the `ITdAmeritradeApi` refit client for TdAmeritrade.Net usage.
