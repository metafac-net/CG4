using System.Collections.Generic;
using System;
using System.Collections.Immutable;

namespace MetaFac.CG4.Models
{
    public class ModelEnumTypeDef : ModelItemBase, IEquatable<ModelEnumTypeDef>
    {
        public readonly ImmutableList<ModelEnumItemDef> EnumItemDefs;

        public ModelEnumTypeDef(string name, IEnumerable<ModelEnumItemDef> enumItemDefs, 
            string? summary = null, ModelItemState? state = null, IEnumerable<KeyValuePair<string, string>>? tokens = null)
            : base(name, null, summary, state, tokens)
        {
            EnumItemDefs = ImmutableList<ModelEnumItemDef>.Empty.AddRange(enumItemDefs);
        }

        public static ModelEnumTypeDef? From(JsonEnumTypeDef? source)
        {
            if (source is null) return null;
            return new ModelEnumTypeDef(
                source.Name ?? throw new ArgumentNullException(nameof(source.Name)),
                source.EnumItemDefs.NotNullRange(ModelEnumItemDef.From),
                source.Summary,
                ModelItemState.From(source.State),
                source.Tokens);
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