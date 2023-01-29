using MetaFac.Memory;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace MetaCode.Runtime
{
    public static class HashCodeHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetUnaryHashCode<T>(this T value)
        {
            unchecked
            {
                if (value == null) return 0;
                return value.GetHashCode();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetUnaryHashCode<T>(this T? value) where T : struct
        {
            unchecked
            {
                if (!value.HasValue) return 0;
                return value.Value.GetHashCode();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetArrayHashCode<T>(this T[] array)
        {
            unchecked
            {
                if (array is null) return 0;
                int hash = array.Length;
                foreach (var element in array)
                {
                    hash = (hash * 397) ^ element.GetUnaryHashCode();
                }
                return hash;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetArrayHashCode<T>(this T?[] array) where T : struct
        {
            unchecked
            {
                if (array is null) return 0;
                int hash = array.Length;
                foreach (var element in array)
                {
                    hash = (hash * 397) ^ element.GetUnaryHashCode();
                }
                return hash;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetArrayHashCode<T>(this ImmutableArray<T> array)
        {
            unchecked
            {
                if (array.IsDefault) return 0;
                int hash = array.Length;
                foreach (var element in array)
                {
                    hash = (hash * 397) ^ element.GetUnaryHashCode();
                }
                return hash;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetArrayHashCode<T>(this ImmutableArray<T?> array) where T : struct
        {
            unchecked
            {
                if (array.IsDefault) return 0;
                int hash = array.Length;
                foreach (var element in array)
                {
                    hash = (hash * 397) ^ element.GetUnaryHashCode();
                }
                return hash;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetArrayHashCode<T>(this IList<T> list)
        {
            unchecked
            {
                if (list is null) return 0;
                int hash = list.Count;
                foreach (var element in list)
                {
                    hash = (hash * 397) ^ element.GetUnaryHashCode();
                }
                return hash;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetArrayHashCode<T>(this IList<T?> list) where T : struct
        {
            unchecked
            {
                if (list is null) return 0;
                int hash = list.Count;
                foreach (var element in list)
                {
                    hash = (hash * 397) ^ element.GetUnaryHashCode();
                }
                return hash;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetIndexHashCode<TKey, T>(this IDictionary<TKey, T> dict)
        {
            unchecked
            {
                if (dict is null) return 0;
                int hash = dict.Count;
                foreach (var kvp in dict)
                {
                    // note: unordered
                    hash = (hash) ^ (kvp.Key.GetUnaryHashCode()) ^ (kvp.Value.GetUnaryHashCode());
                }
                return hash;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetIndexHashCode<TKey, T>(this IDictionary<TKey, T?> dict) where T : struct
        {
            unchecked
            {
                if (dict is null) return 0;
                int hash = dict.Count;
                foreach (var kvp in dict)
                {
                    // note: unordered
                    hash = (hash) ^ (kvp.Key.GetUnaryHashCode()) ^ (kvp.Value.GetUnaryHashCode());
                }
                return hash;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetUnaryHashCode(this byte[] buffer)
        {
            unchecked
            {
                if (buffer is null) return 0;
                int hash = buffer.Length;
                for (int i = 0; i < buffer.Length; i++)
                {
                    hash = (hash * 397) ^ buffer[i];
                }
                return hash;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetArrayHashCode(this byte[][] buffers)
        {
            unchecked
            {
                if (buffers is null) return 0;
                int hash = buffers.Length;
                foreach (var buffer in buffers)
                {
                    hash = (hash * 397) ^ buffer.GetUnaryHashCode();
                }
                return hash;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetIndexHashCode<TKey>(this IDictionary<TKey, byte[]> dict)
        {
            unchecked
            {
                if (dict is null) return 0;
                int hash = dict.Count;
                foreach (var kvp in dict)
                {
                    // note: unordered
                    hash = (hash) ^ (kvp.Key.GetUnaryHashCode()) ^ (kvp.Value.GetUnaryHashCode());
                }
                return hash;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetUnaryHashCode(this Octets buffer)
        {
            return buffer?.GetHashCode() ?? 0;
        }

    }
}