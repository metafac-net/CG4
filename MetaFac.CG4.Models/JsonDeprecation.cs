using System;

namespace MetaFac.CG4.Models
{
    public class JsonItemState : IEquatable<JsonItemState>
    {
        public string? Reason { get; set; }
        public bool IsError { get; set; }

        public JsonItemState() { }

        public JsonItemState(ModelItemState source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Reason = source.Reason;
            IsError = source.IsError;
        }

        public bool Equals(JsonItemState? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Reason, other.Reason)
                   && IsError == other.IsError
                   ;
        }

        public override bool Equals(object? obj) => obj is JsonItemState other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Reason, IsError);
    }
}