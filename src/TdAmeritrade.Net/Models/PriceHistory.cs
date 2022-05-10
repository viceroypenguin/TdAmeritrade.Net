namespace TdAmeritrade.Models.PriceHistory;

public enum PeriodType
{
	Day,
	Month,
	Year,
	Ytd,
}

public enum FrequencyType
{
	Minute,
	Daily,
	Weekly,
	Monthly,
}

public class PriceHistoryRequest
{
	/// <summary>
	/// Pass your OAuth User ID to make an unauthenticated request for delayed data.
	/// </summary>
	[AliasAs("apikey")] public string? ApiKey { get; set; }

	/// <summary>
	/// <p> The type of period to show. </p>
	/// </summary>
	[AliasAs("periodType")] public PeriodType? PeriodType { get; set; }

	/// <summary>
	/// The number of periods to show.
	/// </summary>
	/// <value>
	/// Valid periods by <see cref="PriceHistory.PeriodType"/> (defaults marked with an asterisk):
	///	<list type="bullet">
	///	<item><see cref="PeriodType.Day"/>: 1, 2, 3, 4, 5, 10* </item> 
	///	<item><see cref="PeriodType.Month"/>: 1*, 2, 3, 6 </item> 
	///	<item><see cref="PeriodType.Year"/>: 1*, 2, 3, 5, 10, 15, 20 </item> 
	///	<item><see cref="PeriodType.Ytd"/>: 1* </item> 
	///	</list>
	/// </value>
	[AliasAs("period")] public int? Period { get; set; }

	/// <summary>
	/// The type of <see cref="Frequency"/> with which a new candle is formed.
	/// </summary>
	/// <value>
	/// Valid periods by <see cref="PriceHistory.PeriodType"/> (defaults marked with an asterisk):
	///	<list type="bullet">
	///	<item><see cref="PeriodType.Day"/>: <see cref="FrequencyType.Minute"/>* </item> 
	///	<item><see cref="PeriodType.Month"/>: <see cref="FrequencyType.Daily"/>, <see cref="FrequencyType.Weekly"/>* </item> 
	///	<item><see cref="PeriodType.Year"/>: <see cref="FrequencyType.Daily"/>, <see cref="FrequencyType.Weekly"/>, <see cref="FrequencyType.Monthly"/>* </item> 
	///	<item><see cref="PeriodType.Ytd"/>: <see cref="FrequencyType.Daily"/>, <see cref="FrequencyType.Weekly"/>* </item> 
	///	</list>
	/// </value>
	[AliasAs("frequencyType")] public FrequencyType? FrequencyType { get; set; }

	/// <summary>
	/// The number of the frequencyType to be included in each candle.
	/// </summary>
	/// <value>
	/// Valid periods by <see cref="PriceHistory.FrequencyType"/> (defaults marked with an asterisk):
	///	<list type="bullet">
	///	<item><see cref="FrequencyType.Minute"/>: 1*, 5, 10, 15, 30 </item>
	///	<item><see cref="FrequencyType.Daily"/>: 1* </item>
	///	<item><see cref="FrequencyType.Weekly"/>: 1* </item>
	///	<item><see cref="FrequencyType.Monthly"/>: 1* </item>
	///	</list>
	/// </value>
	[AliasAs("frequency")] public int? Frequency { get; set; }

	/// <summary>
	/// Start date as milliseconds since epoch. If both <see cref="StartDate"/> and <see cref="EndDate"/> are 
	/// provided, <see cref="Period"/> should not be provided.
	/// </summary>
	/// <value>
	/// This value can be easily obtained by using <see cref="DateTimeOffset.ToUnixTimeMilliseconds"/>.
	/// Example code:
	/// <code>
	/// StartDate = DateTimeOffset.Now.ToUnixTimeMilliseconds();
	/// </code>
	/// </value>
	[AliasAs("startDate")] public long? StartDate { get; set; }

	/// <summary>
	/// End date as milliseconds since epoch. If both <see cref="StartDate"/> and <see cref="EndDate"/> are 
	/// provided, <see cref="Period"/> should not be provided. Default is previous trading day.
	/// </summary>
	/// <value>
	/// This value can be easily obtained by using <see cref="DateTimeOffset.ToUnixTimeMilliseconds"/>.
	/// Example code:
	/// <code>
	/// EndDate = DateTimeOffset.Now.ToUnixTimeMilliseconds();
	/// </code>
	/// </value>
	[AliasAs("endDate")] public long? EndDate { get; set; }

	/// <summary>
	/// <c>true</c> to return extended hours data, <c>false</c> for regular market hours only. Default is <c>true</c>
	/// </summary>
	[AliasAs("needExtendedHoursData")] public bool? NeedExtendedHoursData { get; set; }
}

public class PriceHistoryResponse
{
	public string Symbol { get; set; } = string.Empty;
	public bool Empty { get; set; }

	public IReadOnlyList<Candle> Candles { get; set; } = Array.Empty<Candle>();
}

public class Candle
{
	[JsonConverter(typeof(DateTimeConverter))]
	public DateTimeOffset Datetime { get; set; }
	public decimal Close { get; set; }
	public decimal High { get; set; }
	public decimal Low { get; set; }
	public decimal Open { get; set; }
	public decimal Volume { get; set; }
}
