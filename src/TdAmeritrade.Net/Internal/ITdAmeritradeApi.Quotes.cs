namespace TdAmeritrade.Internal;

using Models.Quotes;

public partial interface ITdAmeritradeApi
{
	/// <summary>
	/// This API allows the developer to get the quote information for a single symbol
	/// </summary>
	/// <param name="authorization">
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
	/// </returns>
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/quotes/apis/get/marketdata/%7Bsymbol%7D/quotes"/>
	/// </remarks>
	[Get("/v1/marketdata/{symbol}/quotes")]
	Task<IReadOnlyDictionary<string, Quote>> GetQuote([Header("Authorization")] string? authorization, string? apikey, string symbol);

	/// <summary>
	/// This API allows the developer to get the quote information for multiple symbols
	/// </summary>
	/// <param name="authorization">
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
	/// </returns>
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/quotes/apis/get/marketdata/quotes"/>
	/// </remarks>
	[Get("/v1/marketdata/quotes")]
	Task<IReadOnlyDictionary<string, Quote>> GetQuotes([Header("Authorization")] string? authorization, string? apikey, [Query(CollectionFormat = CollectionFormat.Csv)] IReadOnlyList<string> symbol);
}
