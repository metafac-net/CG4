using System;

namespace MetaFac.CG4.Models
{
    public class ModelItemState : IEquatable<ModelItemState>
    {
        public readonly bool IsObsolete;
        public readonly string? Reason;
        public readonly bool IsError;

        public ModelItemState(bool isObsolete, string? reason, bool isError = false)
        {
            IsObsolete = isObsolete;
            Reason = reason;
            IsError = isError;
        }

        public ModelItemState(JsonItemState source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            IsObsolete = source.IsObsolete;
            Reason = source.Reason;
            IsError = source.IsError;
        }

        public bool Equals(ModelItemState? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return IsObsolete == other.IsObsolete 
                && string.Equals(Reason, other.Reason)
                && IsError == other.IsError
                ;
        }

        public override bool Equals(object? obj) => obj is ModelItemState other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(IsObsolete, Reason, IsError);
    }
}