using System.Runtime.CompilerServices;

namespace MetaCode.Runtime.GProto3
{
    public static class CharHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char Decode_Char_From_UInt32(this uint input)
        {
            unchecked
            {
                return (char)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static char? Decode_Char_From_UInt32(this uint? input, int notUsed)
        {
            unchecked
            {
                return input is null ? null : (char?)(char)input.Value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Encode_Char_To_UInt32(this char input)
        {
            return input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint? Encode_Char_To_UInt32(this char? input)
        {
            if (input is null) return null;
            return input.Value;
        }

    }
}
