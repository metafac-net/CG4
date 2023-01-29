using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MetaCode.Runtime.ProtobufNet3
{
    public static class EqualityHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo(this DateTimeOffsetData self, DateTimeOffsetData other)
        {
            return other.Equals(self);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo(this DateTimeOffsetData? self, DateTimeOffsetData? other)
        {
            return self.HasValue
                ? other.HasValue
                    ? other.Value.Equals(self.Value)
                    : false
                : !other.HasValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualTo(this IList<DateTimeOffsetData> self, IList<DateTimeOffsetData> other)
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
        public static bool IsEqualTo<TKey>(this IDictionary<TKey, DateTimeOffsetData> self, IDictionary<TKey, DateTimeOffsetData> other)
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