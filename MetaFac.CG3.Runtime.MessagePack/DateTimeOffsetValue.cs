using MessagePack;
using System;

namespace MetaFac.CG3.Runtime.MessagePack
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

        public override int GetHashCode()
        {
            return DateTimeTicks.GetHashCode() ^ TimeSpanTicks.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return obj is DateTimeOffsetValue other && Equals(other);
        }

        public bool Equals(DateTimeOffsetValue other)
        {
            return other.DateTimeTicks.Equals(DateTimeTicks)
                && other.TimeSpanTicks.Equals(TimeSpanTicks);
        }

        public static implicit operator DateTimeOffsetValue(DateTimeOffset value)
        {
            return new DateTimeOffsetValue(value);
        }

        public static implicit operator DateTimeOffset(DateTimeOffsetValue value)
        {
            return new DateTimeOffset(value.DateTimeTicks, new TimeSpan(value.TimeSpanTicks));
        }
    }
}
