using System;
using System.Runtime.CompilerServices;

namespace MetaCode.Runtime
{
    public static class TimeSpanCodecs
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan Decode_TimeSpan_From_Int64(this Int64 value) => new TimeSpan(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 Encode_TimeSpan_To_Int64(this TimeSpan value) => value.Ticks;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan? Decode_TimeSpan_From_Int64(this Int64? value, int notUsed) => value is null ? null : (TimeSpan?)new TimeSpan(value.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64? Encode_TimeSpan_To_Int64(this TimeSpan? value) => value?.Ticks;
    }
}