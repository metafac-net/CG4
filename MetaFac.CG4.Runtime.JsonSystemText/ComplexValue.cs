using System.Numerics;
using System;

namespace MetaFac.CG4.Runtime.JsonSystemText
{
    public struct ComplexValue
    {
        public long RealBits { get; set; }
        public long ImagBits { get; set; }
        public ComplexValue() { }
        public ComplexValue(long realBits, long imagBits)
        {
            RealBits = realBits;
            ImagBits = imagBits;
        }
        public override int GetHashCode() => HashCode.Combine(RealBits, ImagBits);
        public override bool Equals(object? obj) => obj is ComplexValue other && Equals(other);
        public bool Equals(ComplexValue other) => other.RealBits.Equals(this.RealBits) && other.ImagBits.Equals(this.ImagBits);
        public static bool operator ==(ComplexValue left, ComplexValue right) => left.Equals(right);
        public static bool operator !=(ComplexValue left, ComplexValue right) => !left.Equals(right);

        public static implicit operator ComplexValue(Complex value) => new ComplexValue(BitConverter.DoubleToInt64Bits(value.Real), BitConverter.DoubleToInt64Bits(value.Imaginary));
        public static implicit operator Complex(ComplexValue value) => new Complex(BitConverter.Int64BitsToDouble(value.RealBits), BitConverter.Int64BitsToDouble(value.ImagBits));
    }

}