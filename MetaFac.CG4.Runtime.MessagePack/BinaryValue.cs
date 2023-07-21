using MessagePack;
using MetaFac.Memory;
using System;

namespace MetaFac.CG4.Runtime.MessagePack
{
    //
    // todo move these helper types into template
    //
    [MessagePackObject]
    public sealed class BinaryValue : IEquatable<BinaryValue>
    {
        [Key(0)]
        public readonly ReadOnlyMemory<byte> Value;

        private readonly Lazy<int> _hashCodeFunc;

        public BinaryValue(ReadOnlyMemory<byte> value)
        {
            Value = value;
            _hashCodeFunc = new Lazy<int>(new Func<int>(CalcHashCode));
        }

        private int CalcHashCode()
        {
            ReadOnlySpan<byte> span = Value.Span;
            int length = span.Length;
            int num = length;
            for (int i = 0; i < length; i++)
            {
                num = (num * 397) ^ span[i];
            }

            return num;
        }

        public override int GetHashCode()
        {
            return _hashCodeFunc.Value;
        }

        public override bool Equals(object? obj)
        {
            return obj is BinaryValue other && Equals(other);
        }

        public bool Equals(BinaryValue? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;

            var thisSpan = Value.Span;
            var thatSpan = other.Value.Span;
            if (thatSpan.Length != thisSpan.Length) return false;
            if (other!.GetHashCode() != GetHashCode()) return false;
            return thatSpan.SequenceEqual(thisSpan);
        }

        public static bool operator ==(BinaryValue? left, BinaryValue? right)
        {
            return left is null ? right is null : left.Equals(right);
        }

        public static bool operator !=(BinaryValue? left, BinaryValue? right) => !(left == right);

        public static implicit operator BinaryValue?(Octets? octets)
        {
            if (octets is null) return null;
            return new BinaryValue(octets.Memory);
        }

        public static implicit operator Octets?(BinaryValue? binary)
        {
            if (binary is null) return null;
            return Octets.UnsafeWrap(binary.Value);
        }
    }
}