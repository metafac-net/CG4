using System;

namespace MetaFac.CG4.Models
{
    public class JsonItemState : IEquatable<JsonItemState>
    {
        public bool IsInactive { get; set; }
        public bool IsRedacted { get; set; }
        public string? Reason { get; set; }

        public JsonItemState() { }

        public static JsonItemState? From(ModelItemState? source)
        {
            if (source is null) return null;
            return new JsonItemState()
            {
                IsInactive = source.IsInactive,
                IsRedacted = source.IsRedacted,
                Reason = source.Reason,
            };
        }

        public bool Equals(JsonItemState? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return IsInactive == other.IsInactive
                && IsRedacted == other.IsRedacted
                && string.Equals(Reason, other.Reason)
                ;
        }

        public override bool Equals(object? obj) => obj is JsonItemState other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(IsInactive, IsRedacted, Reason);
    }
}