namespace TdAmeritrade.Internal;

using Models.Instruments;

public partial interface ITdAmeritradeApi
{
	/// <summary>
	/// This API allows the developer to search for instrument data, including fundamental data
	/// </summary>
	/// <param name="authorization">
	/// A current and valid <see cref="Models.Authentication.LoginResponse.AccessToken"/>; optional. If not provided, <paramref name="apikey"/> must be provided.
	/// </param>
	/// <param name="apikey">
	/// Pass your OAuth User ID to make an unauthenticated request for delayed data.
	/// </param>
	/// <param name="projection">
	/// The type of request (must be one of the following):
	/// <list type="table">
	/// <item><term>symbol-search</term><description>Retrieve instrument data of a specific symbol or cusip</description></item>
	/// <item><term>symbol-regex</term><description>Retrieve instrument data for all symbols matching regex.Example: symbol= XYZ.* will return all symbols beginning with XYZ</description></item>
	/// <item><term>desc-search</term><description>Retrieve instrument data for instruments whose description contains the word supplied.Example: symbol= FakeCompany will return all instruments with FakeCompany in the description.</description></item>
	/// <item><term>desc-regex</term><description>Search description with full regex support. Example: symbol= XYZ.[A - C] returns all instruments whose descriptions contain a word beginning with XYZ followed by a character A through C.</description></item>
	/// <item><term>fundamental</term><description>Returns fundamental data for a single instrument specified by exact symbol.</description></item>
	/// </list>
	/// </param>
	/// <param name="symbol">
	/// Value to pass to the search. See <paramref name="projection"/> for more information.
	/// </param>
	/// <returns>
	/// If successful, the return includes the search results.
	/// </returns>
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/instruments/apis/get/instruments"/>
	/// </remarks>
	[Get("/v1/instruments")]
	Task<IReadOnlyDictionary<string, Instrument>> GetInstruments([Header("Authorization")] string? authorization, string? apikey, string projection, string symbol);

	/// <summary>
	/// This API allows the developer to get information about a single CUSIP
	/// </summary>
	/// <param name="authorization">
	/// A current and valid <see cref="Models.Authentication.LoginResponse.AccessToken"/>; optional. If not provided, <paramref name="apikey"/> must be provided.
	/// </param>
	/// <param name="apikey">
	/// Pass your OAuth User ID to make an unauthenticated request for delayed data.
	/// </param>
	/// <param name="cusip">
	/// The cusip for which to get information.
	/// </param>
	/// <returns>
	/// If successful, the return includes the search results.
	/// </returns>
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/instruments/apis/get/instruments/%7Bcusip%7D"/>
	/// </remarks>
	[Get("/v1/instruments/{cusip}")]
	Task<IReadOnlyList<Instrument>> GetInstrument([Header("Authorization")] string? authorization, string? apikey, string cusip);
}
