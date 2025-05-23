using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonReader.Converters;
public class DateTimeOffsetConverterUsingDateTimeParse : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DateTimeOffset.Parse(reader.GetString());
    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString());
}

