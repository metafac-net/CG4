using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace MetaFac.CG4.Runtime
{
    public static class ValueEqualityExtensions
    {
        // specific types
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ArrayEquals<T>(this ImmutableArray<T?> self, in ImmutableArray<T?> other)
        {
            if (self.IsDefault) return other.IsDefault;
            if (other.IsDefault) return false;
            if (self.Length != other.Length) return false;
            for (int i = 0; i < self.Length; i++)
            {
                if (!self[i].ValueEquals(other[i])) return false;
            }
            return true;
        }

        // generic types
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValueEquals<T>(this T? self, in T? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            return self.Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ArrayEquals<T>(this T?[]? self, in T?[]? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            if (self.Length != other.Length) return false;
            for (int i = 0; i < self.Length; i++)
            {
                if (!self[i].ValueEquals(other[i])) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ByteSpanEquals(this ReadOnlySpan<byte> a, ReadOnlySpan<byte> b)
        {
            return a.SequenceEqual(b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValueEquals(this byte[]? self, in byte[]? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            return ByteSpanEquals(self, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValueEquals(this ReadOnlyMemory<byte> self, in ReadOnlyMemory<byte> other)
        {
            if (self.IsEmpty) return other.IsEmpty;
            if (other.IsEmpty) return false;
            if (self.Length != other.Length) return false;
            var selfSpan = self.Span;
            var otherSpan = other.Span;
            for (int i = 0; i < selfSpan.Length; i++)
            {
                if (selfSpan[i] != otherSpan[i]) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValueEquals(this ImmutableArray<byte> self, in ImmutableArray<byte> other)
        {
            if (self.IsDefault) return other.IsDefault;
            if (other.IsDefault) return false;
            // compare elements
            if (self.Length != other.Length) return false;
            for (int i = 0; i < self.Length; i++)
            {
                if (self[i] != other[i]) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ArrayEquals(this byte[]?[]? self, in byte[]?[]? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            if (self.Length != other.Length) return false;
            for (int i = 0; i < self.Length; i++)
            {
                if (!self[i].ValueEquals(other[i])) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ArrayEquals<T>(this IReadOnlyList<T?>? self, in IReadOnlyList<T?>? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            if (self.Count != other.Count) return false;
            for (int i = 0; i < self.Count; i++)
            {
                if (!self[i].ValueEquals(other[i])) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ArrayEquals(this IReadOnlyList<ReadOnlyMemory<byte>>? self, in IReadOnlyList<ReadOnlyMemory<byte>>? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            if (self.Count != other.Count) return false;
            for (int i = 0; i < self.Count; i++)
            {
                if (!self[i].ValueEquals(other[i])) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ArrayEquals(this IReadOnlyList<ImmutableArray<byte>>? self, in IReadOnlyList<ImmutableArray<byte>>? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            if (self.Count != other.Count) return false;
            for (int i = 0; i < self.Count; i++)
            {
                if (!self[i].ValueEquals(other[i])) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IndexEquals<TKey, T>(this IReadOnlyDictionary<TKey, T?>? self, in IReadOnlyDictionary<TKey, T?>? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            if (self.Count != other.Count) return false;
            foreach (var kvp in self)
            {
                if (!self.TryGetValue(kvp.Key, out var otherValue)) return false;
                if (!kvp.Value.ValueEquals(otherValue)) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IndexEquals<TKey>(this IReadOnlyDictionary<TKey, ReadOnlyMemory<byte>>? self, in IReadOnlyDictionary<TKey, ReadOnlyMemory<byte>>? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            if (self.Count != other.Count) return false;
            foreach (var kvp in self)
            {
                if (!self.TryGetValue(kvp.Key, out var otherValue)) return false;
                if (!kvp.Value.ValueEquals(otherValue)) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IndexEquals<TKey>(this IReadOnlyDictionary<TKey, ImmutableArray<byte>>? self, in IReadOnlyDictionary<TKey, ImmutableArray<byte>>? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            if (self.Count != other.Count) return false;
            foreach (var kvp in self)
            {
                if (!self.TryGetValue(kvp.Key, out var otherValue)) return false;
                if (!kvp.Value.ValueEquals(otherValue)) return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IndexEquals<TKey>(this IReadOnlyDictionary<TKey, byte[]?>? self, in IReadOnlyDictionary<TKey, byte[]?>? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            if (self.Count != other.Count) return false;
            foreach (var kvp in self)
            {
                if (!self.TryGetValue(kvp.Key, out var otherValue)) return false;
                if (!kvp.Value.ValueEquals(otherValue)) return false;
            }
            return true;
        }
    }
}
