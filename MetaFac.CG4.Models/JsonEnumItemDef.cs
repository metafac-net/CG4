using System.Collections.Generic;
using System;

namespace MetaFac.CG4.Models
{
    public class JsonEnumItemDef : IEquatable<JsonEnumItemDef>
    {
        public string? Name { get; set; }
        public int Value { get; set; }

        public JsonEnumItemDef() { }

        public JsonEnumItemDef(ModelEnumItemDef source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Name = source.Name;
            Value = source.Value;
        }

        public bool Equals(JsonEnumItemDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Name, other.Name)
                   && Value == other.Value
                   ;
        }

        public override bool Equals(object? obj)
        {
            return obj is JsonEnumItemDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Name?.GetHashCode() ?? 0;
                hashCode = hashCode * 397 ^ Value.GetHashCode();
                return hashCode;
            }
        }
    }
}