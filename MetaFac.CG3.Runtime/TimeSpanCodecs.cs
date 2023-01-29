using System;
using System.Runtime.CompilerServices;

namespace MetaFac.CG3.Runtime
{
    public static class TimeSpanCodecs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan Decode_TimeSpan_From_Int64(this long value) => new TimeSpan(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Encode_TimeSpan_To_Int64(this TimeSpan value) => value.Ticks;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan? Decode_TimeSpan_From_Int64(this long? value, int notUsed) => value is null ? null : new TimeSpan(value.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long? Encode_TimeSpan_To_Int64(this TimeSpan? value) => value?.Ticks;
    }
}