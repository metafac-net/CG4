using System;
using System.Collections.Generic;

namespace MetaFac.CG3.ModelReader
{
    internal static class EqualityHelper
    {
        public static bool IsEqualTo<T>(this T self, T other) where T : class, IEquatable<T>
        {
            if (ReferenceEquals(self, other)) return true;
            if (self is null) return false;
            if (other is null) return false;
            return self.Equals(other);
        }

        public static bool IsEqualTo<T>(this IList<T>? self, IList<T>? other) where T : IEquatable<T>
        {
            if (ReferenceEquals(self, other)) return true;
            if (self is null) return false;
            if (other is null) return false;
            if (self.Count != other.Count) return false;
            for (int i = 0; i < self.Count; i++)
            {
                T thisValue = self[i];
                T otherValue = other[i];
                if (!ReferenceEquals(otherValue, thisValue))
                {
                    if (otherValue == null) return false;
                    if (thisValue == null) return false;
                    if (!otherValue.Equals(thisValue)) return false;
                }
            }
            return true;
        }

        public static bool IsEqualTo<TK, TV>(this IDictionary<TK, TV>? self, IDictionary<TK, TV>? other) where TV : IEquatable<TV>
        {
            if (ReferenceEquals(self, other)) return true;
            if (self is null) return false;
            if (other is null) return false;
            if (self.Count != other.Count) return false;
            foreach (var kvp in self)
            {
                bool exists = other.TryGetValue(kvp.Key, out TV? otherValue);
                if (!exists) return false;
                TV thisValue = kvp.Value;
                if (!ReferenceEquals(otherValue, thisValue))
                {
                    if (otherValue == null) return false;
                    if (thisValue == null) return false;
                    if (!otherValue.Equals(kvp.Value)) return false;
                }
            }
            return true;
        }
    }
}