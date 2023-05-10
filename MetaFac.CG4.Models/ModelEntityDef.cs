using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class ModelEntityDef : IEquatable<ModelEntityDef>
    {
        public readonly int? Tag;
        public readonly string Name;
        public readonly bool IsAbstract;
        public readonly string? ParentName;
        public readonly ImmutableList<ModelFieldDef> FieldDefs;
        public readonly ImmutableList<ModelEntityDef> DerivedEntities;

        private ModelEntityDef(string entityName, int? tag, bool isAbstract, string? parentName,
            ImmutableList<ModelFieldDef> fieldDefs,
            ImmutableList<ModelEntityDef> derivedEntities)
        {
            Tag = tag;
            Name = entityName;
            IsAbstract = isAbstract;
            ParentName = parentName;
            FieldDefs = fieldDefs;
            DerivedEntities = derivedEntities;
        }

        private static ImmutableDictionary<string, string> BuildTokens(string name, int? tag, string? parentName, IEnumerable<KeyValuePair<string, string>>? tokens)
        {
            var newTokens = ImmutableDictionary<string, string>.Empty;
            if (tokens is not null) newTokens = newTokens.AddRange(tokens);
            return newTokens;
        }

        public ModelEntityDef(string entityName, int? tag, bool isAbstract, string? parentName,
            IEnumerable<ModelFieldDef> fieldDefs)
        {
            Tag = tag;
            Name = entityName;
            IsAbstract = isAbstract;
            ParentName = parentName;
            FieldDefs = ImmutableList<ModelFieldDef>.Empty.AddRange(fieldDefs);
            DerivedEntities = ImmutableList<ModelEntityDef>.Empty;
        }

        public ModelEntityDef SetDerivedEntities(IEnumerable<ModelEntityDef> derivedEntities)
        {
            return new ModelEntityDef(
                Name, Tag, IsAbstract, ParentName, FieldDefs,
                ImmutableList<ModelEntityDef>.Empty.AddRange(derivedEntities));
        }

        public ModelEntityDef(JsonEntityDef? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Tag = source.Tag;
            Name = source.Name ?? "Unknown_Class";
            IsAbstract = source.IsAbstract;
            ParentName = source.ParentName;
            FieldDefs = source.FieldDefs != null
                ? ImmutableList<ModelFieldDef>.Empty.AddRange(source.FieldDefs.Where(fd => fd != null).Select(fd => new ModelFieldDef(fd)))
                : ImmutableList<ModelFieldDef>.Empty;
            DerivedEntities = ImmutableList<ModelEntityDef>.Empty;
        }

        public string ToJson()
        {
            var cd = new JsonEntityDef(this);
            return JsonSerializer.Serialize(cd);
        }

        public static ModelEntityDef FromJson(string json)
        {
            var cd = JsonSerializer.Deserialize<JsonEntityDef>(json);
            return new ModelEntityDef(cd);
        }

        public bool Equals(ModelEntityDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return Tag == other.Tag
                   && string.Equals(Name, other.Name)
                   && IsAbstract == other.IsAbstract
                   && string.Equals(ParentName, other.ParentName)
                   && FieldDefs.IsEqualTo(other.FieldDefs);
        }

        public override bool Equals(object? obj)
        {
            return obj is ModelEntityDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Tag.GetHashCode();
                hashCode = hashCode * 397 ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = hashCode * 397 ^ IsAbstract.GetHashCode();
                hashCode = hashCode * 397 ^ (ParentName != null ? ParentName.GetHashCode() : 0);
                // ordered
                hashCode = hashCode * 397 ^ FieldDefs.Count.GetHashCode();
                foreach (var field in FieldDefs)
                {
                    hashCode = hashCode * 397 ^ field.GetHashCode();
                }
                return hashCode;
            }
        }
    }
}