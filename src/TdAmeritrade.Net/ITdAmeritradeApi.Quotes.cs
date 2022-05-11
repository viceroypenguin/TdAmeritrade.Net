namespace TdAmeritrade;

using Models.Quotes;

public partial interface ITdAmeritradeApi
{
	/// <summary>
	/// This API allows the developer to get the quote information for a single symbol
	/// </summary>
	/// <param name="token">
	/// A current and valid <see cref="Models.Authentication.LoginResponse.AccessToken"/>; optional. If not provided, <paramref name="apikey"/> must be provided.
	/// </param>
	/// <param name="symbol">
	/// The requested symbol
	/// </param>
	/// <param name="apikey">
	/// Pass your OAuth User ID to make an unauthenticated request for delayed data.
	/// </param>
	/// <returns>
	/// If successful, the return includes quote information for the requested symbol.
	/// Upon failure, the return will include information about the failure.
	/// </returns>
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/quotes/apis/get/marketdata/%7Bsymbol%7D/quotes"/>
	/// </remarks>
	[Get("/v1/marketdata/{symbol}/quotes")]
	Task<ApiResponse<IReadOnlyDictionary<string, Quote>>> GetQuote([Authorize("Bearer")] string? token, string symbol, string? apikey = default);

	/// <summary>
	/// This API allows the developer to get the quote information for multiple symbols
	/// </summary>
	/// <param name="token">
	/// A current and valid <see cref="Models.Authentication.LoginResponse.AccessToken"/>; optional. If not provided, <paramref name="apikey"/> must be provided.
	/// </param>
	/// <param name="symbol">
	/// The requested symbols
	/// </param>
	/// <param name="apikey">
	/// Pass your OAuth User ID to make an unauthenticated request for delayed data.
	/// </param>
	/// <returns>
	/// If successful, the return includes quote information for the requested symbols.
	/// Upon failure, the return will include information about the failure.
	/// </returns>
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/quotes/apis/get/marketdata/quotes"/>
	/// </remarks>
	[Get("/v1/marketdata/quotes")]
	Task<ApiResponse<IReadOnlyDictionary<string, Quote>>> GetQuotes([Authorize("Bearer")] string? token, [Query(CollectionFormat = CollectionFormat.Csv)] IReadOnlyList<string> symbol, string? apikey = default);
}
