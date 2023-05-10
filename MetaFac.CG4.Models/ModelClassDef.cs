using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class ModelClassDef : IEquatable<ModelClassDef>
    {
        public readonly int? Tag;
        public readonly string Name;
        public readonly bool IsAbstract;
        public readonly string? BaseClassName;
        public readonly ImmutableList<ModelFieldDef> FieldDefs;
        public readonly ImmutableList<ModelClassDef> AllDerivedClasses;

        private ModelClassDef(string className, int? tag, bool isAbstract, string? baseClassName,
            ImmutableList<ModelFieldDef> fieldDefs,
            ImmutableList<ModelClassDef> allDerivedClasses)
        {
            Tag = tag;
            Name = className;
            IsAbstract = isAbstract;
            BaseClassName = baseClassName;
            FieldDefs = fieldDefs;
            AllDerivedClasses = allDerivedClasses;
        }

        private static ImmutableDictionary<string, string> BuildTokens(string name, int? tag, string? baseClassName, IEnumerable<KeyValuePair<string, string>>? tokens)
        {
            var newTokens = ImmutableDictionary<string, string>.Empty;
            if (tokens is not null) newTokens = newTokens.AddRange(tokens);
            return newTokens;
        }

        public ModelClassDef(string className, int? tag, bool isAbstract, string? baseClassName,
            IEnumerable<ModelFieldDef> fieldDefs)
        {
            Tag = tag;
            Name = className;
            IsAbstract = isAbstract;
            BaseClassName = baseClassName;
            FieldDefs = ImmutableList<ModelFieldDef>.Empty.AddRange(fieldDefs);
            AllDerivedClasses = ImmutableList<ModelClassDef>.Empty;
        }

        public ModelClassDef SetAllDerivedClasses(IEnumerable<ModelClassDef> allDerivedClasses)
        {
            return new ModelClassDef(
                Name, Tag, IsAbstract, BaseClassName, FieldDefs,
                ImmutableList<ModelClassDef>.Empty.AddRange(allDerivedClasses));
        }

        public ModelClassDef(JsonClassDef? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Tag = source.Tag;
            Name = source.Name ?? "Unknown_Class";
            IsAbstract = source.IsAbstract;
            BaseClassName = source.BaseClassName;
            FieldDefs = source.FieldDefs != null
                ? ImmutableList<ModelFieldDef>.Empty.AddRange(source.FieldDefs.Where(fd => fd != null).Select(fd => new ModelFieldDef(fd)))
                : ImmutableList<ModelFieldDef>.Empty;
            AllDerivedClasses = ImmutableList<ModelClassDef>.Empty;
        }

        public string ToJson()
        {
            var cd = new JsonClassDef(this);
            return JsonSerializer.Serialize(cd);
        }

        public static ModelClassDef FromJson(string json)
        {
            var cd = JsonSerializer.Deserialize<JsonClassDef>(json);
            return new ModelClassDef(cd);
        }

        public bool Equals(ModelClassDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return Tag == other.Tag
                   && string.Equals(Name, other.Name)
                   && IsAbstract == other.IsAbstract
                   && string.Equals(BaseClassName, other.BaseClassName)
                   && FieldDefs.IsEqualTo(other.FieldDefs);
        }

        public override bool Equals(object? obj)
        {
            return obj is ModelClassDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Tag.GetHashCode();
                hashCode = hashCode * 397 ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = hashCode * 397 ^ IsAbstract.GetHashCode();
                hashCode = hashCode * 397 ^ (BaseClassName != null ? BaseClassName.GetHashCode() : 0);
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