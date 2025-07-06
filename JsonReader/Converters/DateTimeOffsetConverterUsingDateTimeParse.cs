using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonReader.Converters;

public class DateTimeOffsetConverterUsingDateTimeParse : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader is Utf8JsonReader r)
        {
            if (r.TokenType == JsonTokenType.Null)
            {
                throw new JsonException("The JSON token is null.");
            }

            string dateString = r.GetString() ?? throw new JsonException("The JSON value is null.");
            return DateTimeOffset.Parse(dateString!);
        }
        return new DateTimeOffset();
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString());
}