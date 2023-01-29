using System;
using System.Runtime.CompilerServices;

namespace MetaFac.CG3.Runtime
{
    public static class DateTimeBinaryCodec
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong EncodeToInt64(this DateTime value)
        {
            return (ulong)value.Ticks | (ulong)value.Kind << 62;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime DecodeToDateTime(this ulong value)
        {
            unchecked
            {
                ulong ticks = value & 0x3FFFFFFFFFFFFFFF;
                ulong kind = value >> 62;
                return new DateTime((long)ticks, (DateTimeKind)kind);
            }
        }
    }
}