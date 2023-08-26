using System;
using System.Collections.Generic;

namespace MetaFac.CG4.Models
{
    public class JsonMemberDef : IEquatable<JsonMemberDef>
    {
        public string? Name { get; set; }
        public int? Tag { get; set; }
        public string? Summary { get; set; }
        public JsonItemState? State { get; set; }
        public Dictionary<string, string>? Tokens { get; set; }
        public string? InnerType { get; set; }
        public bool Nullable { get; set; }
        public JsonProxyDef? ProxyDef { get; set; }
        public int ArrayRank { get; set; }
        public string? IndexType { get; set; }
        public bool IsModelType { get; set; }

        public JsonMemberDef() { }

        public JsonMemberDef(ModelMemberDef source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Name = source.Name;
            Tag = source.Tag;
            Summary = source.Summary;
            InnerType = source.InnerType;
            Nullable = source.Nullable;
            ProxyDef = JsonProxyDef.From(source.ProxyDef);
            ArrayRank = source.ArrayRank;
            IsModelType = source.IsModelType;
            IndexType = source.IndexType;
            State = JsonItemState.From(source.State);
            Tokens = source.Tokens.Count > 0 ? new Dictionary<string, string>(source.Tokens) : null;
        }

        public bool Equals(JsonMemberDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Name, other.Name)
                   && Tag == other.Tag
                   && string.Equals(Summary, other.Summary)
                   && Equals(State, other.State)
                   && Tokens.IsEqualTo(other.Tokens)
                   && string.Equals(InnerType, other.InnerType)
                   && Nullable == other.Nullable
                   && Equals(ProxyDef, other.ProxyDef)
                   && ArrayRank == other.ArrayRank
                   && IsModelType == other.IsModelType
                   && string.Equals(IndexType, other.IndexType)
                   ;
        }

        public override bool Equals(object? obj)
        {
            return obj is JsonMemberDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Tag);
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
            hashCode.Add(InnerType);
            hashCode.Add(Nullable);
            hashCode.Add(ProxyDef);
            hashCode.Add(ArrayRank);
            hashCode.Add(IndexType);
            hashCode.Add(IsModelType);
            return hashCode.ToHashCode();
        }
    }
}