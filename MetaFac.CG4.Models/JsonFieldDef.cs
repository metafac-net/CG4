﻿using System.Collections.Generic;
using System;
using System.Xml.Linq;

namespace MetaFac.CG4.Models
{
    public class JsonFieldDef : IEquatable<JsonFieldDef>
    {
        public string? Name { get; set; }
        public int? Tag { get; set; }
        public string? Summary { get; set; }
        public JsonItemState? State { get; set; }
        public string? InnerType { get; set; }
        public bool Nullable { get; set; }
        public JsonProxyDef? ProxyDef { get; set; }
        public int ArrayRank { get; set; }
        public string? IndexType { get; set; }
        public bool IsModelType { get; set; }

        public JsonFieldDef() { }

        public JsonFieldDef(ModelFieldDef source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Name = source.Name;
            Tag = source.Tag;
            Summary = source.Summary;
            InnerType = source.InnerType;
            Nullable = source.Nullable;
            ProxyDef = source.ProxyDef is null ? null : new JsonProxyDef(source.ProxyDef);
            ArrayRank = source.ArrayRank;
            IsModelType = source.IsModelType;
            IndexType = source.IndexType;
            State = source.State is null ? null : new JsonItemState(source.State);
        }

        public bool Equals(JsonFieldDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Name, other.Name)
                   && Tag == other.Tag
                   && string.Equals(Summary, other.Summary)
                   && string.Equals(InnerType, other.InnerType)
                   && Nullable == other.Nullable
                   && Equals(ProxyDef, other.ProxyDef)
                   && ArrayRank == other.ArrayRank
                   && IsModelType == other.IsModelType
                   && string.Equals(IndexType, other.IndexType)
                   && Equals(State, other.State);
        }

        public override bool Equals(object? obj)
        {
            return obj is JsonFieldDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Tag);
            hashCode.Add(Summary);
            hashCode.Add(State);
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