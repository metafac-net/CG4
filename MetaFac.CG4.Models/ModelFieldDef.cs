using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class ModelFieldDef : IEquatable<ModelFieldDef>
    {
        public readonly int? Tag;
        public readonly string Name;
        public readonly string InnerType;
        public readonly bool Nullable;
        public readonly ModelProxyDef? ProxyDef;
        public readonly int ArrayRank;
        public readonly string? IndexType;
        public readonly bool IsModelType;

        public bool IsBufferType => InnerType == "binary";
        public bool IsStringType => InnerType == "string";

        public ModelFieldDef(string fieldName, int? tag, string innerType,
            bool nullable,
            ModelProxyDef? proxyDef,
            int arrayRank,
            string? indexType,
            bool isModelType)
        {
            Tag = tag;
            Name = fieldName;
            InnerType = innerType ?? throw new ArgumentNullException(nameof(innerType));
            Nullable = nullable;
            ProxyDef = proxyDef;
            ArrayRank = arrayRank;
            IndexType = indexType;
            IsModelType = isModelType;
        }

        public static ModelFieldDef? From(JsonFieldDef? source)
        {
            if (source is null) return null;
            return new ModelFieldDef(
                source.Name ?? throw new ArgumentNullException(nameof(source.Name)),
                source.Tag,
                source.InnerType ?? throw new ArgumentNullException(nameof(source.InnerType)),
                source.Nullable,
                ModelProxyDef.From(source.ProxyDef),
                source.ArrayRank,
                source.IndexType,
                source.IsModelType);
        }

        public string ToJson()
        {
            var member = new JsonFieldDef(this);
            return JsonSerializer.Serialize(member);
        }

        public static ModelFieldDef? FromJson(string json)
        {
            var member = JsonSerializer.Deserialize<JsonFieldDef>(json);
            return ModelFieldDef.From(member);
        }

        public bool Equals(ModelFieldDef? other)
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
            return obj is ModelFieldDef other && Equals(other);
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