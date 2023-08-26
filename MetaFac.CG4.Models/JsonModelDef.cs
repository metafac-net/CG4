using System;
using System.Collections.Generic;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class JsonModelDef : IEquatable<JsonModelDef>
    {
        public int? Tag { get; set; }
        public string? Name { get; set; }
        public List<JsonEntityDef>? EntityDefs { get; set; }
        public List<JsonEnumTypeDef>? EnumTypeDefs { get; set; }
        public Dictionary<string, string>? Tokens { get; set; }

        public JsonModelDef() { }

        public JsonModelDef(ModelDefinition source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Tag = source.Tag;
            Name = source.Name;
            EntityDefs = source.AllEntityDefs.Select(cd => new JsonEntityDef(cd)).ToList();
            EnumTypeDefs = source.AllEnumTypeDefs.Select(cd => new JsonEnumTypeDef(cd)).ToList();
            Tokens = source.Tokens.Count > 0 ? new Dictionary<string, string>(source.Tokens) : null;
        }

        public bool Equals(JsonModelDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return Tag == other.Tag
                   && string.Equals(Name, other.Name)
                   && EntityDefs.IsEqualTo(other.EntityDefs)
                   && EnumTypeDefs.IsEqualTo(other.EnumTypeDefs)
                   && Tokens.IsEqualTo(other.Tokens)
                   ;
        }

        public override bool Equals(object? obj)
        {
            return obj is JsonModelDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Tag?.GetHashCode() ?? 0;
                hashCode = hashCode * 397 ^ (Name?.GetHashCode() ?? 0);
                // order ignored
                if (Tokens is not null)
                {
                    hashCode = hashCode * 397 ^ Tokens.Count;
                    foreach (var kvp in Tokens)
                    {
                        hashCode = hashCode ^ kvp.Key.GetHashCode();
                        if (kvp.Value != null) hashCode = hashCode ^ kvp.Value.GetHashCode();
                    }
                }
                // ordered
                if (EntityDefs != null)
                {
                    hashCode = hashCode * 397 ^ EntityDefs.Count;
                    foreach (var cd in EntityDefs)
                    {
                        hashCode = hashCode * 397 ^ cd.GetHashCode();
                    }
                }
                if (EnumTypeDefs != null)
                {
                    hashCode = hashCode * 397 ^ EnumTypeDefs.Count;
                    foreach (var cd in EnumTypeDefs)
                    {
                        hashCode = hashCode * 397 ^ cd.GetHashCode();
                    }
                }
                return hashCode;
            }
        }
    }
}