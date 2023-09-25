using System;
using System.Collections.Generic;
using System.Text;

namespace T_Namespace_.JsonNewtonSoft
{
    public struct SampleInternal : IEquatable<SampleInternal>
    {
        public long Value { get; set; }

        public SampleInternal() { }
        public SampleInternal(long value) => Value = value;
        public override int GetHashCode() => HashCode.Combine(Value);
        public override bool Equals(object? obj) => obj is SampleInternal other && Equals(other);
        public bool Equals(SampleInternal other) => other.Value.Equals(Value);
        public static bool operator ==(SampleInternal left, SampleInternal right) => left.Equals(right);
        public static bool operator !=(SampleInternal left, SampleInternal right) => !left.Equals(right);
        public static implicit operator SampleInternal(long value) => new(value);
        public static implicit operator long(SampleInternal value) => value.Value;
    }
}