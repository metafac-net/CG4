using Google.Protobuf.WellKnownTypes;
using System;
using System.Runtime.CompilerServices;

namespace MetaCode.Runtime.GProto3
{
    public static class DateTimeHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime Decode_DateTime_From_Timestamp(this Timestamp value)
        {
            if (value is null) return default;
            return value.ToDateTime();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime? Decode_DateTime_From_Timestamp(this Timestamp value, int notUsed)
        {
            if (value is null) return null;
            return value.ToDateTime();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Timestamp Encode_DateTime_To_Timestamp(this DateTime value)
        {
            return Timestamp.FromDateTime(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Timestamp? Encode_DateTime_To_Timestamp(this DateTime? value)
        {
            if (value is null) return null;
            return Timestamp.FromDateTime(value.Value);
        }

    }
}