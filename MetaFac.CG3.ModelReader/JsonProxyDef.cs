using System;

namespace MetaFac.CG3.ModelReader
{
    public class JsonProxyDef : IEquatable<JsonProxyDef>
    {
        public string? ExternalName { get; set; }
        public string? ConcreteName { get; set; }

        public JsonProxyDef() { }

        public JsonProxyDef(ModelProxyDef source)
        {
            ExternalName = source.ExternalName;
            ConcreteName = source.ConcreteName;
        }

        public bool Equals(JsonProxyDef? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(ExternalName, other.ExternalName)
                   && string.Equals(ConcreteName, other.ConcreteName);
        }

        public override bool Equals(object? obj)
        {
            return obj is JsonProxyDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ExternalName, ConcreteName);
        }
    }
}
