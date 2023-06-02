using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.Text.Json;
using System.Xml.Linq;

namespace MetaFac.CG4.Models
{
    public class ModelEntityDef : ModelItemBase, IEquatable<ModelEntityDef>
    {
        public readonly bool IsAbstract;
        public readonly string? ParentName;
        public readonly ImmutableList<ModelMemberDef> MemberDefs;
        public readonly ImmutableList<ModelEntityDef> DerivedEntities;
        public readonly ModelItemState? State;

        private ModelEntityDef(string name, int? tag, string? summary, 
            bool isAbstract, string? parentName,
            ImmutableList<ModelMemberDef> memberDefs,
            ImmutableList<ModelEntityDef> derivedEntities,
            ModelItemState? state)
            : base(name, tag, summary)
        {
            IsAbstract = isAbstract;
            ParentName = parentName;
            MemberDefs = memberDefs;
            DerivedEntities = derivedEntities;
            State = state;
        }

        public ModelEntityDef(string name, int? tag, string? summary,
            bool isAbstract, string? parentName,
            IEnumerable<ModelMemberDef> memberDefs,
            ModelItemState? state = null)
            : base(name, tag, summary)
        {
            IsAbstract = isAbstract;
            ParentName = parentName;
            MemberDefs = ImmutableList<ModelMemberDef>.Empty.AddRange(memberDefs);
            DerivedEntities = ImmutableList<ModelEntityDef>.Empty;
            State = state;
        }

        public ModelEntityDef SetDerivedEntities(IEnumerable<ModelEntityDef> derivedEntities)
        {
            return new ModelEntityDef(
                Name, Tag, Summary, IsAbstract, ParentName, MemberDefs,
                ImmutableList<ModelEntityDef>.Empty.AddRange(derivedEntities),
                State);
        }

        public static ModelEntityDef? From(JsonEntityDef? source)
        {
            if (source is null) return null;
            return new ModelEntityDef(
                source.Name ?? throw new ArgumentNullException(nameof(source.Name)),
                source.Tag,
                source.Summary,
                source.IsAbstract,
                source.ParentName,
                ImmutableList<ModelMemberDef>.Empty.AddRange(source.MemberDefs.NotNullRange(ModelMemberDef.From)),
                ImmutableList<ModelEntityDef>.Empty,
                ModelItemState.From(source.State));
        }

        public string ToJson()
        {
            var cd = new JsonEntityDef(this);
            return JsonSerializer.Serialize(cd);
        }

        public static ModelEntityDef? FromJson(string json)
        {
            var cd = JsonSerializer.Deserialize<JsonEntityDef>(json);
            return ModelEntityDef.From(cd);
        }

        public bool Equals(ModelEntityDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return base.Equals(other)
                && IsAbstract == other.IsAbstract
                && string.Equals(ParentName, other.ParentName)
                && MemberDefs.IsEqualTo(other.MemberDefs)
                && Equals(State, other.State)
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
            hashCode.Add(IsAbstract);
            hashCode.Add(ParentName);
            if(MemberDefs is not null)
            {
                hashCode.Add(MemberDefs.Count);
                foreach (var md in MemberDefs)
                {
                    hashCode.Add(md);
                }
            }
            hashCode.Add(State);
            return hashCode.ToHashCode();
        }
    }
}