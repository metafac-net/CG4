using System;
using System.Runtime.CompilerServices;

namespace MetaFac.CG4.Runtime.MessagePack
{
    public static class ConversionHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime ToExternal(this DateTimeValue value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime? ToExternal(this DateTimeValue? value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeValue ToInternal(this DateTime value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeValue? ToInternal(this DateTime? value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset ToExternal(this DateTimeOffsetValue value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset? ToExternal(this DateTimeOffsetValue? value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffsetValue ToInternal(this DateTimeOffset value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffsetValue? ToInternal(this DateTimeOffset? value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToExternal(this DecimalValue value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal? ToExternal(this DecimalValue? value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DecimalValue ToInternal(this decimal value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DecimalValue? ToInternal(this decimal? value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid ToExternal(this GuidValue value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid? ToExternal(this GuidValue? value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GuidValue ToInternal(this Guid value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GuidValue? ToInternal(this Guid? value)
        {
            return value;
        }

    }
}
