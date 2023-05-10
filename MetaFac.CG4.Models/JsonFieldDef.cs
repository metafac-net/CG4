using System.Collections.Generic;
using System;

namespace MetaFac.CG4.Models
{
    public class JsonFieldDef : IEquatable<JsonFieldDef>
    {
        public int? Tag { get; set; }
        public string? Name { get; set; }
        public string? InnerType { get; set; }
        public bool Nullable { get; set; }
        public JsonProxyDef? ProxyDef { get; set; }
        public int ArrayRank { get; set; }
        public string? IndexType { get; set; }
        public bool IsModelType { get; set; }

        public JsonFieldDef() { }

        public JsonFieldDef(ModelFieldDef source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Tag = source.Tag;
            Name = source.Name;
            InnerType = source.InnerType;
            Nullable = source.Nullable;
            ProxyDef = source.ProxyDef is null ? null : new JsonProxyDef(source.ProxyDef);
            ArrayRank = source.ArrayRank;
            IsModelType = source.IsModelType;
            IndexType = source.IndexType;
        }

        public bool Equals(JsonFieldDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return Tag == other.Tag
                   && string.Equals(Name, other.Name)
                   && string.Equals(InnerType, other.InnerType)
                   && Nullable == other.Nullable
                   && Equals(ProxyDef, other.ProxyDef)
                   && ArrayRank == other.ArrayRank
                   && IsModelType == other.IsModelType
                   && string.Equals(IndexType, other.IndexType);
        }

        public override bool Equals(object? obj)
        {
            return obj is JsonFieldDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Tag?.GetHashCode() ?? 0;
                hashCode = hashCode * 397 ^ (Name?.GetHashCode() ?? 0);
                hashCode = hashCode * 397 ^ (InnerType?.GetHashCode() ?? 0);
                hashCode = hashCode * 397 ^ Nullable.GetHashCode();
                hashCode = hashCode * 397 ^ (ProxyDef?.GetHashCode() ?? 0);
                hashCode = hashCode * 397 ^ ArrayRank.GetHashCode();
                hashCode = hashCode * 397 ^ (IndexType?.GetHashCode() ?? 0);
                hashCode = hashCode * 397 ^ IsModelType.GetHashCode();
                return hashCode;
            }
        }
    }
}