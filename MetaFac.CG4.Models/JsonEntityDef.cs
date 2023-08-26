using System;
using System.Collections.Generic;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class JsonEntityDef : IEquatable<JsonEntityDef>
    {
        public string? Name { get; set; }
        public int? Tag { get; set; }
        public string? Summary { get; set; }
        public JsonItemState? State { get; set; }
        public string? ParentName { get; set; }
        public List<JsonMemberDef>? MemberDefs { get; set; }
        public Dictionary<string, string>? Tokens { get; set; }

        public JsonEntityDef() { }

        public JsonEntityDef(ModelEntityDef source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Name = source.Name;
            Tag = source.Tag;
            Summary = source.Summary;
            State = JsonItemState.From(source.State);
            ParentName = source.ParentName;
            MemberDefs = source.AllMemberDefs.Select(fd => new JsonMemberDef(fd)).ToList();
            Tokens = source.Tokens.Count > 0 ? new Dictionary<string, string>(source.Tokens) : null;
        }

        public bool Equals(JsonEntityDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Name, other.Name)
                   && Tag == other.Tag
                   && string.Equals(Summary, other.Summary)
                   && Equals(State, other.State)
                   && string.Equals(ParentName, other.ParentName)
                   && MemberDefs.IsEqualTo(other.MemberDefs)
                   && Tokens.IsEqualTo(other.Tokens)
                   ;
        }

        public override bool Equals(object? obj)
        {
            return obj is JsonEntityDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Tag);
            hashCode.Add(Summary);
            hashCode.Add(State);
            hashCode.Add(ParentName);
            if (MemberDefs is not null)
            {
                hashCode.Add(MemberDefs.Count);
                foreach (var fd in MemberDefs)
                {
                    hashCode.Add(fd);
                }
            }
            if (Tokens is not null)
            {
                hashCode.Add(Tokens.Count);
                foreach (var kvp in Tokens)
                {
                    hashCode.Add(kvp.Key);
                    hashCode.Add(kvp.Value);
                }
            }
            return hashCode.ToHashCode();
        }
    }
}