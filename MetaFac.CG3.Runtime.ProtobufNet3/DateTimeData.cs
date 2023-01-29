using ProtoBuf;
using System;

namespace MetaCode.Runtime.ProtobufNet3
{
    [ProtoContract]
    public struct DateTimeData : IEquatable<DateTimeData>
    {
        [ProtoMember(1)]
        public long Ticks { get; set; }

        [ProtoMember(2)]
        public int Kind { get; set; }

        public DateTimeData(DateTime value)
        {
            Ticks = value.Ticks;
            Kind = (int)value.Kind;
        }

        public override int GetHashCode()
        {
            return Ticks.GetHashCode() ^ Kind.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return obj is DateTimeData other && Equals(other);
        }

        public bool Equals(DateTimeData other)
        {
            return other.Ticks.Equals(this.Ticks)
                && other.Kind.Equals(this.Kind);
        }

        public static implicit operator DateTimeData(DateTime value)
        {
            return new DateTimeData(value);
        }

        public static implicit operator DateTime(DateTimeData value)
        {
            return new DateTime(value.Ticks, (DateTimeKind)value.Kind);
        }
    }
}