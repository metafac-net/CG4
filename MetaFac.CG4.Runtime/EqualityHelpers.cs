using MetaFac.Memory;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace MetaFac.CG4.Runtime
{
    public static class EqualityHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo<T>(this ImmutableArray<T> self, ImmutableArray<T> other) where T : IEquatable<T>
        {
            if (self.IsDefault && other.IsDefault) return true;
            if (other.IsDefault) return false;
            if (self.IsDefault) return false;
            if (other.Length != self.Length) return false;
            for (int i = 0; i < self.Length; i++)
            {
                if (!other[i].IsEqualTo(self[i])) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo<T>(this ImmutableArray<T?> self, ImmutableArray<T?> other) where T : struct, IEquatable<T>
        {
            if (self.IsDefault && other.IsDefault) return true;
            if (other.IsDefault) return false;
            if (self.IsDefault) return false;
            if (other.Length != self.Length) return false;
            for (int i = 0; i < self.Length; i++)
            {
                if (!other[i].IsEqualTo(self[i])) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo<T>(this T self, T other) where T : IEquatable<T>
        {
            if (ReferenceEquals(other, self)) return true;
            if (other == null) return false;
            if (self == null) return false;
            return self.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo<T>(this T? self, T? other) where T : struct, IEquatable<T>
        {
            return self.HasValue
                ? other.HasValue ? self.Value.Equals(other.Value) : false
                : !other.HasValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo<T>(this IList<T> self, IList<T> other) where T : IEquatable<T>
        {
            if (ReferenceEquals(other, self)) return true;
            if (other is null) return false;
            if (self is null) return false;
            if (other.Count != self.Count) return false;
            for (int i = 0; i < self.Count; i++)
            {
                if (!other[i].IsEqualTo(self[i])) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo<T>(this IList<T?> self, IList<T?> other) where T : struct, IEquatable<T>
        {
            if (ReferenceEquals(other, self)) return true;
            if (other is null) return false;
            if (self is null) return false;
            if (other.Count != self.Count) return false;
            for (int i = 0; i < self.Count; i++)
            {
                if (!other[i].IsEqualTo(self[i])) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo(this byte[] self, byte[] other)
        {
            if (ReferenceEquals(other, self)) return true;
            if (other is null) return false;
            if (self is null) return false;
            if (other.Length != self.Length) return false;
            for (int i = 0; i < self.Length; i++)
            {
                if (other[i] != self[i]) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo(this byte[][] self, byte[][] other)
        {
            if (ReferenceEquals(other, self)) return true;
            if (other is null) return false;
            if (self is null) return false;
            if (other.Length != self.Length) return false;
            for (int i = 0; i < self.Length; i++)
            {
                if (!other[i].IsEqualTo(self[i])) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo<TKey>(this IDictionary<TKey, byte[]> self, IDictionary<TKey, byte[]> other)
            where TKey : IEquatable<TKey>
        {
            if (ReferenceEquals(other, self)) return true;
            if (other is null) return false;
            if (self is null) return false;
            if (other.Count != self.Count) return false;
            foreach (var kvp in self)
            {
                if (!other.TryGetValue(kvp.Key, out var otherValue))
                    return false;
                if (!kvp.Value.IsEqualTo(otherValue)) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo<TKey, TValue>(this IDictionary<TKey, TValue> self, IDictionary<TKey, TValue> other)
            where TKey : IEquatable<TKey>
            where TValue : IEquatable<TValue>
        {
            if (ReferenceEquals(other, self)) return true;
            if (other is null) return false;
            if (self is null) return false;
            if (other.Count != self.Count) return false;
            foreach (var kvp in self)
            {
                if (!other.TryGetValue(kvp.Key, out var otherValue))
                    return false;
                if (!kvp.Value.IsEqualTo(otherValue)) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo<TKey, TValue>(this IDictionary<TKey, TValue?> self, IDictionary<TKey, TValue?> other)
            where TKey : IEquatable<TKey>
            where TValue : struct, IEquatable<TValue>
        {
            if (ReferenceEquals(other, self)) return true;
            if (other is null) return false;
            if (self is null) return false;
            if (other.Count != self.Count) return false;
            foreach (var kvp in self)
            {
                if (!other.TryGetValue(kvp.Key, out var otherValue))
                    return false;
                if (!kvp.Value.IsEqualTo(otherValue)) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo(this Octets self, Octets other)
        {
            if (ReferenceEquals(other, self)) return true;
            if (other is null) return false;
            if (self is null) return false;
            return other.Equals(self);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo(this IList<Octets> self, IList<Octets> other)
        {
            if (ReferenceEquals(other, self)) return true;
            if (other is null) return false;
            if (self is null) return false;
            if (other.Count != self.Count) return false;
            for (int i = 0; i < self.Count; i++)
            {
                if (!other[i].IsEqualTo(self[i])) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo<TKey>(this IDictionary<TKey, Octets> self, IDictionary<TKey, Octets> other)
            where TKey : IEquatable<TKey>
        {
            if (ReferenceEquals(other, self)) return true;
            if (other is null) return false;
            if (self is null) return false;
            if (other.Count != self.Count) return false;
            foreach (var kvp in self)
            {
                if (!other.TryGetValue(kvp.Key, out var otherValue))
                    return false;
                if (!kvp.Value.IsEqualTo(otherValue)) return false;
            }
            return true;
        }

    }
}