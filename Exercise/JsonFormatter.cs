using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Exercise;
public static class JsonFormatter
{
    public static string ToJsonString<T>(this T value)
    {
        if (value == null) return "null";
        if (value.GetType().IsValueType)
        {
            return SerializeTuple(value);
        }
        if (!value.GetType().IsClass) return $"{value}";

        var options = new JsonSerializerOptions
        {
            WriteIndented = false,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        return JsonSerializer.Serialize(value, options);
    }

    static string SerializeTuple(object tuple)
    {
        var sb = new StringBuilder("(");
        var type = tuple.GetType();

        var fields = type.GetFields();
        for (int i = 0; i < fields.Length; i++)
        {
            var value = fields[i].GetValue(tuple);
            sb.Append(FormatValue(value));
            if (i < fields.Length - 1) sb.Append(", ");
        }

        sb.Append(')');
        return sb.ToString();
    }

    static string FormatValue(object value)
    {
        if (value == null) return "null";

        return value switch
        {
            Array array => FormatArray(array),
            ITuple tuple => SerializeTuple(tuple),
            _ => value.ToString()
        };
    }

    static string FormatArray(Array arr)
    {
        var sb = new StringBuilder("[");
        for (int i = 0; i < arr.Length; i++)
        {
            sb.Append(arr.GetValue(i));
            if (i < arr.Length - 1) sb.Append(',');
        }
        sb.Append(']');
        return sb.ToString();
    }

}