using System.Collections.Generic;
using System;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class JsonEntityDef : IEquatable<JsonEntityDef>
    {
        public int? Tag { get; set; }
        public string? Name { get; set; }
        public bool IsAbstract { get; set; }
        public string? ParentName { get; set; }
        public List<JsonMemberDef>? MemberDefs { get; set; }

        public JsonEntityDef() { }

        public JsonEntityDef(ModelEntityDef source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Tag = source.Tag;
            Name = source.Name;
            IsAbstract = source.IsAbstract;
            ParentName = source.ParentName;
            MemberDefs = source.MemberDefs.Select(fd => new JsonMemberDef(fd)).ToList();
        }

        public bool Equals(JsonEntityDef? other)
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
            return obj is JsonEntityDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Tag?.GetHashCode() ?? 0;
                hashCode = hashCode * 397 ^ (Name?.GetHashCode() ?? 0);
                hashCode = hashCode * 397 ^ IsAbstract.GetHashCode();
                hashCode = hashCode * 397 ^ (ParentName?.GetHashCode() ?? 0);
                // ordered
                if (MemberDefs != null)
                {
                    hashCode = hashCode * 397 ^ MemberDefs.Count;
                    foreach (var fd in MemberDefs)
                    {
                        hashCode = hashCode * 397 ^ fd.GetHashCode();
                    }
                }
                return hashCode;
            }
        }
    }
}
