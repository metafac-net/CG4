using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MetaCode.Runtime.JsonPoco
{
    public class JsonConverter_TimeSpanData : JsonConverter<TimeSpanData>
    {
        public override TimeSpanData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            TimeSpan parsed = value is null ? default : TimeSpan.ParseExact(value, "c", CultureInfo.InvariantCulture);
            return new TimeSpanData(parsed);
        }

        public override void Write(Utf8JsonWriter writer, TimeSpanData value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Value.ToString("c", CultureInfo.InvariantCulture));
        }
    }
}