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

        public ModelItemInfo(JsonItemInfo source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Summary = source.Summary;
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