using System.Text.Json;

namespace TdAmeritrade.Models.Options;

public enum ContractType
{
	[EnumMember(Value = "CALL")] Call,
	[EnumMember(Value = "PUT")] Put,
	[EnumMember(Value = "ALL")] All,
}

public enum IncludeQuotes
{
	[EnumMember(Value = "TRUE")] True,
	[EnumMember(Value = "FALSE")] False,
}

public enum OptionsStrategy
{
	[EnumMember(Value = "SINGLE")] Single,
	[EnumMember(Value = "ANALYTICAL")] Analytical,
	[EnumMember(Value = "COVERED")] Covered,
	[EnumMember(Value = "VERTICAL")] Vertical,
	[EnumMember(Value = "CALENDAR")] Calendar,
	[EnumMember(Value = "STRANGLE")] Strangle,
	[EnumMember(Value = "STRADDLE")] Straddle,
	[EnumMember(Value = "BUTTERFLY")] Butterfly,
	[EnumMember(Value = "CONDOR")] Condor,
	[EnumMember(Value = "DIAGONAL")] Diagonal,
	[EnumMember(Value = "COLLAR")] Collar,
	[EnumMember(Value = "ROLL")] Roll,
}

public enum OptionsRange
{
	[EnumMember(Value = "ITM")] InTheMoney,
	[EnumMember(Value = "NTM")] NearTheMoney,
	[EnumMember(Value = "OTM")] OutOfTheMoney,
	[EnumMember(Value = "SAK")] StrikesAboveMarket,
	[EnumMember(Value = "SBK")] StrikesBelowMarket,
	[EnumMember(Value = "SNK")] StrikesNearMarket,
	[EnumMember(Value = "ALL")] AllStrikes,
}

public enum OptionType
{
	[EnumMember(Value = "S")] Standard,
	[EnumMember(Value = "NS")] NonStandard,
	[EnumMember(Value = "ALL")] All,
}

public class OptionRequest
{
	/// <summary>
	/// Type of contracts to return in the chain. Default is <see cref="ContractType.All"/>.
	/// </summary>
	[AliasAs("contractType")]
	public ContractType? ContractType { get; set; }

	/// <summary>
	/// The number of strikes to return above and below the at-the-money price.
	/// </summary>
	[AliasAs("strikeCount")]
	public int? StrikeCount { get; set; }

	/// <summary>
	/// Include quotes for options in the option chain. Default is <see cref="IncludeQuotes.False"/>
	/// </summary>
	[AliasAs("includeQuotes")]
	public IncludeQuotes? IncludeQuotes { get; set; }

	/// <summary>
	/// Passing a value returns a Strategy Chain. Default is <see cref="OptionsStrategy.Single"/>.
	/// </summary>
	/// <remarks>
	/// When the value is set to <see cref="OptionsStrategy.Analytical"/>, 
	/// the following properties can be used to calculate theoretical values: <see cref="Volatility"/>, <see cref="UnderlyingPrice"/>, 
	/// <see cref="InterestRate"/>, and <see cref="DaysToExpiration"/>.
	/// </remarks>
	[AliasAs("strategy")]
	public OptionsStrategy? Strategy { get; set; }

	/// <summary>
	/// Strike interval for spread strategy chains
	/// </summary>
	[AliasAs("interval")]
	public decimal? Interval { get; set; }

	/// <summary>
	/// Provide a strike price to return options only at that strike price.
	/// </summary>
	[AliasAs("strike")]
	public decimal? StrikePrice { get; set; }

	/// <summary>
	/// Returns options for the given range. Default is <see cref="OptionsRange.AllStrikes"/>
	/// </summary>
	[AliasAs("range")]
	public OptionsRange? Range { get; set; }

	/// <summary>
	/// Only return expirations after this date. For strategies, expiration refers to the nearest term expiration in the strategy.
	/// </summary>
	[AliasAs("fromDate")]
	public DateOnly? FromDate { get; set; }

	/// <summary>
	/// Only return expirations before this date. For strategies, expiration refers to the nearest term expiration in the strategy.
	/// </summary>
	[AliasAs("toDate")]
	public DateOnly? ToDate { get; set; }

	/// <summary>
	/// Volatility to use in calculations
	/// </summary>
	[AliasAs("volatility")]
	public decimal? Volatility { get; set; }

	/// <summary>
	/// Underlying price to use in calculations
	/// </summary>
	[AliasAs("underlyingPrice")]
	public decimal? UnderlyingPrice { get; set; }

	/// <summary>
	/// Interest rate to use in calculations
	/// </summary>
	[AliasAs("interestRate")]
	public decimal? InterestRate { get; set; }

	/// <summary>
	/// Days to expiration to use in calculations
	/// </summary>
	[AliasAs("daysToExpiration")]
	public int? DaysToExpiration { get; set; }

	/// <summary>
	/// Return only options expiring in the specified month. Month is given in the three character format.
	/// Example: <c>JAN</c>.
	/// Default is <c>ALL</c>.
	/// </summary>
	[AliasAs("expMonth")]
	public string? ExpMonth { get; set; }

	/// <summary>
	/// Type of contracts to return. Default is <see cref="OptionType.All"/>
	/// </summary>
	[AliasAs("optionType")]
	public OptionType? OptionType { get; set; }
}

