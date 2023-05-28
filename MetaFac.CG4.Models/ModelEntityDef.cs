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

        private ModelEntityDef(string name, int? tag, string? summary, bool isAbstract, string? parentName,
            ImmutableList<ModelMemberDef> memberDefs,
            ImmutableList<ModelEntityDef> derivedEntities)
            : base(name, tag, summary)
        {
            IsAbstract = isAbstract;
            ParentName = parentName;
            MemberDefs = memberDefs;
            DerivedEntities = derivedEntities;
        }

        public ModelEntityDef(string name, int? tag, string? summary, bool isAbstract, string? parentName,
            IEnumerable<ModelMemberDef> memberDefs)
            : base(name, tag, summary)
        {
            IsAbstract = isAbstract;
            ParentName = parentName;
            MemberDefs = ImmutableList<ModelMemberDef>.Empty.AddRange(memberDefs);
            DerivedEntities = ImmutableList<ModelEntityDef>.Empty;
        }

        public ModelEntityDef SetDerivedEntities(IEnumerable<ModelEntityDef> derivedEntities)
        {
            return new ModelEntityDef(
                Name, Tag, Summary, IsAbstract, ParentName, MemberDefs,
                ImmutableList<ModelEntityDef>.Empty.AddRange(derivedEntities));
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
                ImmutableList<ModelEntityDef>.Empty);
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
            return Tag == other.Tag
                   && string.Equals(Name, other.Name)
                   && IsAbstract == other.IsAbstract
                   && string.Equals(ParentName, other.ParentName)
                   && MemberDefs.IsEqualTo(other.MemberDefs);
        }

        public override bool Equals(object? obj)
        {
            return obj is ModelEntityDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Tag.GetHashCode();
                hashCode = hashCode * 397 ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = hashCode * 397 ^ IsAbstract.GetHashCode();
                hashCode = hashCode * 397 ^ (ParentName != null ? ParentName.GetHashCode() : 0);
                // ordered
                hashCode = hashCode * 397 ^ MemberDefs.Count;
                foreach (var field in MemberDefs)
                {
                    hashCode = hashCode * 397 ^ field.GetHashCode();
                }
                return hashCode;
            }
        }
    }
}