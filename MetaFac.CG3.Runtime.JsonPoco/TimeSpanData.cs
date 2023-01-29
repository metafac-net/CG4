using System;
using System.Text.Json.Serialization;

namespace MetaCode.Runtime.JsonPoco
{
    [JsonConverter(typeof(JsonConverter_TimeSpanData))]
    public struct TimeSpanData : IEquatable<TimeSpanData>
    {
        public TimeSpan Value { get; set; }

        public TimeSpanData(TimeSpan value)
        {
            Value = value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return obj is TimeSpanData other && Equals(other);
        }

        public bool Equals(TimeSpanData other)
        {
            return other.Value.Equals(this.Value);
        }

        public static implicit operator TimeSpanData(TimeSpan value)
        {
            return new TimeSpanData(value);
        }

        public static implicit operator TimeSpan(TimeSpanData value)
        {
            return value.Value;
        }
    }
}