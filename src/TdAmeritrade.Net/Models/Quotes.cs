using System.Text.Json;

namespace TdAmeritrade.Models.Quotes;

[JsonConverter(typeof(QuoteConverter))]
public class Quote
{
	public string AssetType { get; set; } = string.Empty;
	public string AssetMainType { get; set; } = string.Empty;
	public string Symbol { get; set; } = string.Empty;
	public string Cusip { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
}

public class QuoteConverter : JsonConverter<Quote>
{
	public override Quote? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var obj = JsonSerializer.Deserialize<JsonElement>(ref reader, options);

		return obj.GetProperty("assetType").GetString() switch
		{
			"EQUITY" => obj.Deserialize<EquityQuote>(options),
			"ETF" => obj.Deserialize<EtfQuote>(options),
			"MUTUAL_FUND" => obj.Deserialize<MutualFundQuote>(options),
			_ => throw new JsonException($"Unable to parse Quote node. Asset Type = {obj.GetProperty("assetType").GetString()}."),
		};
	}

	public override void Write(Utf8JsonWriter writer, Quote value, JsonSerializerOptions options) => throw new NotImplementedException();
}

public class MutualFundQuote : Quote
{
	public decimal ClosePrice { get; set; }
	public decimal NetChange { get; set; }
	public decimal TotalVolume { get; set; }

	[JsonPropertyName("tradeTimeInLong")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTimeOffset TradeTime { get; set; }

	public string? Exchange { get; set; }
	public string? ExchangeName { get; set; }
	public decimal Digits { get; set; }
	[JsonPropertyName("52WkHigh")] public decimal FiftyTwoWeekHigh { get; set; }
	[JsonPropertyName("52WkLow")] public decimal FiftyTwoWeekLow { get; set; }
	public decimal NAV { get; set; }
	public decimal PeRatio { get; set; }
	public decimal DivAmount { get; set; }
	public decimal DivYield { get; set; }
	public string? DivDate { get; set; }
	public string? SecurityStatus { get; set; }
}


public class FutureQuote : Quote
{
	public decimal BidPriceInDouble { get; set; }
	public decimal AskPriceInDouble { get; set; }
	public decimal LastPriceInDouble { get; set; }
	public string? BidId { get; set; }
	public string? AskId { get; set; }
	public decimal HighPriceInDouble { get; set; }
	public decimal LowPriceInDouble { get; set; }
	public decimal ClosePriceInDouble { get; set; }
	public string? Exchange { get; set; }
	public string? LastId { get; set; }
	public decimal OpenPriceInDouble { get; set; }
	public decimal ChangeInDouble { get; set; }
	public decimal FuturePercentChange { get; set; }
	public string? ExchangeName { get; set; }
	public string? SecurityStatus { get; set; }
	public decimal OpenInterest { get; set; }
	public decimal Mark { get; set; }
	public decimal Tick { get; set; }
	public decimal TickAmount { get; set; }
	public string? Product { get; set; }
	public string? FuturePriceFormat { get; set; }
	public string? FutureTradingHours { get; set; }
	public bool FutureIsTradable { get; set; }
	public decimal FutureMultiplier { get; set; }
	public bool FutureIsActive { get; set; }
	public decimal FutureSettlementPrice { get; set; }
	public string? FutureActiveSymbol { get; set; }
	[JsonConverter(typeof(DateOnlyConverter))] public DateOnly FutureExpirationDate { get; set; }
}


public class FutureOptionQuote : Quote
{
	public decimal BidPriceInDouble { get; set; }
	public decimal AskPriceInDouble { get; set; }
	public decimal LastPriceInDouble { get; set; }
	public decimal HighPriceInDouble { get; set; }
	public decimal LowPriceInDouble { get; set; }
	public decimal ClosePriceInDouble { get; set; }
	public decimal OpenPriceInDouble { get; set; }
	public decimal NetChangeInDouble { get; set; }
	public decimal OpenInterest { get; set; }
	public string? ExchangeName { get; set; }
	public string? SecurityStatus { get; set; }
	public decimal Volatility { get; set; }
	public decimal MoneyIntrinsicValueInDouble { get; set; }
	public decimal MultiplierInDouble { get; set; }
	public decimal Digits { get; set; }
	public decimal StrikePriceInDouble { get; set; }
	public string? ContractType { get; set; }
	public string? Underlying { get; set; }
	public decimal TimeValueInDouble { get; set; }
	public decimal DeltaInDouble { get; set; }
	public decimal GammaInDouble { get; set; }
	public decimal ThetaInDouble { get; set; }
	public decimal VegaInDouble { get; set; }
	public decimal RhoInDouble { get; set; }
	public decimal Mark { get; set; }
	public decimal Tick { get; set; }
	public decimal TickAmount { get; set; }
	public bool FutureIsTradable { get; set; }
	public string? FutureTradingHours { get; set; }
	public decimal FuturePercentChange { get; set; }
	public bool FutureIsActive { get; set; }
	[JsonConverter(typeof(DateOnlyConverter))] public DateOnly FutureExpirationDate { get; set; }
	public string? ExpirationType { get; set; }
	public string? ExerciseType { get; set; }
	public bool InTheMoney { get; set; }
}

public class IndexQuote : Quote
{
	public decimal LastPrice { get; set; }
	public decimal OpenPrice { get; set; }
	public decimal HighPrice { get; set; }
	public decimal LowPrice { get; set; }
	public decimal ClosePrice { get; set; }
	public decimal NetChange { get; set; }
	public decimal TotalVolume { get; set; }

