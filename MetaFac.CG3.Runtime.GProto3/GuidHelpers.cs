using System;
using System.Runtime.CompilerServices;

namespace MetaCode.Runtime.GProto3
{
    public static class GuidHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid Decode_Guid_From_String(this string value)
        {
            if (value is null) return default;
            return Guid.ParseExact(value, "D");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid? Decode_Guid_From_String(this string value, int notUsed)
        {
            if (value is null) return null;
            return Guid.ParseExact(value, "D");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Encode_Guid_To_String(this Guid value)
        {
            return value.ToString("D");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string? Encode_Guid_To_String(this Guid? value)
        {
            if (value is null) return null;
            return value.Value.ToString("D");
        }

    }
}
