using MessagePack;
using System;

namespace MetaFac.CG3.Runtime.MessagePack
{
    [MessagePackObject]
    public struct DecimalValue : IEquatable<DecimalValue>
    {
        [Key(0)]
        public readonly int Bits0;

        [Key(1)]
        public readonly int Bits1;

        [Key(2)]
        public readonly int Bits2;

        [Key(3)]
        public readonly int Bits3;

        public DecimalValue(int bits0, int bits1, int bits2, int bits3)
        {
            Bits0 = bits0;
            Bits1 = bits1;
            Bits2 = bits2;
            Bits3 = bits3;
        }

        public DecimalValue(decimal value)
        {
            int[] bits = decimal.GetBits(value);
            Bits0 = bits[0];
            Bits1 = bits[1];
            Bits2 = bits[2];
            Bits3 = bits[3];
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Bits0 ^ Bits1 ^ Bits2 ^ Bits3;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is DecimalValue other && Equals(other);
        }

        public bool Equals(DecimalValue other)
        {
            return other.Bits0 == Bits0
                && other.Bits1 == Bits1
                && other.Bits2 == Bits2
                && other.Bits3 == Bits3
                ;
        }

        public static implicit operator DecimalValue(decimal value)
        {
            return new DecimalValue(value);
        }

        public static implicit operator decimal(DecimalValue value)
        {
            return new decimal(new int[] { value.Bits0, value.Bits1, value.Bits2, value.Bits3 });
        }
    }
}