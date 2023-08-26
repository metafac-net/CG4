using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class ModelEntityDef : ModelItemBase, IEquatable<ModelEntityDef>
    {
        public readonly string? ParentName;
        private readonly ImmutableList<ModelMemberDef> _memberDefs;
        private readonly ImmutableList<ModelEntityDef> _derivedEntities;
        public ImmutableList<ModelEntityDef> AllDerivedEntities => _derivedEntities;
        public ImmutableList<ModelEntityDef> DerivedEntities => ImmutableList<ModelEntityDef>.Empty.AddRange(_derivedEntities.Where(ed => !ed.IsRedacted));

        public ImmutableList<ModelMemberDef> AllMemberDefs => _memberDefs;
        public IEnumerable<ModelMemberDef> MemberDefs => _memberDefs.Where(md => !md.IsRedacted);

        private ModelEntityDef(string name, int? tag, string? summary,
            string? parentName,
            ImmutableDictionary<string, string> tokens,
            ImmutableList<ModelMemberDef> memberDefs,
            ImmutableList<ModelEntityDef> derivedEntities,
            ModelItemState? state)
            : base(name, tag, summary, state, tokens)
        {
            ParentName = parentName;
            _memberDefs = memberDefs;
            _derivedEntities = derivedEntities;
        }

        public ModelEntityDef(string name, int? tag, string? summary,
            string? parentName,
            IEnumerable<ModelMemberDef> memberDefs,
            ModelItemState? state = null,
            IEnumerable<KeyValuePair<string, string>>? tokens = null)
            : base(name, tag, summary, state, tokens)
        {
            ParentName = parentName;
            _memberDefs = ImmutableList<ModelMemberDef>.Empty.AddRange(memberDefs);
            _derivedEntities = ImmutableList<ModelEntityDef>.Empty;
        }

        internal ModelEntityDef SetAllDescendents(IEnumerable<ModelEntityDef> descendents)
        {
            return new ModelEntityDef(
                Name, Tag, Summary, ParentName, Tokens, _memberDefs,
                ImmutableList<ModelEntityDef>.Empty.AddRange(descendents),
                State);
        }

        public static ModelEntityDef? From(JsonEntityDef? source)
        {
            if (source is null) return null;
            return new ModelEntityDef(
                source.Name ?? throw new ArgumentNullException(nameof(source.Name)),
                source.Tag,
                source.Summary,
                source.ParentName,
                source.Tokens is null
                    ? ImmutableDictionary<string, string>.Empty
                    : ImmutableDictionary<string, string>.Empty.AddRange(source.Tokens),
                ImmutableList<ModelMemberDef>.Empty.AddRange(source.MemberDefs.NotNullRange(ModelMemberDef.From)),
                ImmutableList<ModelEntityDef>.Empty,
                ModelItemState.From(source.State));
        }

        public bool Equals(ModelEntityDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return base.Equals(other)
                && string.Equals(ParentName, other.ParentName)
                && _memberDefs.IsEqualTo(other._memberDefs)
                ;
        }

        public override bool Equals(object? obj)
        {
            return obj is ModelEntityDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(base.GetHashCode());
            hashCode.Add(ParentName);
            hashCode.Add(_memberDefs.Count);
            foreach (var md in _memberDefs)
            {
                hashCode.Add(md);
            }
            hashCode.Add(State);
            return hashCode.ToHashCode();
        }
    }
}