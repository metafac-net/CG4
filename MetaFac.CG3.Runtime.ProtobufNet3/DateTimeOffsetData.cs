using ProtoBuf;
using System;

namespace MetaCode.Runtime.ProtobufNet3
{
    [ProtoContract]
    public struct DateTimeOffsetData : IEquatable<DateTimeOffsetData>
    {
        [ProtoMember(1)]
        public long DateTimeTicks { get; set; }

        [ProtoMember(2, DataFormat = DataFormat.ZigZag)]
        public long TimeSpanTicks { get; set; }

        public DateTimeOffsetData(DateTimeOffset value)
        {
            DateTimeTicks = value.Ticks;
            TimeSpanTicks = value.Offset.Ticks;
        }

        public override int GetHashCode()
        {
            return DateTimeTicks.GetHashCode() ^ TimeSpanTicks.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return obj is DateTimeOffsetData other && Equals(other);
        }

        public bool Equals(DateTimeOffsetData other)
        {
            return other.DateTimeTicks.Equals(this.DateTimeTicks)
                && other.TimeSpanTicks.Equals(this.TimeSpanTicks);
        }

        public static implicit operator DateTimeOffsetData(DateTimeOffset value)
        {
            return new DateTimeOffsetData(value);
        }

        public static implicit operator DateTimeOffset(DateTimeOffsetData value)
        {
            return new DateTimeOffset(value.DateTimeTicks, new TimeSpan(value.TimeSpanTicks));
        }
    }
}