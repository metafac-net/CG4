using System;

namespace MetaFac.CG4.Models
{
    public class JsonItemState : IEquatable<JsonItemState>
    {
        public bool IsObsolete { get; set; }
        public string? Reason { get; set; }
        public bool IsError { get; set; }

        public JsonItemState() { }

        public static JsonItemState? From(ModelItemState? source)
        {
            if (source is null) return null;
            return new JsonItemState()
            {
                IsObsolete = source.IsObsolete,
                Reason = source.Reason,
                IsError = source.IsError
            };
        }

        public bool Equals(JsonItemState? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return IsObsolete == other.IsObsolete
                && string.Equals(Reason, other.Reason)
                && IsError == other.IsError
                ;
        }

        public override bool Equals(object? obj) => obj is JsonItemState other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(IsObsolete, Reason, IsError);
    }
}