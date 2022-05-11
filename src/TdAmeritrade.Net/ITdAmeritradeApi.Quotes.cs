namespace TdAmeritrade;

using Models.Quotes;

public partial interface ITdAmeritradeApi
{
	[Get("/v1/marketdata/{symbol}/quotes")]
	Task<ApiResponse<IReadOnlyDictionary<string, Quote>>> GetQuote([Authorize("Bearer")] string? token, string symbol, string? apikey = default);

	[Get("/v1/marketdata/quotes")]
	Task<ApiResponse<IReadOnlyDictionary<string, Quote>>> GetQuotes([Authorize("Bearer")] string? token, [Query(CollectionFormat = CollectionFormat.Csv)] IReadOnlyList<string> symbol, string? apikey = default);
}
