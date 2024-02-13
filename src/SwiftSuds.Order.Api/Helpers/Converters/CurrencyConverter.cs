using SwiftSuds.Domain.ValueObjects;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwiftSuds.Order.Api.Helpers.Converters;

public class CurrencyConverter<TCurrency, TValue> : JsonConverter<TCurrency> 
    where TCurrency : Currency
    where TValue : notnull
{
    public override TCurrency? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = JsonSerializer.Deserialize<TValue>(ref reader, options);
        if (value != null)
        {
            return (TCurrency)Activator.CreateInstance(typeof(TCurrency), value)!;
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, TCurrency? value, JsonSerializerOptions options)
    {
        if (value is null)
            writer.WriteNullValue();
        else
            JsonSerializer.Serialize(writer, value.Symbol, options);
    }
}
