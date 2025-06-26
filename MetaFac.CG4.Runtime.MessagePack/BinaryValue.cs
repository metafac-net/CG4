using MessagePack;
using DataFac.Memory;
using System;

namespace MetaFac.CG4.Runtime.MessagePack
{
    [MessagePackObject]
    public sealed class BinaryValue : IEquatable<BinaryValue>
    {
        [Key(0)]
        public readonly ReadOnlyMemory<byte> Value;

        public BinaryValue(ReadOnlyMemory<byte> value) => Value = value;

        public bool Equals(BinaryValue? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            return other.Value.Span.SequenceEqual(Value.Span);
        }

        public override int GetHashCode()
        {
            ReadOnlySpan<byte> span = Value.Span;
            int length = span.Length;
            int hash = length;
            unchecked
            {
                for (int i = 0; i < length; i++)
                {
                    hash = (hash * 397) ^ span[i];
                }
            }
            return hash;
        }

        public override bool Equals(object? obj) => obj is BinaryValue other && Equals(other);
        public static bool operator ==(BinaryValue? left, BinaryValue? right) => left is null ? right is null : left.Equals(right);
        public static bool operator !=(BinaryValue? left, BinaryValue? right) => !(left == right);
        public static implicit operator BinaryValue?(Octets? octets) => octets is null ? null : new BinaryValue(octets.AsMemory());
        public static implicit operator Octets?(BinaryValue? binary) => binary is null ? null : Octets.UnsafeWrap(binary.Value);
    }
}