using System.Text.Json;

namespace TdAmeritrade.Models.Accounts;

public class AccountContainer
{
	[JsonPropertyName("securitiesAccount")]
	public Account Account { get; set; } = default!;
}

public class Account
{
	public string Type { get; set; } = string.Empty;
	public string AccountId { get; set; } = string.Empty;
	public int RoundTrips { get; set; }
	public bool IsDayTrader { get; set; }
	public bool IsClosingOnlyRestricted { get; set; }
	public IReadOnlyList<Position>? Positions { get; set; }
	public IReadOnlyList<OrderStrategy>? OrderStrategies { get; set; }
	public InitialBalances? InitialBalances { get; set; }
	public CurrentBalances? CurrentBalances { get; set; }
	public ProjectedBalances? ProjectedBalances { get; set; }
}

public class InitialBalances
{
	public decimal AccountValue { get; set; }
	public decimal AccruedInterest { get; set; }
	public decimal AvailableFundsNonMarginableTrade { get; set; }
	public decimal BondValue { get; set; }
	public decimal BuyingPower { get; set; }
	public decimal CashAvailableForTrading { get; set; }
	public decimal CashAvailableForWithdrawal { get; set; }
	public decimal CashBalance { get; set; }
	public decimal CashDebitCallValue { get; set; }
	public decimal CashReceipts { get; set; }
	public decimal DayTradingBuyingPower { get; set; }
	public decimal DayTradingBuyingPowerCall { get; set; }
	public decimal DayTradingEquityCall { get; set; }
	public decimal Equity { get; set; }
	public decimal EquityPercentage { get; set; }
	public bool IsInCall { get; set; }
	public decimal LiquidationValue { get; set; }
	public decimal LongMarginValue { get; set; }
	public decimal LongOptionMarketValue { get; set; }
	public decimal LongStockValue { get; set; }
	public decimal MaintenanceCall { get; set; }
	public decimal MaintenanceRequirement { get; set; }
	public decimal Margin { get; set; }
	public decimal MarginBalance { get; set; }
	public decimal MarginEquity { get; set; }
	public decimal MoneyMarketFund { get; set; }
	public decimal MutualFundValue { get; set; }
	public decimal PendingDeposits { get; set; }
	public decimal RegTCall { get; set; }
	public decimal ShortBalance { get; set; }
	public decimal ShortMarginValue { get; set; }
	public decimal ShortOptionMarketValue { get; set; }
	public decimal ShortStockValue { get; set; }
	public decimal TotalCash { get; set; }
	public decimal UnsettledCash { get; set; }
}

public class CurrentBalances
{
	public decimal AccruedInterest { get; set; }
	public decimal AvailableFunds { get; set; }
	public decimal AvailableFundsNonMarginableTrade { get; set; }
	public decimal BondValue { get; set; }
	public decimal BuyingPower { get; set; }
	public decimal BuyingPowerNonMarginableTrade { get; set; }
	public decimal CashAvailableForTrading { get; set; }
	public decimal CashAvailableForWithdrawal { get; set; }
	public decimal CashBalance { get; set; }
	public decimal CashCall { get; set; }
	public decimal CashDebitCallValue { get; set; }
	public decimal CashReceipts { get; set; }
	public decimal DayTradingBuyingPower { get; set; }
	public decimal Equity { get; set; }
	public decimal EquityPercentage { get; set; }
	public decimal LiquidationValue { get; set; }
	public decimal LongMarginValue { get; set; }
	public decimal LongMarketValue { get; set; }
	public decimal LongNonMarginableMarketValue { get; set; }
	public decimal LongOptionMarketValue { get; set; }
	public decimal MaintenanceCall { get; set; }
	public decimal MaintenanceRequirement { get; set; }
	public decimal MarginBalance { get; set; }
	public decimal MoneyMarketFund { get; set; }
	public decimal MutualFundValue { get; set; }
	public decimal PendingDeposits { get; set; }
	public decimal RegTCall { get; set; }
	public decimal Savings { get; set; }
	public decimal ShortBalance { get; set; }
	public decimal ShortMarginValue { get; set; }
	public decimal ShortMarketValue { get; set; }
	public decimal ShortOptionMarketValue { get; set; }
	public decimal Sma { get; set; }
	public decimal TotalCash { get; set; }
	public decimal UnsettledCash { get; set; }
}

