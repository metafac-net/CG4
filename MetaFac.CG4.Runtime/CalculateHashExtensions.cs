using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MetaFac.CG4.Runtime
{
    public static class CalculateHashExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CalcHashUnary<T>(this T? self)
        {
            if (self is null) return 0;
            return self.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CalcHashUnary<T>(this T? self) where T : struct
        {
            if (self is null) return 0;
            return self.Value.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CalcHashUnary(this byte[]? self)
        {
            if (self is null) return 0;
            unchecked
            {
                int hash = self.Length;
                for (int i = 0; i < self.Length; i++)
                {
                    hash = hash * 397 ^ self[i];
                }
                return hash;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CalcHashUnary(this ReadOnlyMemory<byte> self)
        {
            if (self.IsEmpty) return 0;
            unchecked
            {
                var span = self.Span;
                int hash = span.Length;
                for (int i = 0; i < span.Length; i++)
                {
                    hash = hash * 397 ^ span[i];
                }
                return hash;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CalcHashArray(this byte[]?[]? self)
        {
            if (self is null) return 0;
            HashCode hc = new HashCode();
            hc.Add(self.Length);
            for (int i = 0; i < self.Length; i++)
            {
                hc.Add(self[i].CalcHashUnary());
            }
            return hc.ToHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CalcHashArray<T>(this IReadOnlyList<T?>? self)
        {
            if (self is null) return 0;
            HashCode hc = new HashCode();
            hc.Add(self.Count);
            for (int i = 0; i < self.Count; i++)
            {
                hc.Add(self[i].CalcHashUnary());
            }
            return hc.ToHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CalcHashArray<T>(this IReadOnlyList<T?>? self) where T : struct
        {
            if (self is null) return 0;
            HashCode hc = new HashCode();
            hc.Add(self.Count);
            for (int i = 0; i < self.Count; i++)
            {
                hc.Add(self[i].CalcHashUnary());
            }
            return hc.ToHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CalcHashIndex<TKey, T>(this IReadOnlyDictionary<TKey, T?>? self)
        {
            if (self is null) return 0;
            HashCode hc = new HashCode();
            hc.Add(self.Count);
            foreach (var kvp in self)
            {
                hc.Add(kvp.Key);
                hc.Add(kvp.Value.CalcHashUnary());
            }
            return hc.ToHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CalcHashIndex<TKey, T>(this IReadOnlyDictionary<TKey, T?>? self) where T : struct
        {
            if (self is null) return 0;
            HashCode hc = new HashCode();
            hc.Add(self.Count);
            foreach (var kvp in self)
            {
                hc.Add(kvp.Key);
                hc.Add(kvp.Value.CalcHashUnary());
            }
            return hc.ToHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CalcHashIndex<TKey>(this IReadOnlyDictionary<TKey, byte[]?>? self)
        {
            if (self is null) return 0;
            HashCode hc = new HashCode();
            hc.Add(self.Count);
            foreach (var kvp in self)
            {
                hc.Add(kvp.Key);
                hc.Add(kvp.Value.CalcHashUnary());
            }
            return hc.ToHashCode();
        }
    }
}
