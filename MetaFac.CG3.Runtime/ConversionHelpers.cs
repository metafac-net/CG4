using MetaFac.Memory;
using System;
using System.Runtime.CompilerServices;

namespace MetaCode.Runtime
{
    public static class BenignCodecs
    {
        // non-nullable
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool Decode_Boolean_From_Boolean(this bool value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool Encode_Boolean_To_Boolean(this bool value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static sbyte Decode_SByte_From_SByte(this sbyte value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static sbyte Encode_SByte_To_SByte(this sbyte value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static byte Decode_Byte_From_Byte(this byte value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static byte Encode_Byte_To_Byte(this byte value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static short Decode_Int16_From_Int16(this short value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static short Encode_Int16_To_Int16(this short value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static ushort Decode_UInt16_From_UInt16(this ushort value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static ushort Encode_UInt16_To_UInt16(this ushort value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static char Decode_Char_From_Char(this char value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static char Encode_Char_To_Char(this char value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int Decode_Int32_From_Int32(this int value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int Encode_Int32_To_Int32(this int value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static uint Decode_UInt32_From_UInt32(this uint value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static uint Encode_UInt32_To_UInt32(this uint value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Decode_Single_From_Single(this float value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Encode_Single_To_Single(this float value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static long Decode_Int64_From_Int64(this long value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static long Encode_Int64_To_Int64(this long value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static ulong Decode_UInt64_From_UInt64(this ulong value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static ulong Encode_UInt64_To_UInt64(this ulong value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double Decode_Double_From_Double(this double value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double Encode_Double_To_Double(this double value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DateTime Decode_DateTime_From_DateTime(this DateTime value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DateTime Encode_DateTime_To_DateTime(this DateTime value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static TimeSpan Decode_TimeSpan_From_TimeSpan(this TimeSpan value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static TimeSpan Encode_TimeSpan_To_TimeSpan(this TimeSpan value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DateTimeOffset Decode_DateTimeOffset_From_DateTimeOffset(this DateTimeOffset value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DateTimeOffset Encode_DateTimeOffset_To_DateTimeOffset(this DateTimeOffset value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static decimal Decode_Decimal_From_Decimal(this decimal value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static decimal Encode_Decimal_To_Decimal(this decimal value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Guid Decode_Guid_From_Guid(this Guid value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Guid Encode_Guid_To_Guid(this Guid value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static string? Decode_String_From_String(this string? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static string? Encode_String_To_String(this string? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Octets? Decode_Octets_From_Octets(this Octets? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Octets? Encode_Octets_To_Octets(this Octets? value) => value;

        // nullable
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool? Decode_Boolean_From_Boolean(this bool? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool? Encode_Boolean_To_Boolean(this bool? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static sbyte? Decode_SByte_From_SByte(this sbyte? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static sbyte? Encode_SByte_To_SByte(this sbyte? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static byte? Decode_Byte_From_Byte(this byte? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static byte? Encode_Byte_To_Byte(this byte? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static short? Decode_Int16_From_Int16(this short? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static short? Encode_Int16_To_Int16(this short? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static ushort? Decode_UInt16_From_UInt16(this ushort? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static ushort? Encode_UInt16_To_UInt16(this ushort? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static char? Decode_Char_From_Char(this char? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static char? Encode_Char_To_Char(this char? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int? Decode_Int32_From_Int32(this int? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int? Encode_Int32_To_Int32(this int? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static uint? Decode_UInt32_From_UInt32(this uint? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static uint? Encode_UInt32_To_UInt32(this uint? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float? Decode_Single_From_Single(this float? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float? Encode_Single_To_Single(this float? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static long? Decode_Int64_From_Int64(this long? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static long? Encode_Int64_To_Int64(this long? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static ulong? Decode_UInt64_From_UInt64(this ulong? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static ulong? Encode_UInt64_To_UInt64(this ulong? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double? Decode_Double_From_Double(this double? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double? Encode_Double_To_Double(this double? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DateTime? Decode_DateTime_From_DateTime(this DateTime? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DateTime? Encode_DateTime_To_DateTime(this DateTime? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static TimeSpan? Decode_TimeSpan_From_TimeSpan(this TimeSpan? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static TimeSpan? Encode_TimeSpan_To_TimeSpan(this TimeSpan? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DateTimeOffset? Decode_DateTimeOffset_From_DateTimeOffset(this DateTimeOffset? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DateTimeOffset? Encode_DateTimeOffset_To_DateTimeOffset(this DateTimeOffset? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static decimal? Decode_Decimal_From_Decimal(this decimal? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static decimal? Encode_Decimal_To_Decimal(this decimal? value) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Guid? Decode_Guid_From_Guid(this Guid? value, int notUsed) => value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Guid? Encode_Guid_To_Guid(this Guid? value) => value;
    }

    public static class ConversionHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime Decode_DateTime_From_UInt64(this UInt64 value)
        {
            return value.DecodeToDateTime();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime? Decode_DateTime_From_UInt64(this UInt64? value, int notUsed)
        {
            if (value is null) return null;
            return value.Value.DecodeToDateTime();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt64 Encode_DateTime_To_UInt64(this DateTime value)
        {
            return value.EncodeToInt64();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt64? Encode_DateTime_To_UInt64(this DateTime? value)
        {
            if (value is null) return null;
            return value.Value.EncodeToInt64();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ToExternal<T>(this T value)
        {
            return value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? ToExternal<T>(this T? value) where T : struct
        {
            return value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ToInternal<T>(this T value)
        {
            return value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? ToInternal<T>(this T? value) where T : struct
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPublic ToPublic<TPrivate, TPublic>(this TPrivate value)
            where TPrivate : TPublic
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TPrivate ToPrivate<TPublic, TPrivate>(this TPublic value)
            where TPublic : TPrivate
        {
            return value;
        }
    }
}