using System.Runtime.CompilerServices;

namespace MetaFac.CG3.Runtime.GProto3
{
    public static class SByteHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Decode_SByte_From_Int32(this int input)
        {
            unchecked
            {
                return (sbyte)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte? Decode_SByte_From_Int32(this int? input, int notUsed)
        {
            unchecked
            {
                return input is null ? null : (sbyte)input.Value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Encode_SByte_To_Int32(this sbyte input)
        {
            return input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int? Encode_SByte_To_Int32(this sbyte? input)
        {
            if (input is null) return null;
            return input.Value;
        }

    }
}
