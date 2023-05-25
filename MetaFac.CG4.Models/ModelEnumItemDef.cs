using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class ModelEnumItemDef : IEquatable<ModelEnumItemDef>
    {
        public readonly string Name;
        public readonly int Value;

        public ModelEnumItemDef(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public ModelEnumItemDef(JsonEnumItemDef? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Name = source.Name ?? "Unknown_Field";
            Value = source.Value;
        }

        public string ToJson()
        {
            var member = new JsonEnumItemDef(this);
            return JsonSerializer.Serialize(member);
        }

        public static ModelEnumItemDef FromJson(string json)
        {
            var member = JsonSerializer.Deserialize<JsonEnumItemDef>(json);
            return new ModelEnumItemDef(member);
        }

        public bool Equals(ModelEnumItemDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Name, other.Name)
                   && Value == other.Value
                   ;
        }

        public override bool Equals(object? obj)
        {
            return obj is ModelEnumItemDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name?.GetHashCode() ?? 0;
                hashCode = hashCode * 397 ^ Value.GetHashCode();
                return hashCode;
            }
        }
    }
}