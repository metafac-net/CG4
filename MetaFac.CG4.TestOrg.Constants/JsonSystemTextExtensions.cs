using System.Text.Json;
using System.Text.Json.Serialization;

namespace MetaFac.CG4.TestOrg.Common
{
    public static class JsonSystemTextExtensions
    {
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals,
        };

        public static string SerializeToJsonSystemText<T>(this T value)
        {
            return JsonSerializer.Serialize(value, options);
        }

        public static T? DeserializeFromJsonSystemText<T>(this string buffer)
        {
            return JsonSerializer.Deserialize<T>(buffer, options);
        }
    }
}