public class ProjectedBalances
{
	public decimal AccruedInterest { get; set; }
	public decimal AvailableFunds { get; set; }
	public decimal AvailableFundsNonMarginableTrade { get; set; }
	public decimal BondValue { get; set; }
	public decimal BuyingPower { get; set; }
	public decimal CashAvailableForTrading { get; set; }
	public decimal CashAvailableForWithdrawal { get; set; }
	public decimal CashBalance { get; set; }
	public decimal CashCall { get; set; }
	public decimal CashDebitCallValue { get; set; }
	public decimal CashReceipts { get; set; }
	public decimal DayTradingBuyingPower { get; set; }
	public decimal DayTradingBuyingPowerCall { get; set; }
	public bool IsInCall { get; set; }
	public decimal LiquidationValue { get; set; }
	public decimal LongMarketValue { get; set; }
	public decimal LongNonMarginableMarketValue { get; set; }
	public decimal LongOptionMarketValue { get; set; }
	public decimal MaintenanceCall { get; set; }
	public decimal MoneyMarketFund { get; set; }
	public decimal MutualFundValue { get; set; }
	public decimal PendingDeposits { get; set; }
	public decimal RegTCall { get; set; }
	public decimal Savings { get; set; }
	public decimal ShortMarketValue { get; set; }
	public decimal ShortOptionMarketValue { get; set; }
	public decimal StockBuyingPower { get; set; }
	public decimal TotalCash { get; set; }
	public decimal UnsettledCash { get; set; }
}

public class Position
{
	public decimal AgedQuantity { get; set; }
	public decimal AveragePrice { get; set; }
	public decimal CurrentDayCost { get; set; }
	public decimal CurrentDayProfitLoss { get; set; }
	public decimal CurrentDayProfitLossPercentage { get; set; }
	public decimal LongQuantity { get; set; }
	public decimal MaintenanceRequirement { get; set; }
	public decimal MarketValue { get; set; }
	public decimal PreviousSessionLongQuantity { get; set; }
	public decimal SettledLongQuantity { get; set; }
	public decimal SettledShortQuantity { get; set; }
	public decimal ShortQuantity { get; set; }
	public Instrument? Instrument { get; set; }
}

public class InstrumentConverter : JsonConverter<Instrument>
{
	public override Instrument? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var element = JsonSerializer.Deserialize<JsonElement>(ref reader);
		return element.GetProperty("assetType").GetString() switch
		{
			"EQUITY" => element.Deserialize<Equity>(options),
			"INDEX" => element.Deserialize<Equity>(options),
			"FIXED_INCOME" => element.Deserialize<FixedIncome>(options),
			"MUTUAL_FUND" => element.Deserialize<MutualFund>(options),
			"CURRENCY" => element.Deserialize<Currency>(options),
			"CASH_EQUIVALENT" => element.Deserialize<CashEquivalent>(options),
			"OPTION" => element.Deserialize<Option>(options),
			_ => throw new JsonException("Unable to parse Instrument node"),
		};
	}

	public override void Write(Utf8JsonWriter writer, Instrument value, JsonSerializerOptions options) =>
		JsonSerializer.Serialize(writer, value, value.GetType());
}

