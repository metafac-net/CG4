using System;
using System.Runtime.CompilerServices;

namespace MetaFac.CG4.Runtime.JsonPoco
{
    public static class ConversionHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan ToExternal(this TimeSpanData value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpanData ToInternal(this TimeSpan value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan? ToExternal(this TimeSpanData? value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpanData? ToInternal(this TimeSpan? value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan Decode_TimeSpan_From_TimeSpanData(this TimeSpanData value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan? Decode_TimeSpan_From_TimeSpanData(this TimeSpanData? value, int notUsed) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpanData Encode_TimeSpan_To_TimeSpanData(this TimeSpan value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpanData? Encode_TimeSpan_To_TimeSpanData(this TimeSpan? value) => value;

    }
}