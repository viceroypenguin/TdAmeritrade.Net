using System.Text.Json;

namespace TdAmeritrade.Models.MarketData;

[JsonConverter(typeof(MarketDataResponseConverter))]
public class MarketDataResponse
{
	public IReadOnlyDictionary<string, Hour>? Hours { get; set; }
}

public class MarketDataResponseConverter : JsonConverter<MarketDataResponse>
{
	private static readonly JsonSerializerOptions s_options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, };
	public override MarketDataResponse? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var obj = JsonSerializer.Deserialize<JsonElement>(ref reader);
		var dictionary = new Dictionary<string, Hour>(StringComparer.OrdinalIgnoreCase);
		foreach (var x in obj.EnumerateObject())
		{
			dictionary[x.Name] = x.Value.Deserialize<Hour>(s_options)!;
		}
		return new() { Hours = dictionary, };
	}

	public override void Write(Utf8JsonWriter writer, MarketDataResponse value, JsonSerializerOptions options) => throw new NotImplementedException();
}

public class Hour
{
	public string? Category { get; set; }
	public DateOnly Date { get; set; }
	public string? Exchange { get; set; }
	public bool IsOpen { get; set; }
	public string? MarketType { get; set; }
	public string? Product { get; set; }
	public string? ProductName { get; set; }
	public SessionHours? SessionHours { get; set; }
}

public class SessionHours
{
	public IReadOnlyList<DateRange>? PreMarket { get; set; }
	public IReadOnlyList<DateRange>? RegularMarket { get; set; }
	public IReadOnlyList<DateRange>? PostMarket { get; set; }
}

public class DateRange
{
	public DateTimeOffset Start { get; set; }
	public DateTimeOffset End { get; set; }
}
