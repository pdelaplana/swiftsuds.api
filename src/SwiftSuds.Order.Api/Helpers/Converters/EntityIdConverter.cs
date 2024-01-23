using SwiftSuds.Domain.ValueObjects;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwiftSuds.Order.Api.Helpers.Converters;

public class EntityIdConverter<TEntityId, TValue> : JsonConverter<TEntityId> 
    where TEntityId : EntityId
    where TValue : notnull
{
    public override TEntityId? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = JsonSerializer.Deserialize<TValue>(ref reader, options);
        if (value != null)
        {
            return (TEntityId)Activator.CreateInstance(typeof(TEntityId), value)!;
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, TEntityId? value, JsonSerializerOptions options)
    {
        if (value is null)
            writer.WriteNullValue();
        else
            JsonSerializer.Serialize(writer, value.Value, options);
    }
}
