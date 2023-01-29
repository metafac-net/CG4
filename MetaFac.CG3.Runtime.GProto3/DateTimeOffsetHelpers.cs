using Google.Protobuf.WellKnownTypes;
using System;
using System.Runtime.CompilerServices;

namespace MetaFac.CG3.Runtime.GProto3
{
    public static class DateTimeOffsetHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset Decode_DateTimeOffset_From_Timestamp(this Timestamp value)
        {
            if (value is null) return default;
            return value.ToDateTimeOffset();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset? Decode_DateTimeOffset_From_Timestamp(this Timestamp value, int notUsed)
        {
            if (value is null) return null;
            return value.ToDateTimeOffset();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Timestamp Encode_DateTimeOffset_To_Timestamp(this DateTimeOffset value)
        {
            return Timestamp.FromDateTimeOffset(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Timestamp? Encode_DateTimeOffset_To_Timestamp(this DateTimeOffset? value)
        {
            if (value is null) return null;
            return Timestamp.FromDateTimeOffset(value.Value);
        }

    }
}
