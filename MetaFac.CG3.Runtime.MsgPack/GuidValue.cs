using MessagePack;
using System;
using System.Runtime.CompilerServices;

namespace MetaCode.Runtime.MsgPack
{
    [MessagePackObject]
    public struct GuidValue : IEquatable<GuidValue>
    {
        [Key(0)]
        public readonly ulong Bits0;

        [Key(1)]
        public readonly ulong Bits1;

        public GuidValue(ulong bits0, ulong bits1)
        {
            Bits0 = bits0;
            Bits1 = bits1;
        }

        public GuidValue(Guid value)
        {
            byte[] bytes = value.ToByteArray();
            unchecked
            {
                Bits0 =
                    bytes[0]
                    | (ulong)bytes[1] << 8
                    | (ulong)bytes[2] << 16
                    | (ulong)bytes[3] << 24
                    | (ulong)bytes[4] << 32
                    | (ulong)bytes[5] << 40
                    | (ulong)bytes[6] << 48
                    | (ulong)bytes[7] << 56
                    ;
                Bits1 =
                    bytes[8 + 0]
                    | (ulong)bytes[8 + 1] << 8
                    | (ulong)bytes[8 + 2] << 16
                    | (ulong)bytes[8 + 3] << 24
                    | (ulong)bytes[8 + 4] << 32
                    | (ulong)bytes[8 + 5] << 40
                    | (ulong)bytes[8 + 6] << 48
                    | (ulong)bytes[8 + 7] << 56
                    ;
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Bits0.GetHashCode() ^ Bits1.GetHashCode();
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is GuidValue other && Equals(other);
        }

        public bool Equals(GuidValue other)
        {
            return other.Bits0 == Bits0
                && other.Bits1 == Bits1
                ;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator GuidValue(Guid value)
        {

            return new GuidValue(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Guid(GuidValue value)
        {
            ulong lo = value.Bits0;
            ulong hi = value.Bits1;
            byte[] bytes;
            unchecked
            {
                byte b00 = (byte)(lo & 0xFF);
                byte b01 = (byte)((lo >> 8) & 0xFF);
                byte b02 = (byte)((lo >> 16) & 0xFF);
                byte b03 = (byte)((lo >> 24) & 0xFF);
                byte b04 = (byte)((lo >> 32) & 0xFF);
                byte b05 = (byte)((lo >> 40) & 0xFF);
                byte b06 = (byte)((lo >> 48) & 0xFF);
                byte b07 = (byte)((lo >> 56) & 0xFF);
                byte b08 = (byte)(hi & 0xFF);
                byte b09 = (byte)((hi >> 8) & 0xFF);
                byte b10 = (byte)((hi >> 16) & 0xFF);
                byte b11 = (byte)((hi >> 24) & 0xFF);
                byte b12 = (byte)((hi >> 32) & 0xFF);
                byte b13 = (byte)((hi >> 40) & 0xFF);
                byte b14 = (byte)((hi >> 48) & 0xFF);
                byte b15 = (byte)((hi >> 56) & 0xFF);
                bytes = new byte[] { b00, b01, b02, b03, b04, b05, b06, b07, b08, b09, b10, b11, b12, b13, b14, b15, };
            }
            return new Guid(bytes);
        }
    }
}