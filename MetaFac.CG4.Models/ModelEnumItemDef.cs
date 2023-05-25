using System;
using System.Text.Json;

namespace MetaFac.CG4.Models
{
    public class ModelEnumItemDef : IEquatable<ModelEnumItemDef>
    {
        public readonly string Name;
        public readonly int Value;
        public readonly string? Summary;
        public readonly string? ObsoleteMessage;

        public ModelEnumItemDef(string name, int value, string? summary, string? obsoleteMessage)
        {
            Name = name;
            Value = value;
            Summary = summary;
            ObsoleteMessage = obsoleteMessage;
        }

        public ModelEnumItemDef(JsonEnumItemDef? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Name = source.Name ?? throw new ArgumentNullException(nameof(source.Name));
            Value = source.Value;
            Summary = source.Summary;
            ObsoleteMessage = source.ObsoleteMessage;
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
                   && string.Equals(Summary, other.Summary)
                   && string.Equals(ObsoleteMessage, other.ObsoleteMessage)
                   ;
        }

        public override bool Equals(object? obj)
        {
            return obj is ModelEnumItemDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Value, Summary, ObsoleteMessage);
        }
    }
}