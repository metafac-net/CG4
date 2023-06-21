using System;

namespace MetaFac.CG4.Models
{
    public class ModelProxyDef : IEquatable<ModelProxyDef>
    {
        public readonly string ExternalName;
        public readonly string ConcreteName;

        public ModelProxyDef(string externalName, string concreteName)
        {
            ExternalName = externalName;
            ConcreteName = concreteName;
        }

        public static ModelProxyDef? From(JsonProxyDef? source)
        {
            if (source is null) return null;
            return new ModelProxyDef(
                source.ExternalName ?? throw new ArgumentNullException(nameof(source.ExternalName)),
                source.ConcreteName ?? throw new ArgumentNullException(nameof(source.ConcreteName)));
        }

        public bool Equals(ModelProxyDef? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(ExternalName, other.ExternalName)
                   && string.Equals(ConcreteName, other.ConcreteName);
        }

        public override bool Equals(object? obj)
        {
            return obj is ModelProxyDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ExternalName, ConcreteName);
        }
    }
}