using System.Numerics;
using System;

namespace MetaFac.CG4.Runtime.JsonSystemText
{
    public struct BigIntValue
    {
        public string? Text { get; set; }
        public BigIntValue() { }
        public BigIntValue(string? text) => Text = text;
        public override int GetHashCode() => HashCode.Combine(Text);
        public override bool Equals(object? obj) => obj is BigIntValue other && Equals(other);
        public bool Equals(BigIntValue other) => string.Equals(Text, other.Text);
        public static bool operator ==(BigIntValue left, BigIntValue right) => left.Equals(right);
        public static bool operator !=(BigIntValue left, BigIntValue right) => !left.Equals(right);

        public static implicit operator BigIntValue(BigInteger value) => new BigIntValue(value.ToString());
        public static implicit operator BigInteger(BigIntValue value) => value.Text is null ? default : BigInteger.Parse(value.Text);
    }

}