[JsonConverter(typeof(InstrumentConverter))]
public class Instrument
{
	public string AssetType { get; set; } = string.Empty;
	public string Cusip { get; set; } = string.Empty;
	public string Symbol { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
}

public class Equity : Instrument { }

public class FixedIncome : Instrument
{
	public string MaturityDate { get; set; } = string.Empty;
	public decimal VariableRate { get; set; }
	public decimal Factor { get; set; }
}

public class MutualFund : Instrument
{
	public string Type { get; set; } = string.Empty;
}

public class Currency : Instrument
{
	public string? CurrencyType { get; set; }
}

public class CashEquivalent : Instrument
{
	public string Type { get; set; } = string.Empty;
}

public class Option : Instrument
{
	public string? Type { get; set; }
	public string? PutCall { get; set; }
	public string? UnderlyingSymbol { get; set; }
	public decimal OptionMultiplier { get; set; }
	public IReadOnlyList<OptionDeliverable> OptionDeliverables { get; set; } = Array.Empty<OptionDeliverable>();
}

public class OptionDeliverable
{
	public string? Symbol { get; set; }
	public decimal DeliverableUnits { get; set; }
	public string? CurrencyType { get; set; }
	public string? AssetType { get; set; }
}


public class OrderStrategy
{
	public string? Session { get; set; }
	public string? Duration { get; set; }
	public string? OrderType { get; set; }
	public CancelTime? CancelTime { get; set; }
	public string? ComplexOrderStrategyType { get; set; }
	public decimal Quantity { get; set; }
	public decimal FilledQuantity { get; set; }
	public decimal RemainingQuantity { get; set; }
	public string? RequestedDestination { get; set; }
	public string? DestinationLinkName { get; set; }
	public string? ReleaseTime { get; set; }
	public decimal StopPrice { get; set; }
	public string? StopPriceLinkBasis { get; set; }
	public string? StopPriceLinkType { get; set; }
	public decimal StopPriceOffset { get; set; }
	public string? StopType { get; set; }
	public string? PriceLinkBasis { get; set; }
	public string? PriceLinkType { get; set; }
	public decimal Price { get; set; }
	public string? TaxLotMethod { get; set; }
	public decimal ActivationPrice { get; set; }
	public string? SpecialInstruction { get; set; }
	public string? OrderStrategyType { get; set; }
	public decimal OrderId { get; set; }
	public bool Cancelable { get; set; }
	public bool Editable { get; set; }
	public string? Status { get; set; }
	public string? EnteredTime { get; set; }
	public string? CloseTime { get; set; }
	public string? Tag { get; set; }
	public string? AccountId { get; set; }
	public string? StatusDescription { get; set; }

	[JsonPropertyName("orderLegCollection")]
	public IReadOnlyList<OrderLeg>? OrderLegs { get; set; } = Array.Empty<OrderLeg>();
	[JsonPropertyName("orderActivityCollection")]
	public IReadOnlyList<OrderActivity>? OrderActivities { get; set; } = Array.Empty<OrderActivity>();
	[JsonPropertyName("replacingOrderCollection")]
	public IReadOnlyList<ReplacingOrder>? ReplacingOrders { get; set; } = Array.Empty<ReplacingOrder>();
	public IReadOnlyList<ChildOrderStrategy>? ChildOrderStrategies { get; set; } = Array.Empty<ChildOrderStrategy>();
}

public class CancelTime
{
	public string? Date { get; set; }
	public bool ShortFormat { get; set; }
}

public class OrderLeg
{
	public string? OrderLegType { get; set; }
	public decimal LegId { get; set; }
	public string? Instrument { get; set; }
	public string? Instruction { get; set; }
	public string? PositionEffect { get; set; }
	public decimal Quantity { get; set; }
	public string? QuantityType { get; set; }
}

public class ReplacingOrder
{
}

public class ChildOrderStrategy
{
}

public class OrderActivity
{
	public string? ActivityType { get; set; }
	public string? ExecutionType { get; set; }
	public decimal Quantity { get; set; }
	public decimal OrderRemainingActivity { get; set; }
	public IReadOnlyList<ExecutionLeg> ExecutionLegs { get; set; } = Array.Empty<ExecutionLeg>();
}

public class ExecutionLeg
{
	public decimal LegId { get; set; }
	public decimal Quanitty { get; set; }
	public decimal MismarkedQuantity { get; set; }
	public decimal Price { get; set; }
	public string? Time { get; set; }
}
