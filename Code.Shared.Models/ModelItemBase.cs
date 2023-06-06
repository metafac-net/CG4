using System;

namespace MetaFac.CG4.Models
{
    public class ModelItemBase : IEquatable<ModelItemBase>
    {
        public readonly string Name;
        public readonly int? Tag;
        public readonly string? Summary;
        public readonly ModelItemState? State;

        public ModelItemBase(string name, int? tag, string? summary, ModelItemState? state)
        {
            Name = name;
            Tag = tag;
            Summary = summary;
            State = state;
        }

        public bool IsInactive => State is null ? false : State.IsInactive;
        public bool IsRedacted => State is null ? false : State.IsRedacted;

        public bool Equals(ModelItemBase? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Name, other.Name)
                && Tag == other.Tag
                && string.Equals(Summary, other.Summary)
                && Equals(State, other.State)
                ;
        }

        public override bool Equals(object? obj) => obj is ModelItemBase other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Name, Tag, Summary, State);
    }
}