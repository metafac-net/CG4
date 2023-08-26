using System;
using System.Collections.Generic;

namespace MetaFac.CG4.Models
{
    public class JsonEnumItemDef : IEquatable<JsonEnumItemDef>
    {
        public string? Name { get; set; }
        public int Value { get; set; }
        public string? Summary { get; set; }
        public JsonItemState? State { get; set; }
        public Dictionary<string, string>? Tokens { get; set; }

        public JsonEnumItemDef() { }

        public JsonEnumItemDef(ModelEnumItemDef source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Name = source.Name;
            Value = source.Value;
            Summary = source.Summary;
            State = JsonItemState.From(source.State);
            Tokens = source.Tokens.Count > 0 ? new Dictionary<string, string>(source.Tokens) : null;
        }

        public bool Equals(JsonEnumItemDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Name, other.Name)
                   && Value == other.Value
                   && string.Equals(Summary, other.Summary)
                   && Equals(State, other.State)
                   && Tokens.IsEqualTo(other.Tokens)
                   ;
        }

        public override bool Equals(object? obj)
        {
            return obj is JsonEnumItemDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Value);
            hashCode.Add(Summary);
            hashCode.Add(State);
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