// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "This name is in reference to Stock Options", Scope = "type", Target = "~T:TdAmeritrade.Models.Accounts.Option")]
[assembly: SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "TD Ameritrade API uses the name date for the parameter", Scope = "member", Target = "~M:TdAmeritrade.ITdAmeritradeApi.GetMarketHours(System.String,System.String,System.String,System.String)~System.Threading.Tasks.Task{Refit.ApiResponse{System.Collections.Generic.IReadOnlyDictionary{System.String,TdAmeritrade.Models.MarketData.MarketDataResponse}}}")]
[assembly: SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "TD Ameritrade API uses the name date for the parameter", Scope = "member", Target = "~M:TdAmeritrade.ITdAmeritradeApi.GetMarketHours(System.String,System.Collections.Generic.IReadOnlyList{System.String},System.String,System.String)~System.Threading.Tasks.Task{Refit.ApiResponse{System.Collections.Generic.IReadOnlyDictionary{System.String,TdAmeritrade.Models.MarketData.MarketDataResponse}}}")]
