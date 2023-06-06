using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.Text.Json;

namespace MetaFac.CG4.Models
{
    public class ModelEnumTypeDef : ModelItemBase, IEquatable<ModelEnumTypeDef>
    {
        public readonly ImmutableList<ModelEnumItemDef> EnumItemDefs;

        public ModelEnumTypeDef(string name, string? summary, ModelItemState? state, IEnumerable<ModelEnumItemDef> enumItemDefs)
            : base(name, null, summary, state)
        {
            EnumItemDefs = ImmutableList<ModelEnumItemDef>.Empty.AddRange(enumItemDefs);
        }

        public static ModelEnumTypeDef? From(JsonEnumTypeDef? source)
        {
            if (source is null) return null;
            return new ModelEnumTypeDef(
                source.Name ?? throw new ArgumentNullException(nameof(source.Name)),
                source.Summary,
                ModelItemState.From(source.State),
                source.EnumItemDefs.NotNullRange(ModelEnumItemDef.From));
        }

        public string ToJson()
        {
            var ed = new JsonEnumTypeDef(this);
            return JsonSerializer.Serialize(ed);
        }

        public static ModelEnumTypeDef? FromJson(string json)
        {
            var cd = JsonSerializer.Deserialize<JsonEnumTypeDef>(json);
            return ModelEnumTypeDef.From(cd);
        }

        public bool Equals(ModelEnumTypeDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return base.Equals(other)
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
                var hashCode = new HashCode();
                hashCode.Add(base.GetHashCode());
                hashCode.Add(State);
                // ordered
                hashCode.Add(EnumItemDefs.Count);
                foreach (var field in EnumItemDefs)
                {
                    hashCode.Add(field);
                }
                return hashCode.ToHashCode();
            }
        }
    }
}