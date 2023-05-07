using System;

namespace MetaFac.CG4.Runtime.JsonPoco.Tests
{
    internal class TestPoco : IEquatable<TestPoco>
    {
        public string? Field1 { get; set; }
        public TimeSpanData Field2 { get; set; }

        public bool Equals(TestPoco? other)
        {
            if (ReferenceEquals(other, this)) return true;
            if (other is null) return false;
            return string.Equals(Field1, other.Field1)
                && Field2.Equals(other.Field2);
        }

        public override bool Equals(object? obj)
        {
            return obj is TestPoco other && Equals(other);
        }

        public override int GetHashCode()
        {
            int hash = Field1?.GetHashCode() ?? 0;
            hash = hash * 397 ^ Field2.GetHashCode();
            return hash;
        }
    }
}