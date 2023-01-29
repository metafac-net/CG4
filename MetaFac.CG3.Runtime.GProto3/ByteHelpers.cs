using System.Runtime.CompilerServices;

namespace MetaFac.CG3.Runtime.GProto3
{
    public static class ByteHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Decode_Byte_From_UInt32(this uint input)
        {
            unchecked
            {
                return (byte)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte? Decode_Byte_From_UInt32(this uint? input, int notUsed)
        {
            unchecked
            {
                return input is null ? null : (byte)input.Value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Encode_Byte_To_UInt32(this byte input)
        {
            return input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint? Encode_Byte_To_UInt32(this byte? input)
        {
            if (input is null) return null;
            return input.Value;
        }

    }
}
