﻿namespace TdAmeritrade.Internal;

using Models.MarketHours;

public partial interface ITdAmeritradeApi
{
	/// <summary>
	/// This API allows the developer to get the market hours for a specified single market
	/// </summary>
	/// <param name="authorization">
	/// A current and valid <see cref="Models.Authentication.LoginResponse.AccessToken"/>; optional. If not provided, <paramref name="apikey"/> must be provided.
	/// </param>
	/// <param name="market">
	/// The market for which you're requesting market hours. Valid markets are EQUITY, OPTION, FUTURE, BOND, or FOREX.
	/// </param>
	/// <param name="apikey">
	/// Pass your OAuth User ID to make an unauthenticated request for delayed data.
	/// </param>
	/// <param name="date">
	/// The date for which market hours information is requested. Valid ISO-8601 formats are: <c>yyyy-MM-dd</c> and <c>yyyy-MM-dd'T'HH:mm:ssz</c>.
	/// </param>
	/// <returns>
	/// If successful, the return includes information about the hours of the market.
	/// </returns>
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/market-hours/apis/get/marketdata/%7Bmarket%7D/hours"/>
	/// </remarks>
	[Get("/v1/marketdata/{market}/hours")]
	Task<IReadOnlyDictionary<string, MarketHoursResponse>> GetMarketHours([Header("Authorization")] string? authorization, string? apikey, string market, string? date = default);

	/// <summary>
	/// This API allows the developer to get the market hours for a multiple markets
	/// </summary>
	/// <param name="authorization">
	/// A current and valid <see cref="Models.Authentication.LoginResponse.AccessToken"/>; optional. If not provided, <paramref name="apikey"/> must be provided.
	/// </param>
	/// <param name="markets">
	/// The markets for which you're requesting market hours, comma-separated. Valid markets are EQUITY, OPTION, FUTURE, BOND, or FOREX.
	/// </param>
	/// <param name="apikey">
	/// Pass your OAuth User ID to make an unauthenticated request for delayed data.
	/// </param>
	/// <param name="date">
	/// The date for which market hours information is requested. Valid ISO-8601 formats are: <c>yyyy-MM-dd</c> and <c>yyyy-MM-dd'T'HH:mm:ssz</c>.
	/// </param>
	/// <returns>
	/// If successful, the return includes information about the hours of the market.
	/// </returns>
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/market-hours/apis/get/marketdata/hours"/>
	/// </remarks>
	[Get("/v1/marketdata/hours")]
	Task<IReadOnlyDictionary<string, MarketHoursResponse>> GetMarketHours(
		[Header("Authorization")] string? authorization,
		string? apikey,
		[Query(CollectionFormat = CollectionFormat.Csv)] IReadOnlyList<string> markets,
		string? date = default);
}
