using Newtonsoft.Json;
using System.IO;

namespace MetaFac.CG4.TestOrg.Common
{
    public static class JsonNewtonSoftExtensions
    {
        private static readonly JsonSerializer serializer = new JsonSerializer()
        {
            Formatting = Formatting.Indented,
            //NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.All,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
        };

        public static string SerializeToJsonNewtonSoft<T>(this T value)
        {
            using var writer = new StringWriter();
            serializer.Serialize(writer, value);
            return writer.ToString();
        }

        public static T? DeserializeFromJsonNewtonSoft<T>(this string buffer)
        {
            using var tr = new StringReader(buffer);
            using var reader = new JsonTextReader(tr);
            return serializer.Deserialize<T>(reader);
        }
    }
}
