using System;

namespace MetaFac.CG4.Models
{
    public class ModelEnumItemDef : ModelItemBase, IEquatable<ModelEnumItemDef>
    {
        public readonly int Value;

        public ModelEnumItemDef(string name, string? summary, int value, ModelItemState? state = null)
            : base(name, null, summary, state)
        {
            Value = value;
        }

        public static ModelEnumItemDef? From(JsonEnumItemDef? source)
        {
            if (source is null) return null;
            return new ModelEnumItemDef(
                source.Name ?? throw new ArgumentNullException(nameof(source.Name)),
                source.Summary,
                source.Value,
                ModelItemState.From(source.State));
        }

        public bool Equals(ModelEnumItemDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return  base.Equals(other)
                && Value == other.Value
                ;
        }

        public override bool Equals(object? obj) => obj is ModelEnumItemDef other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(base.GetHashCode());
            hashCode.Add(Value);
            hashCode.Add(State);
            return hashCode.ToHashCode();
        }
    }
}