namespace TdAmeritrade.Models.Instruments;


public class Instrument
{
	public string Cusip { get; set; } = string.Empty;
	public string Symbol { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string Exchange { get; set; } = string.Empty;
	public string AssetType { get; set; } = string.Empty;
	public decimal? BondPrice { get; set; }
	public FundamentalData? Fundamental { get; set; }
}

public class FundamentalData
{
	public string Symbol { get; set; } = string.Empty;
	public decimal High52 { get; set; }
	public decimal Low52 { get; set; }
	public decimal DividendAmount { get; set; }
	public decimal DividendYield { get; set; }
	[JsonConverter(typeof(DateOnlyConverter))] public DateOnly DividendDate { get; set; }
	public decimal PeRatio { get; set; }
	public decimal PegRatio { get; set; }
	public decimal PbRatio { get; set; }
	public decimal PrRatio { get; set; }
	public decimal PcfRatio { get; set; }
	public decimal GrossMarginTTM { get; set; }
	public decimal GrossMarginMRQ { get; set; }
	public decimal NetProfitMarginTTM { get; set; }
	public decimal NetProfitMarginMRQ { get; set; }
	public decimal OperatingMarginTTM { get; set; }
	public decimal OperatingMarginMRQ { get; set; }
	public decimal ReturnOnEquity { get; set; }
	public decimal ReturnOnAssets { get; set; }
	public decimal ReturnOnInvestment { get; set; }
	public decimal QuickRatio { get; set; }
	public decimal CurrentRatio { get; set; }
	public decimal InterestCoverage { get; set; }
	public decimal TotalDebtToCapital { get; set; }
	public decimal LtDebtToEquity { get; set; }
	public decimal TotalDebtToEquity { get; set; }
	public decimal EpsTTM { get; set; }
	public decimal EpsChangePercentTTM { get; set; }
	public decimal EpsChangeYear { get; set; }
	public decimal EpsChange { get; set; }
	public decimal RevChangeYear { get; set; }
	public decimal RevChangeTTM { get; set; }
	public decimal RevChangeIn { get; set; }
	public decimal SharesOutstanding { get; set; }
	public decimal MarketCapdecimal { get; set; }
	public decimal MarketCap { get; set; }
	public decimal BookValuePerShare { get; set; }
	public decimal ShortIntTodecimal { get; set; }
	public decimal ShortIntDayToCover { get; set; }
	public decimal DivGrowthRate3Year { get; set; }
	public decimal DividendPayAmount { get; set; }
	[JsonConverter(typeof(DateOnlyConverter))] public DateOnly DividendPayDate { get; set; }
	public decimal Beta { get; set; }
	public decimal Vol1DayAvg { get; set; }
	public decimal Vol10DayAvg { get; set; }
	public decimal Vol3MonthAvg { get; set; }
}
