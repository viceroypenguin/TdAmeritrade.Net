namespace TdAmeritrade.Internal;

using Models.PriceHistory;

public partial interface ITdAmeritradeApi
{
	/// <summary>
	/// This API allows the developer to get the price history for a single symbol.
	/// </summary>
	/// <param name="authorization">
	/// A current and valid <see cref="Models.Authentication.LoginResponse.AccessToken"/>; optional. If not provided, <paramref name="apikey"/> must be provided.
	/// </param>
	/// <param name="apikey">
	/// Pass your OAuth User ID to make an unauthenticated request for delayed data.
	/// </param>
	/// <param name="symbol">The symbol for which to get history</param>
	/// <param name="request">Some optional parameters for the data request</param>
	/// <returns>
	/// If successful, the return includes a list of associated accounts and information about each. 
	/// </returns>
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/price-history/apis/get/marketdata/%7Bsymbol%7D/pricehistory"/>
	/// </remarks>
	[Get("/v1/marketdata/{symbol}/pricehistory")]
	Task<PriceHistoryResponse> GetPriceHistory([Header("Authorization")] string? authorization, string? apikey, string symbol, PriceHistoryRequest? request = default);
}
