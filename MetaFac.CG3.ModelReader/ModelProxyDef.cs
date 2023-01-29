using System;

namespace MetaCode.Models
{
    public class ModelProxyDef : IEquatable<ModelProxyDef>
    {
        public readonly bool HasNames;
        public readonly string? ExternalName;
        public readonly string? ConcreteName;

        public ModelProxyDef(bool hasNames, string? externalName, string? concreteName)
        {
            HasNames = hasNames;
            ExternalName = externalName;
            ConcreteName = concreteName;
        }

        public ModelProxyDef(JsonProxyDef source)
        {
            HasNames = source.HasNames;
            ExternalName = source.ExternalName;
            ConcreteName = source.ConcreteName;
        }

        public bool Equals(ModelProxyDef? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return HasNames == other.HasNames
                   && string.Equals(ExternalName, other.ExternalName)
                   && string.Equals(ConcreteName, other.ConcreteName);
        }

        public override bool Equals(object? obj)
        {
            return obj is ModelProxyDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = HasNames.GetHashCode();
                hashCode = (hashCode * 397) ^ (ExternalName?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (ConcreteName?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
    }
}