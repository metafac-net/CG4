﻿using System.Text.Json.Serialization;
using System.Text.Json;

namespace MetaFac.CG4.TestOrg.ModelsNet7.Tests
{
    internal static class JsonSystemTextExtensions
    {
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals,
            //TypeNameHandling = TypeNameHandling.All,
            //TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
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