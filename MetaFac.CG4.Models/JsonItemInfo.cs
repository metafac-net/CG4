using System;

namespace MetaFac.CG4.Models
{
    public class JsonItemInfo : IEquatable<JsonItemInfo>
    {
        public string? Summary { get; set; }

        public JsonItemInfo() { }

        public JsonItemInfo(ModelItemInfo source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Summary = source.Summary;
        }

        public bool Equals(JsonItemInfo? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Summary, other.Summary)
                   ;
        }

        public override bool Equals(object? obj) => obj is JsonItemInfo other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Summary);
    }
}