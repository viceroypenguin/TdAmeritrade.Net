using System.Text.Json;

namespace TdAmeritrade.Converters;

public class DateTimeConverter : JsonConverter<DateTimeOffset>
{
	public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType != JsonTokenType.Number)
		{
			throw new JsonException($"Unable to parse Datetime. Expected token of type 'Number', found token of type '{reader.TokenType}'.");
		}

		var number = reader.GetInt64();
		var dto = DateTimeOffset.FromUnixTimeMilliseconds(number);
		return dto;
	}

	public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options) =>
		writer.WriteNumberValue(value.ToUnixTimeMilliseconds());
}
