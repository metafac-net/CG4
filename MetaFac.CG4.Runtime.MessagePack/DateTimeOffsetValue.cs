using MessagePack;
using System;
using System.Globalization;

namespace MetaFac.CG4.Runtime.MessagePack
{
    [MessagePackObject]
    public struct DateTimeOffsetValue : IEquatable<DateTimeOffsetValue>
    {
        [Key(0)]
        public readonly long DateTimeTicks;

        [Key(1)]
        public readonly long TimeSpanTicks;

        public DateTimeOffsetValue(long dateTimeTicks, long timeSpanTicks)
        {
            DateTimeTicks = dateTimeTicks;
            TimeSpanTicks = timeSpanTicks;
        }

        public DateTimeOffsetValue(DateTimeOffset value)
        {
            DateTimeTicks = value.Ticks;
            TimeSpanTicks = value.Offset.Ticks;
        }

        public override string ToString() => new DateTimeOffset(DateTimeTicks, new TimeSpan(TimeSpanTicks)).ToString("O", CultureInfo.InvariantCulture);

        public static implicit operator DateTimeOffsetValue(DateTimeOffset value) => new DateTimeOffsetValue(value);
        public static implicit operator DateTimeOffset(DateTimeOffsetValue value) => new DateTimeOffset(value.DateTimeTicks, new TimeSpan(value.TimeSpanTicks));

        public bool Equals(DateTimeOffsetValue other) => other.DateTimeTicks.Equals(DateTimeTicks) && other.TimeSpanTicks.Equals(TimeSpanTicks);
        public override bool Equals(object? obj) => obj is DateTimeOffsetValue other && Equals(other);
        public override int GetHashCode() => DateTimeTicks.GetHashCode() ^ TimeSpanTicks.GetHashCode();
        public static bool operator ==(DateTimeOffsetValue left, DateTimeOffsetValue right) => left.Equals(right);
        public static bool operator !=(DateTimeOffsetValue left, DateTimeOffsetValue right) => !left.Equals(right);


    }
}