	[JsonPropertyName("tradeTimeInLong")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTimeOffset TradeTime { get; set; }

	public string? Exchange { get; set; }
	public string? ExchangeName { get; set; }
	public decimal Digits { get; set; }
	[JsonPropertyName("52WkHigh")] public decimal FiftyTwoWeekHigh { get; set; }
	[JsonPropertyName("52WkLow")] public decimal FiftyTwoWeekLow { get; set; }
	public string? SecurityStatus { get; set; }
}


public class OptionQuote : Quote
{
	public decimal BidPrice { get; set; }
	public decimal BidSize { get; set; }
	public decimal AskPrice { get; set; }
	public decimal AskSize { get; set; }
	public decimal LastPrice { get; set; }
	public decimal LastSize { get; set; }
	public decimal OpenPrice { get; set; }
	public decimal HighPrice { get; set; }
	public decimal LowPrice { get; set; }
	public decimal ClosePrice { get; set; }
	public decimal NetChange { get; set; }
	public decimal TotalVolume { get; set; }

	[JsonPropertyName("quoteTimeInLong")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTimeOffset QuoteTime { get; set; }

	[JsonPropertyName("tradeTimeInLong")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTimeOffset TradeTime { get; set; }

	public decimal Mark { get; set; }
	public decimal OpenInterest { get; set; }
	public decimal Volatility { get; set; }
	public decimal MoneyIntrinsicValue { get; set; }
	public decimal Multiplier { get; set; }
	public decimal StrikePrice { get; set; }
	public string? ContractType { get; set; }
	public string? Underlying { get; set; }
	public decimal TimeValue { get; set; }
	public string? Deliverables { get; set; }
	public decimal Delta { get; set; }
	public decimal Gamma { get; set; }
	public decimal Theta { get; set; }
	public decimal Vega { get; set; }
	public decimal Rho { get; set; }
	public string? SecurityStatus { get; set; }
	public decimal TheoreticalOptionValue { get; set; }
	public decimal UnderlyingPrice { get; set; }
	public string? UvExpirationType { get; set; }
	public string? Exchange { get; set; }
	public string? ExchangeName { get; set; }
	public string? SettlementType { get; set; }
}

public class ForexQuote : Quote
{
	public decimal BidPriceInDouble { get; set; }
	public decimal AskPriceInDouble { get; set; }
	public decimal LastPriceInDouble { get; set; }
	public decimal HighPriceInDouble { get; set; }
	public decimal LowPriceInDouble { get; set; }
	public decimal ClosePriceInDouble { get; set; }
	public string? Exchange { get; set; }
	public decimal OpenPriceInDouble { get; set; }
	public decimal ChangeInDouble { get; set; }
	public decimal PercentChange { get; set; }
	public string? ExchangeName { get; set; }
	public decimal Digits { get; set; }
	public string? SecurityStatus { get; set; }
	public decimal Tick { get; set; }
	public decimal TickAmount { get; set; }
	public string? Product { get; set; }
	public string? TradingHours { get; set; }
	public bool IsTradable { get; set; }
	public string? MarketMaker { get; set; }
	[JsonPropertyName("52WkHigh")] public decimal FiftyTwoWeekHigh { get; set; }
	[JsonPropertyName("52WkLow")] public decimal FiftyTwoWeekLow { get; set; }
	public decimal Mark { get; set; }
}


public class EtfQuote : Quote
{
	public decimal BidPrice { get; set; }
	public decimal BidSize { get; set; }
	public string? BidId { get; set; }
	public decimal AskPrice { get; set; }
	public decimal AskSize { get; set; }
	public string? AskId { get; set; }
	public decimal LastPrice { get; set; }
	public decimal LastSize { get; set; }
	public string? LastId { get; set; }
	public decimal OpenPrice { get; set; }
	public decimal HighPrice { get; set; }
	public decimal LowPrice { get; set; }
	public decimal ClosePrice { get; set; }
	public decimal NetChange { get; set; }
	public decimal TotalVolume { get; set; }

	[JsonPropertyName("quoteTimeInLong")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTimeOffset QuoteTime { get; set; }

	[JsonPropertyName("tradeTimeInLong")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTimeOffset TradeTime { get; set; }

	public decimal Mark { get; set; }
	public string? Exchange { get; set; }
	public string? ExchangeName { get; set; }
	public bool Marginable { get; set; }
	public bool Shortable { get; set; }
	public decimal Volatility { get; set; }
	public decimal Digits { get; set; }
	[JsonPropertyName("52WkHigh")] public decimal FiftyTwoWeekHigh { get; set; }
	[JsonPropertyName("52WkLow")] public decimal FiftyTwoWeekLow { get; set; }
	public decimal PeRatio { get; set; }
	public decimal DivAmount { get; set; }
	public decimal DivYield { get; set; }
	[JsonConverter(typeof(DateOnlyConverter))] public DateOnly DivDate { get; set; }
	public string? SecurityStatus { get; set; }
	public decimal RegularMarketLastPrice { get; set; }
	public decimal RegularMarketLastSize { get; set; }
	public decimal RegularMarketNetChange { get; set; }

	[JsonPropertyName("regularMarketTradeTimeInLong")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTimeOffset RegularMarketTradeTime { get; set; }
}


public class EquityQuote : Quote
{
	public decimal BidPrice { get; set; }
	public decimal BidSize { get; set; }
	public string? BidId { get; set; }
	public decimal AskPrice { get; set; }
	public decimal AskSize { get; set; }
	public string? AskId { get; set; }
	public decimal LastPrice { get; set; }
	public decimal LastSize { get; set; }
	public string? LastId { get; set; }
	public decimal OpenPrice { get; set; }
	public decimal HighPrice { get; set; }
	public decimal LowPrice { get; set; }
	public decimal ClosePrice { get; set; }
	public decimal NetChange { get; set; }
	public decimal TotalVolume { get; set; }
	
	[JsonPropertyName("quoteTimeInLong")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTimeOffset QuoteTime { get; set; }

	[JsonPropertyName("tradeTimeInLong")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTimeOffset TradeTime { get; set; }

	public decimal Mark { get; set; }
	public string? Exchange { get; set; }
	public string? ExchangeName { get; set; }
	public bool Marginable { get; set; }
	public bool Shortable { get; set; }
	public decimal Volatility { get; set; }
	public decimal Digits { get; set; }
	[JsonPropertyName("52WkHigh")] public decimal FiftyTwoWeekHigh { get; set; }
	[JsonPropertyName("52WkLow")] public decimal FiftyTwoWeekLow { get; set; }
	public decimal PeRatio { get; set; }
	public decimal DivAmount { get; set; }
	public decimal DivYield { get; set; }
	[JsonConverter(typeof(DateOnlyConverter))] public DateOnly DivDate { get; set; }
	public string? SecurityStatus { get; set; }
	public decimal RegularMarketLastPrice { get; set; }
	public decimal RegularMarketLastSize { get; set; }
	public decimal RegularMarketNetChange { get; set; }
	
	[JsonPropertyName("regularMarketTradeTimeInLong")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTimeOffset RegularMarketTradeTime { get; set; }
}
