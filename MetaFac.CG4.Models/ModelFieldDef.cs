﻿using System.Collections.Generic;
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

        public ModelFieldDef(JsonFieldDef? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Tag = source.Tag;
            Name = source.Name ?? "Unknown_Field";
            InnerType = source.InnerType ?? nameof(Unknown);
            Nullable = source.Nullable;
            ProxyDef = source.ProxyDef is null ? null : new ModelProxyDef(source.ProxyDef);
            ArrayRank = source.ArrayRank;
            IndexType = source.IndexType;
            IsModelType = source.IsModelType;
        }

        public void Write(TextWriter writer)
        {
            if (ProxyDef is not null)
            {
                writer.WriteLine($"    [Proxy(\"{ProxyDef.ExternalName}\", \"{ProxyDef.ConcreteName}\")]");
            }
            writer.Write($"    field");
            if (Tag.HasValue)
                writer.Write($" {Tag.Value}:");
            writer.Write($"{InnerType}");
            if (Nullable)
                writer.Write($"?");
            if (ArrayRank == 1)
                writer.Write($"[{IndexType}]");
            writer.WriteLine($" {Name};");
        }

        public string ToJson()
        {
            var member = new JsonFieldDef(this);
            return JsonSerializer.Serialize(member);
        }

        public static ModelFieldDef FromJson(string json)
        {
            var member = JsonSerializer.Deserialize<JsonFieldDef>(json);
            return new ModelFieldDef(member);
        }

        public override string ToString()
        {
            using (StringWriter writer = new StringWriter())
            {
                Write(writer);
                return writer.ToString();
            }
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