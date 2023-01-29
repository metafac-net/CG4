using System;
using System.Runtime.CompilerServices;

namespace MetaFac.CG3.Runtime.ProtobufNet3
{
    //todo add support for NodaTime
    public static class ConversionHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset Decode_DateTimeOffset_From_DateTimeOffsetData(this DateTimeOffsetData value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffsetData Encode_DateTimeOffset_To_DateTimeOffsetData(this DateTimeOffset value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset? Decode_DateTimeOffset_From_DateTimeOffsetData(this DateTimeOffsetData? value, int notUsed) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffsetData? Encode_DateTimeOffset_To_DateTimeOffsetData(this DateTimeOffset? value) => value;

        //-----

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset ToExternal(this DateTimeOffsetData value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffsetData ToInternal(this DateTimeOffset value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset? ToExternal(this DateTimeOffsetData? value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffsetData? ToInternal(this DateTimeOffset? value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime ToExternal(this DateTimeData value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeData ToInternal(this DateTime value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime? ToExternal(this DateTimeData? value) => value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeData? ToInternal(this DateTime? value) => value;

    }

}