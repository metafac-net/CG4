using System;

namespace MetaFac.CG4.Runtime.JsonSystemText
{
    public struct HalfValue
    {
        public short Value { get; set; }
        public HalfValue() { }
        public HalfValue(short value) => Value = value;
        public override int GetHashCode() => HashCode.Combine(Value);
        public override bool Equals(object? obj) => obj is HalfValue other && Equals(other);
        public bool Equals(HalfValue other) => other.Value.Equals(Value);
        public static bool operator ==(HalfValue left, HalfValue right) => left.Equals(right);
        public static bool operator !=(HalfValue left, HalfValue right) => !left.Equals(right);

        public static implicit operator HalfValue(Half value) => new HalfValue(BitConverter.HalfToInt16Bits(value));
        public static implicit operator Half(HalfValue value) => BitConverter.Int16BitsToHalf(value.Value);
    }

}