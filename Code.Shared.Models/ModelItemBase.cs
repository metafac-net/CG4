using System;

namespace MetaFac.CG4.Models
{
    public class ModelItemBase : IEquatable<ModelItemBase>
    {
        public readonly string Name;
        public readonly int? Tag;
        public readonly string? Summary;

        public ModelItemBase(string name, int? tag, string? summary)
        {
            Name = name;
            Tag = tag;
            Summary = summary;
        }

        public bool Equals(ModelItemBase? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Name, other.Name)
                && Tag == other.Tag
                && string.Equals(Summary, other.Summary)
                   ;
        }

        public override bool Equals(object? obj) => obj is ModelItemBase other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Name, Tag, Summary);
    }
}