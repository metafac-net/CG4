using MessagePack;
using System;
using System.Globalization;

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

        public override string ToString() => new DateTime(Ticks, (DateTimeKind)Kind).ToString("O", CultureInfo.InvariantCulture);

        public static implicit operator DateTimeValue(DateTime value) => new DateTimeValue(value);
        public static implicit operator DateTime(DateTimeValue value) => new DateTime(value.Ticks, (DateTimeKind)value.Kind);

        public bool Equals(DateTimeValue other) => other.Ticks.Equals(Ticks) && other.Kind.Equals(Kind);
        public override bool Equals(object? obj) => obj is DateTimeValue other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(Ticks, Kind);
        public static bool operator ==(DateTimeValue left, DateTimeValue right) => left.Equals(right);
        public static bool operator !=(DateTimeValue left, DateTimeValue right) => !left.Equals(right);

    }
}
