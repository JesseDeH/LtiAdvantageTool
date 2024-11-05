using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace AdvantageTool.Utility
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions Options =  new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true
        };
        
        public static string ToJsonString<T>(this T obj)
        {
            return JsonSerializer.Serialize(obj, Options);
        }
    }
}
