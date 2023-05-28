﻿using System;
using System.Text.Json;

namespace MetaFac.CG4.Models
{
    public class ModelMemberDef : ModelItemBase, IEquatable<ModelMemberDef>
    {
        public readonly string InnerType;
        public readonly bool Nullable;
        public readonly ModelProxyDef? ProxyDef;
        public readonly int ArrayRank;
        public readonly string? IndexType;
        public readonly bool IsModelType;
        public readonly ModelItemState? State;

        public bool IsBufferType => InnerType == "binary";
        public bool IsStringType => InnerType == "string";

        public ModelMemberDef(string name, int? tag, string? summary, 
            string innerType,
            bool nullable,
            ModelProxyDef? proxyDef,
            int arrayRank,
            string? indexType,
            bool isModelType, 
            ModelItemState? state = null)
            : base(name, tag, summary)
        {
            InnerType = innerType ?? throw new ArgumentNullException(nameof(innerType));
            Nullable = nullable;
            ProxyDef = proxyDef;
            ArrayRank = arrayRank;
            IndexType = indexType;
            IsModelType = isModelType;
            State = state;
        }

        public static ModelMemberDef? From(JsonMemberDef? source)
        {
            if (source is null) return null;
            return new ModelMemberDef(
                source.Name ?? throw new ArgumentNullException(nameof(source.Name)),
                source.Tag,
                source.Summary,
                source.InnerType ?? throw new ArgumentNullException(nameof(source.InnerType)),
                source.Nullable,
                ModelProxyDef.From(source.ProxyDef),
                source.ArrayRank,
                source.IndexType,
                source.IsModelType,
                ModelItemState.From(source.State)
                );
        }

        public string ToJson()
        {
            var member = new JsonMemberDef(this);
            return JsonSerializer.Serialize(member);
        }

        public static ModelMemberDef? FromJson(string json)
        {
            var member = JsonSerializer.Deserialize<JsonMemberDef>(json);
            return ModelMemberDef.From(member);
        }

        public bool Equals(ModelMemberDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return Tag == other.Tag
                   && string.Equals(Name, other.Name)
                   && string.Equals(InnerType, other.InnerType)
                   && Nullable == other.Nullable
                   && Equals(ProxyDef, other.ProxyDef)
                   && ArrayRank == other.ArrayRank
                   && string.Equals(IndexType, other.IndexType)
                   && IsModelType == other.IsModelType;
        }

        public override bool Equals(object? obj)
        {
            return obj is ModelMemberDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Tag.GetHashCode();
                hashCode = hashCode * 397 ^ (Name?.GetHashCode() ?? 0);
                hashCode = hashCode * 397 ^ (InnerType?.GetHashCode() ?? 0);
                hashCode = hashCode * 397 ^ Nullable.GetHashCode();
                hashCode = hashCode * 397 ^ (ProxyDef?.GetHashCode() ?? 0);
                hashCode = hashCode * 397 ^ ArrayRank.GetHashCode();
                hashCode = hashCode * 397 ^ (IndexType?.GetHashCode() ?? 0);
                hashCode = hashCode * 397 ^ IsModelType.GetHashCode();
                return hashCode;
            }
        }
    }
}