using System.Runtime.CompilerServices;

namespace MetaFac.CG3.Runtime.GProto3
{
    public static class UInt16Helpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Decode_UInt16_From_UInt32(this uint input)
        {
            unchecked
            {
                return (ushort)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort? Decode_UInt16_From_UInt32(this uint? input, int notUsed)
        {
            unchecked
            {
                return input is null ? null : (ushort)input.Value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Encode_UInt16_To_UInt32(this ushort input)
        {
            return input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint? Encode_UInt16_To_UInt32(this ushort? input)
        {
            if (input is null) return null;
            return input.Value;
        }

    }
}
