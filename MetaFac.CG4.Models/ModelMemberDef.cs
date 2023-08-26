using System;
using System.Collections.Generic;

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

        public bool IsBufferType => InnerType == "binary";
        public bool IsStringType => InnerType == "string";

        public ModelMemberDef(string name, int? tag, string? summary,
            string innerType,
            bool nullable,
            ModelProxyDef? proxyDef,
            int arrayRank,
            string? indexType,
            bool isModelType,
            ModelItemState? state = null,
            IEnumerable<KeyValuePair<string, string>>? tokens = null)
            : base(name, tag, summary, state, tokens)
        {
            InnerType = innerType ?? throw new ArgumentNullException(nameof(innerType));
            Nullable = nullable;
            ProxyDef = proxyDef;
            ArrayRank = arrayRank;
            IndexType = indexType;
            IsModelType = isModelType;
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
                ModelItemState.From(source.State),
                source.Tokens
                );
        }

        public bool Equals(ModelMemberDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return base.Equals(other)
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
            return obj is ModelMemberDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(base.GetHashCode());
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