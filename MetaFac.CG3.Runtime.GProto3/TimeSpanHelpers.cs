using Google.Protobuf.WellKnownTypes;
using System;
using System.Runtime.CompilerServices;

namespace MetaCode.Runtime.GProto3
{
    public static class TimeSpanHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan Decode_TimeSpan_From_Duration(this Duration value)
        {
            if (value is null) return default;
            return value.ToTimeSpan();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan? Decode_TimeSpan_From_Duration(this Duration value, int notUsed)
        {
            if (value is null) return null;
            return value.ToTimeSpan();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Duration Encode_TimeSpan_To_Duration(this TimeSpan value)
        {
            return Duration.FromTimeSpan(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Duration? Encode_TimeSpan_To_Duration(this TimeSpan? value)
        {
            if (value is null) return null;
            return Duration.FromTimeSpan(value.Value);
        }

    }
}