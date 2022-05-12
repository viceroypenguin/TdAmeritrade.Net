namespace TdAmeritrade.Models.Transactions;

public enum TransactionSearchType
{
	[EnumMember(Value = "ALL")] All,
	[EnumMember(Value = "TRADE")] Trade,
	[EnumMember(Value = "BUY_ONLY")] BuyOnly,
	[EnumMember(Value = "SELL_ONLY")] SellOnly,
	[EnumMember(Value = "CASH_IN_OR_CASH_OUT")] CashInOrCashOut,
	[EnumMember(Value = "CHECKING")] Checking,
	[EnumMember(Value = "DIVIDEND")] Dividend,
	[EnumMember(Value = "INTEREST")] Interest,
	[EnumMember(Value = "OTHER")] Other,
	[EnumMember(Value = "ADVISOR_FEES")] AdvisorFees,
}

public class TransactionSearchOptions
{
	public TransactionSearchType Type { get; set; }
	public string? Symbol { get; set; }
	public long StartDate { get; set; }
	public long EndDate { get; set; }
}

public class Transaction
{
	public string Type { get; set; } = string.Empty;
	public string? ClearingReferenceNumber { get; set; }
	public string? SubAccount { get; set; }
	[JsonConverter(typeof(DateOnlyConverter))] public DateOnly SettlementDate { get; set; }
	public string? OrderId { get; set; }
	public decimal Sma { get; set; }
	public decimal RequirementReallocationAmount { get; set; }
	public decimal DayTradeBuyingPowerEffect { get; set; }
	public decimal NetAmount { get; set; }
	[JsonConverter(typeof(DateTimeOffsetConverter))] public DateTimeOffset TransactionDate { get; set; }
	[JsonConverter(typeof(DateTimeOffsetConverter))] public DateTimeOffset? OrderDate { get; set; }
	public string TransactionSubType { get; set; } = string.Empty;
	public long TransactionId { get; set; }
	public bool CashBalanceEffectFlag { get; set; }
	public string Description { get; set; } = string.Empty;
	public string? AchStatus { get; set; }
	public decimal AccruedInterest { get; set; }
	public Fees? Fees { get; set; }
	public TransactionItem? TransactionItem { get; set; }
}

public class TransactionItem
{
	public long AccountId { get; set; }
	public decimal Amount { get; set; }
	public decimal Price { get; set; }
	public decimal Cost { get; set; }
	public decimal ParentOrderKey { get; set; }
	public string? ParentChildIndicator { get; set; }
	public string? Instruction { get; set; }
	public string? PositionEffect { get; set; }
	public Instrument? Instrument { get; set; }
}

public class Instrument
{
	public string Type { get; set; } = string.Empty;
	public string Symbol { get; set; } = string.Empty;
	public string? UnderlyingSymbol { get; set; }
	public string? OptionExpirationDate { get; set; }
	public decimal OptionStrikePrice { get; set; }
	public string? PutCall { get; set; }
	public string Cusip { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string AssetType { get; set; } = string.Empty;
	public string? BondMaturityDate { get; set; }
	public decimal BondInterestRate { get; set; }
}

public class Fees
{
	public decimal RFee { get; set; }
	public decimal AdditionalFee { get; set; }
	public decimal CdscFee { get; set; }
	public decimal RegFee { get; set; }
	public decimal OtherCharges { get; set; }
	public decimal Commission { get; set; }
	public decimal OptRegFee { get; set; }
	public decimal SecFee { get; set; }
}
