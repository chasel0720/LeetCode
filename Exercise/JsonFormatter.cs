using System.Text.Json;
using System.Text.Json.Serialization;

public static class JsonFormatter
{
    public static string ToJsonString<T>(this T value)
    {
        if (value == null) return "null";

        var options = new JsonSerializerOptions
        {
            WriteIndented = false,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        return JsonSerializer.Serialize(value, options);
    }
}