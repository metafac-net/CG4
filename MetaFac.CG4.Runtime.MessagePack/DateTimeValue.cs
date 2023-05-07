using MessagePack;
using System;

namespace MetaFac.CG4.Runtime.MessagePack
{
    [MessagePackObject]
    public struct DateTimeValue : IEquatable<DateTimeValue>
    {
        [Key(0)]
        public readonly long Ticks;

        [Key(1)]
        public readonly int Kind;

        public DateTimeValue(long ticks, int kind)
        {
            Ticks = ticks;
            Kind = kind;
        }

        public DateTimeValue(DateTime value)
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
            return obj is DateTimeValue other && Equals(other);
        }

        public bool Equals(DateTimeValue other)
        {
            return other.Ticks.Equals(Ticks)
                && other.Kind.Equals(Kind);
        }

        public static implicit operator DateTimeValue(DateTime value)
        {
            return new DateTimeValue(value);
        }

        public static implicit operator DateTime(DateTimeValue value)
        {
            return new DateTime(value.Ticks, (DateTimeKind)value.Kind);
        }
    }
}