public class OptionChain
{
	public string Symbol { get; set; } = string.Empty;
	public string Status { get; set; } = string.Empty;
	public Underlying? Underlying { get; set; }
	public string Strategy { get; set; } = string.Empty;
	public int NumberOfContracts { get; set; }
	public bool IsDelayed { get; set; }
	public bool IsIndex { get; set; }
	public decimal Interval { get; set; }
	public decimal DaysToExpiration { get; set; }
	public decimal InterestRate { get; set; }
	public decimal UnderlyingPrice { get; set; }
	public decimal Volatility { get; set; }

	[JsonPropertyName("callExpDateMap")]
	[JsonConverter(typeof(OptionsInstrumentConverter))]
	public IReadOnlyDictionary<DateOnly, IReadOnlyDictionary<decimal, OptionInstrument>>? Calls { get; set; }

	[JsonPropertyName("putExpDateMap")]
	[JsonConverter(typeof(OptionsInstrumentConverter))]
	public IReadOnlyDictionary<DateOnly, IReadOnlyDictionary<decimal, OptionInstrument>>? Puts { get; set; }
}

public class OptionsInstrumentConverter : JsonConverter<IReadOnlyDictionary<DateOnly, IReadOnlyDictionary<decimal, OptionInstrument>>>
{
	public override IReadOnlyDictionary<DateOnly, IReadOnlyDictionary<decimal, OptionInstrument>>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
		var dictionary = new Dictionary<DateOnly, IReadOnlyDictionary<decimal, OptionInstrument>>();
		foreach (var dateProperty in element.EnumerateObject())
		{
			var date = DateOnly.Parse(dateProperty.Name.Split(":")[0], System.Globalization.CultureInfo.InvariantCulture);

			var dateD = new Dictionary<decimal, OptionInstrument>();
			foreach (var priceProperty in dateProperty.Value.EnumerateObject())
			{
				var price = decimal.Parse(priceProperty.Name, System.Globalization.CultureInfo.InvariantCulture);

				var oiJ = priceProperty.Value;
				if (oiJ.ValueKind == JsonValueKind.Array)
					oiJ = oiJ[0];
				var oi = oiJ.Deserialize<OptionInstrument>(options);
				dateD[price] = oi!;
			}

			dictionary[date] = dateD;
		}

		return dictionary;
	}

	public override void Write(Utf8JsonWriter writer, IReadOnlyDictionary<DateOnly, IReadOnlyDictionary<decimal, OptionInstrument>> value, JsonSerializerOptions options) =>
		JsonSerializer.Serialize(writer, value, value.GetType());
}

public class Underlying
{
	public string Symbol { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string ExchangeName { get; set; } = string.Empty;
	public bool Delayed { get; set; }
	public decimal Ask { get; set; }
	public decimal AskSize { get; set; }
	public decimal Bid { get; set; }
	public decimal BidSize { get; set; }
	public decimal Change { get; set; }
	public decimal Close { get; set; }
	public decimal FiftyTwoWeekHigh { get; set; }
	public decimal FiftyTwoWeekLow { get; set; }
	public decimal HighPrice { get; set; }
	public decimal Last { get; set; }
	public decimal LowPrice { get; set; }
	public decimal Mark { get; set; }
	public decimal MarkChange { get; set; }
	public decimal MarkPercentChange { get; set; }
	public decimal OpenPrice { get; set; }
	public decimal PercentChange { get; set; }
	public decimal QuoteTime { get; set; }
	public decimal TotalVolume { get; set; }
	public decimal TradeTime { get; set; }
}

public class OptionInstrument
{
	public string PutCall { get; set; } = string.Empty;
	public string Symbol { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string ExchangeName { get; set; } = string.Empty;
	public decimal Bid { get; set; }
	public decimal Ask { get; set; }
	public decimal Last { get; set; }
	public decimal Mark { get; set; }
	public int BidSize { get; set; }
	public int AskSize { get; set; }
	public string BidAskSize { get; set; } = string.Empty;
	public int LastSize { get; set; }
	public decimal HighPrice { get; set; }
	public decimal LowPrice { get; set; }
	public decimal OpenPrice { get; set; }
	public decimal ClosePrice { get; set; }
	public int TotalVolume { get; set; }

	[JsonPropertyName("quoteTimeInLong")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTimeOffset QuoteTime { get; set; }

	[JsonPropertyName("tradeTimeInLong")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTimeOffset TradeTime { get; set; }

	public decimal NetChange { get; set; }
	public double Volatility { get; set; }
	public double Delta { get; set; }
	public double Gamma { get; set; }
	public double Theta { get; set; }
	public double Vega { get; set; }
	public double Rho { get; set; }
	public int OpenInterest { get; set; }
	public decimal TimeValue { get; set; }
	public double TheoreticalOptionValue { get; set; }
	public double TheoreticalVolatility { get; set; }
	public decimal StrikePrice { get; set; }
	public long ExpirationDate { get; set; }
	public int DaysToExpiration { get; set; }
	public string ExpirationType { get; set; } = string.Empty;

	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTimeOffset LastTradingDay { get; set; }

	public decimal Multiplier { get; set; }
	public string SettlementType { get; set; } = string.Empty;
	public string DeliverableNote { get; set; } = string.Empty;
	public decimal PercentChange { get; set; }
	public decimal MarkChange { get; set; }
	public decimal MarkPercentChange { get; set; }
	public decimal IntrinsicValue { get; set; }
	public bool NonStandard { get; set; }
	public bool PennyPilot { get; set; }
	public bool InTheMoney { get; set; }
	public bool Mini { get; set; }
}

