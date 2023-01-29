using System;

namespace MetaFac.CG3.ModelReader
{
    public class JsonProxyDef : IEquatable<JsonProxyDef>
    {
        public bool HasNames { get; set; }
        public string? ExternalName { get; set; }
        public string? ConcreteName { get; set; }

        public JsonProxyDef() { }

        public JsonProxyDef(ModelProxyDef source)
        {
            HasNames = source.HasNames;
            ExternalName = source.ExternalName;
            ConcreteName = source.ConcreteName;
        }

        public bool Equals(JsonProxyDef? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return HasNames == other.HasNames
                   && string.Equals(ExternalName, other.ExternalName)
                   && string.Equals(ConcreteName, other.ConcreteName);
        }

        public override bool Equals(object? obj)
        {
            return obj is JsonProxyDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = HasNames.GetHashCode();
                hashCode = hashCode * 397 ^ (ExternalName?.GetHashCode() ?? 0);
                hashCode = hashCode * 397 ^ (ConcreteName?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
    }
}
