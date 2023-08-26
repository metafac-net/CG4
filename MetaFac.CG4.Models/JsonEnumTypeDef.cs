using System;
using System.Collections.Generic;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class JsonEnumTypeDef : IEquatable<JsonEnumTypeDef>
    {
        public string? Name { get; set; }
        public string? Summary { get; set; }
        public JsonItemState? State { get; set; }
        public Dictionary<string, string>? Tokens { get; set; }
        public List<JsonEnumItemDef>? EnumItemDefs { get; set; }

        public JsonEnumTypeDef() { }

        public JsonEnumTypeDef(ModelEnumTypeDef source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Name = source.Name;
            Summary = source.Summary;
            State = JsonItemState.From(source.State);
            Tokens = source.Tokens.Count > 0 ? new Dictionary<string, string>(source.Tokens) : null;
            EnumItemDefs = source.EnumItemDefs.Select(fd => new JsonEnumItemDef(fd)).ToList();
        }

        public bool Equals(JsonEnumTypeDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Name, other.Name)
                   && string.Equals(Summary, other.Summary)
                   && Equals(State, other.State)
                   && EnumItemDefs.IsEqualTo(other.EnumItemDefs)
                   && Tokens.IsEqualTo(other.Tokens)
                   ;
        }

        public override bool Equals(object? obj)
        {
            return obj is JsonEnumTypeDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Summary);
            hashCode.Add(State);
            if (EnumItemDefs is not null)
            {
                hashCode.Add(EnumItemDefs.Count);
                foreach (var fd in EnumItemDefs)
                {
                    hashCode.Add(fd);
                }
            }
            if (Tokens is not null)
            {
                hashCode.Add(Tokens.Count);
                foreach (var kvp in Tokens)
                {
                    hashCode.Add(kvp.Key);
                    hashCode.Add(kvp.Value);
                }
            }
            return hashCode.ToHashCode();
        }
    }
}
