using System.Text.Json;

namespace TdAmeritrade.Converters;

public class UnixDateTimeConverter : JsonConverter<DateTimeOffset>
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

public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
	private static readonly string[] s_formatStrings =
	{
		"yyyy'-'MM'-'dd'T'HH':'mm':'sszzz",
	};

	public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType != JsonTokenType.String)
		{
			throw new JsonException($"Unable to parse Datetime. Expected token of type 'Number', found token of type '{reader.TokenType}'.");
		}

		var str = reader.GetString()!;
		var dt = DateTimeOffset.ParseExact(str, s_formatStrings, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
		return dt;
	}

	public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options) =>
		writer.WriteNumberValue(value.ToUnixTimeMilliseconds());
}

public class DateOnlyConverter : JsonConverter<DateOnly>
{
	private static readonly string[] s_formatStrings =
	{
		"yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff",
		"yyyy'-'MM'-'dd",
	};

	public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType != JsonTokenType.String)
		{
			throw new JsonException($"Unable to parse Datetime. Expected token of type 'String', found token of type '{reader.TokenType}'.");
		}

		var str = reader.GetString()!;
		var dt = DateTime.ParseExact(str, s_formatStrings, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
		return dt;
	}

	public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) => throw new NotImplementedException();
}
