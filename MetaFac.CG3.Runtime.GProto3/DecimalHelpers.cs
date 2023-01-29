using System.Runtime.CompilerServices;

namespace MetaCode.Runtime.GProto3
{
    public static class DecimalHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Decode_Decimal_From_String(this string value)
        {
            if (value is null) return default;
            return decimal.Parse(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal? Decode_Decimal_From_String(this string value, int notUsed)
        {
            if (value is null) return null;
            return decimal.Parse(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Encode_Decimal_To_String(this decimal value)
        {
            return value.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string? Encode_Decimal_To_String(this decimal? value)
        {
            if (value is null) return null;
            return value.Value.ToString();
        }

    }
}
