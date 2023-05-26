using System;

namespace MetaFac.CG4.Models
{
    public class ModelItemInfo : IEquatable<ModelItemInfo>
    {
        public readonly string? Summary;

        public ModelItemInfo(string? summary)
        {
            Summary = summary;
        }

        public static ModelItemInfo? From(JsonItemInfo? source)
        {
            if (source is null) return null;
            return new ModelItemInfo(source.Summary);
        }

        public bool Equals(ModelItemInfo? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Summary, other.Summary)
                   ;
        }

        public override bool Equals(object? obj) => obj is ModelItemInfo other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Summary);
    }
}