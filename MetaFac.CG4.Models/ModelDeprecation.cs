using System;

namespace MetaFac.CG4.Models
{
    public class ModelItemState : IEquatable<ModelItemState>
    {
        public readonly string? Reason;
        public readonly bool IsError;

        public ModelItemState(string? reason, bool isError = false)
        {
            Reason = reason;
            IsError = isError;
        }

        public ModelItemState(JsonItemState source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Reason = source.Reason;
            IsError = source.IsError;
        }

        public bool Equals(ModelItemState? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Reason, other.Reason)
                   && IsError == other.IsError
                   ;
        }

        public override bool Equals(object? obj) => obj is ModelItemState other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Reason, IsError);
    }
}