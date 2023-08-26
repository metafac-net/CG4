using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MetaFac.CG4.Models
{
    public abstract class ModelItemBase : IEquatable<ModelItemBase>
    {
        public readonly string Name;
        public readonly int? Tag;
        public readonly string? Summary;
        public readonly ModelItemState? State;
        public readonly ImmutableDictionary<string, string> Tokens;

        protected ModelItemBase(string name, int? tag, string? summary, ModelItemState? state, IEnumerable<KeyValuePair<string, string>>? tokens)
        {
            Name = name;
            Tag = tag;
            Summary = summary;
            State = state;
            Tokens = tokens switch
            {
                null => ImmutableDictionary<string, string>.Empty,
                ImmutableDictionary<string, string> immutable => immutable,
                _ => ImmutableDictionary<string, string>.Empty.AddRange(tokens)
            };
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
                && Tokens.IsEqualTo(other.Tokens)
                ;
        }

        public override bool Equals(object? obj) => obj is ModelItemBase other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Tag);
            hashCode.Add(Summary);
            hashCode.Add(State);
            hashCode.Add(Tokens.Count);
            foreach (var kvp in Tokens)
            {
                hashCode.Add(kvp.Key);
                hashCode.Add(kvp.Value);
            }
            return hashCode.ToHashCode();
        }
    }
}