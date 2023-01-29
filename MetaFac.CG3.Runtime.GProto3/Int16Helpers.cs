using System.Runtime.CompilerServices;

namespace MetaCode.Runtime.GProto3
{
    public static class Int16Helpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Decode_Int16_From_Int32(this int input)
        {
            unchecked
            {
                return (short)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short? Decode_Int16_From_Int32(this int? input, int notUsed)
        {
            unchecked
            {
                return input is null ? null : (short?)(short)input.Value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Encode_Int16_To_Int32(this short input)
        {
            return input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int? Encode_Int16_To_Int32(this short? input)
        {
            if (input is null) return null;
            return input.Value;
        }

    }
}
