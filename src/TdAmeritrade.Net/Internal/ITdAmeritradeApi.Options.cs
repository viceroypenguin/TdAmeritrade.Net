namespace TdAmeritrade.Internal;

using Models.Options;

public partial interface ITdAmeritradeApi
{
	/// <summary>
	/// This API allows the developer to get the option chain for a given symbol
	/// </summary>
	/// <param name="authorization">
	/// A current and valid <see cref="Models.Authentication.LoginResponse.AccessToken"/>; optional. If not provided, <paramref name="apikey"/> must be provided.
	/// </param>
	/// <param name="apikey">
	/// Pass your OAuth User ID to make an unauthenticated request for delayed data.
	/// </param>
	/// <param name="symbol">
	/// The symbol for which to get option data
	/// </param>
	/// <param name="request">
	/// The optional parameters for the option chain API
	/// </param>
	/// <returns>
	/// If successful, the return includes information about the option chain.
	/// </returns>
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/option-chains/apis/get/marketdata/chains"/>
	/// </remarks>
	[Get("/v1/marketdata/chains")]
	Task<OptionChain?> GetOptionChain([Header("Authorization")] string? authorization, string? apikey, string symbol, OptionRequest? request);
}
