using System.Collections.Generic;
using System;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class JsonEnumTypeDef : IEquatable<JsonEnumTypeDef>
    {
        public string? Name { get; set; }
        public string? Summary { get; set; }
        public JsonItemState? State { get; set; }
        public List<JsonEnumItemDef>? EnumItemDefs { get; set; }

        public JsonEnumTypeDef() { }

        public JsonEnumTypeDef(ModelEnumTypeDef source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Name = source.Name;
            Summary = source.Summary;
            State = source.State is null ? null : new JsonItemState(source.State);
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
            return hashCode.ToHashCode();
        }
    }
}
