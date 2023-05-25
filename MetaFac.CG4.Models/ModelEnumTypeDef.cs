using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.Text.Json;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class ModelEnumTypeDef : IEquatable<ModelEnumTypeDef>
    {
        public readonly string Name;
        public readonly string? Summary;
        public readonly string? ObsoleteMessage;
        public readonly ImmutableList<ModelEnumItemDef> EnumItemDefs;

        private ModelEnumTypeDef(string name,
            ImmutableList<ModelEnumItemDef> enumItemDefs)
        {
            Name = name;
            EnumItemDefs = enumItemDefs;
        }

        public ModelEnumTypeDef(string name, string? summary, string? obsoleteMessage,
            IEnumerable<ModelEnumItemDef> enumItemDefs)
        {
            Name = name;
            Summary = summary;
            ObsoleteMessage = obsoleteMessage;
            EnumItemDefs = ImmutableList<ModelEnumItemDef>.Empty.AddRange(enumItemDefs);
        }

        public ModelEnumTypeDef(JsonEnumTypeDef? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Name = source.Name ?? throw new ArgumentNullException(nameof(source.Name));
            Summary = source.Summary;
            ObsoleteMessage = source.ObsoleteMessage;
            EnumItemDefs = source.EnumItemDefs != null
                ? ImmutableList<ModelEnumItemDef>.Empty.AddRange(source.EnumItemDefs.Where(fd => fd != null).Select(fd => new ModelEnumItemDef(fd)))
                : ImmutableList<ModelEnumItemDef>.Empty;
        }

        public string ToJson()
        {
            var ed = new JsonEnumTypeDef(this);
            return JsonSerializer.Serialize(ed);
        }

        public static ModelEnumTypeDef FromJson(string json)
        {
            var cd = JsonSerializer.Deserialize<JsonEnumTypeDef>(json);
            return new ModelEnumTypeDef(cd);
        }

        public bool Equals(ModelEnumTypeDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Name, other.Name)
                   && string.Equals(Summary, other.Summary)
                   && string.Equals(ObsoleteMessage, other.ObsoleteMessage)
                   && EnumItemDefs.IsEqualTo(other.EnumItemDefs)
                   ;
        }

        public override bool Equals(object? obj)
        {
            return obj is ModelEnumTypeDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name?.GetHashCode() ?? 0;
                hashCode = hashCode * 397 ^ (Summary?.GetHashCode() ?? 0);
                hashCode = hashCode * 397 ^ (ObsoleteMessage?.GetHashCode() ?? 0);
                // ordered
                hashCode = hashCode * 397 ^ EnumItemDefs.Count;
                foreach (var field in EnumItemDefs)
                {
                    hashCode = hashCode * 397 ^ field.GetHashCode();
                }
                return hashCode;
            }
        }
    }
}