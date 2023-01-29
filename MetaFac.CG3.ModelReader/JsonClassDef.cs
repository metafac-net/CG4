using System;
using System.Collections.Generic;
using System.Linq;

namespace MetaCode.Models
{
    public class JsonClassDef : IEquatable<JsonClassDef>
    {
        public int? Tag { get; set; }
        public string? Name { get; set; }
        public bool IsAbstract { get; set; }
        public string? BaseClassName { get; set; }
        public List<JsonFieldDef>? FieldDefs { get; set; }
        public Dictionary<string, string>? Tokens { get; set; }

        public JsonClassDef() { }

        public JsonClassDef(ModelClassDef source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Tag = source.Tag;
            Name = source.Name;
            IsAbstract = source.IsAbstract;
            BaseClassName = source.BaseClassName;
            FieldDefs = source.FieldDefs.Select(fd => new JsonFieldDef(fd)).ToList();
            Tokens = new Dictionary<string, string>(source.Tokens);
        }

        public bool Equals(JsonClassDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return Tag == other.Tag
                   && string.Equals(Name, other.Name)
                   && (this.IsAbstract == other.IsAbstract)
                   && string.Equals(BaseClassName, other.BaseClassName)
                   && FieldDefs.IsEqualTo(other.FieldDefs)
                   && Tokens.IsEqualTo(other.Tokens);
        }

        public override bool Equals(object? obj)
        {
            return obj is JsonClassDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Tag?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ IsAbstract.GetHashCode();
                hashCode = (hashCode * 397) ^ (BaseClassName?.GetHashCode() ?? 0);
                // order sensitive
                if (FieldDefs != null)
                {
                    hashCode = (hashCode * 397) ^ FieldDefs.Count.GetHashCode();
                    for (int i = 0; i < FieldDefs.Count; i++)
                    {
                        hashCode = (hashCode * 397) ^ FieldDefs[i].GetHashCode();
                    }
                }
                // order ignored
                if (Tokens != null)
                {
                    hashCode = (hashCode * 397) ^ Tokens.Count.GetHashCode();
                    foreach (var kvp in Tokens)
                    {
                        hashCode = hashCode ^ kvp.Key.GetHashCode();
                        if (kvp.Value != null) hashCode = hashCode ^ kvp.Value.GetHashCode();
                    }
                }
                return hashCode;
            }
        }
    }
}
