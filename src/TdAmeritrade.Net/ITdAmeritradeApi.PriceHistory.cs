namespace TdAmeritrade;

using Models.PriceHistory;

public partial interface ITdAmeritradeApi
{
	/// <summary>
	/// This API allows the developer to get the price history for a single symbol.
	/// </summary>
	/// <param name="token">
	/// A current and valid <see cref="Models.Authentication.LoginResponse.AccessToken"/>; optional. If not provided, <see cref="PriceHistoryRequest.ApiKey" /> must be provided.
	/// </param>
	/// <param name="symbol">The symbol for which to get history</param>
	/// <param name="request">Some optional parameters for the data request</param>
	/// <returns>
	/// If successful, the return includes a list of associated accounts and information about each. 
	/// Upon failure, the return will include information about the failure.
	/// </returns>
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/price-history/apis/get/marketdata/%7Bsymbol%7D/pricehistory"/>
	/// </remarks>
	[Get("/v1/marketdata/{symbol}/pricehistory")]
	Task<ApiResponse<PriceHistoryResponse>> GetPriceHistory([Authorize("Bearer")] string? token, string symbol, PriceHistoryRequest? request = default);
}
