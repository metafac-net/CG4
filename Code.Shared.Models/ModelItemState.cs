using System;

namespace MetaFac.CG4.Models
{
    public class ModelItemState : IEquatable<ModelItemState>
    {
        public readonly bool IsInactive;
        public readonly bool IsRedacted;
        public readonly string? Reason;

        private ModelItemState(bool isInactive, bool isRedacted, string? reason)
        {
            IsInactive = isInactive;
            IsRedacted = isRedacted;
            Reason = reason;
        }

        public static ModelItemState? Create(bool isInactive, bool isRedacted, string? reason)
        {
            if (!isInactive && !isRedacted && reason is null) return null;
            return new ModelItemState(isInactive, isRedacted, reason);
        }

        public static ModelItemState? From(JsonItemState? source)
        {
            if (source is null) return null;
            return new ModelItemState(source.IsInactive, source.IsRedacted, source.Reason);
        }

        public bool Equals(ModelItemState? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return IsInactive == other.IsInactive 
                && IsRedacted == other.IsRedacted
                && string.Equals(Reason, other.Reason)
                ;
        }

        public override bool Equals(object? obj) => obj is ModelItemState other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(IsInactive, IsRedacted, Reason);
    }
}