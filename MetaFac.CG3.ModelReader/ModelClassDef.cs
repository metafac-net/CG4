using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace MetaCode.Models
{
    public class ModelClassDef : IEquatable<ModelClassDef>
    {
        public readonly int? Tag;
        public readonly string Name;
        public readonly bool IsAbstract;
        public readonly string? BaseClassName;
        public readonly ImmutableList<ModelFieldDef> FieldDefs;
        public readonly ImmutableDictionary<string, string> Tokens;

        public ModelClassDef(string className, int? tag, bool isAbstract, string? baseClassName,
            IEnumerable<ModelFieldDef>? fieldDefs = null,
            IEnumerable<KeyValuePair<string, string>>? tokens = null)
        {
            Tag = tag;
            Name = className;
            IsAbstract = isAbstract;
            BaseClassName = baseClassName;
            FieldDefs = fieldDefs != null
                ? ImmutableList<ModelFieldDef>.Empty.AddRange(fieldDefs)
                : ImmutableList<ModelFieldDef>.Empty;
            Tokens = tokens != null
                ? ImmutableDictionary<string, string>.Empty.AddRange(tokens)
                : ImmutableDictionary<string, string>.Empty;
        }

        internal ModelClassDef(JsonClassDef? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Tag = source.Tag;
            Name = source.Name ?? "Unknown_Class";
            IsAbstract = source.IsAbstract;
            BaseClassName = source.BaseClassName;
            FieldDefs = source.FieldDefs != null
                ? ImmutableList<ModelFieldDef>.Empty.AddRange(source.FieldDefs.Where(fd => fd != null).Select(fd => new ModelFieldDef(fd)))
                : ImmutableList<ModelFieldDef>.Empty;
            Tokens = source.Tokens != null
                ? ImmutableDictionary<string, string>.Empty.AddRange(source.Tokens)
                : ImmutableDictionary<string, string>.Empty;
        }

        internal void Write(TextWriter writer)
        {
            writer.Write($"  class");
            if (Tag.HasValue)
                writer.Write($" {Tag.Value}:");
            writer.Write($" {Name}");
            if (BaseClassName != null)
                writer.Write($" extends {BaseClassName}");
            writer.WriteLine();
            writer.WriteLine("  {");
            foreach (ModelFieldDef fieldDef in FieldDefs)
            {
                if (fieldDef != null)
                    fieldDef.Write(writer);
            }
            writer.WriteLine("  }");
        }

        public string ToJson()
        {
            var cd = new JsonClassDef(this);
            return JsonSerializer.Serialize<JsonClassDef>(cd);
        }

        public static ModelClassDef FromJson(string json)
        {
            var cd = JsonSerializer.Deserialize<JsonClassDef>(json);
            return new ModelClassDef(cd);
        }

        public override string ToString()
        {
            using (StringWriter writer = new StringWriter())
            {
                Write(writer);
                return writer.ToString();
            }
        }

        public bool Equals(ModelClassDef? other)
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
            return obj is ModelClassDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Tag.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsAbstract.GetHashCode();
                hashCode = (hashCode * 397) ^ (BaseClassName != null ? BaseClassName.GetHashCode() : 0);
                // ordered
                hashCode = (hashCode * 397) ^ FieldDefs.Count.GetHashCode();
                foreach (var field in FieldDefs)
                {
                    hashCode = (hashCode * 397) ^ field.GetHashCode();
                }
                hashCode = (hashCode * 397) ^ Tokens.Count.GetHashCode();
                // order ignored
                foreach (var kvp in Tokens)
                {
                    hashCode = hashCode ^ kvp.Key.GetHashCode();
                    if (kvp.Value != null) hashCode = hashCode ^ kvp.Value.GetHashCode();
                }
                return hashCode;
            }
        }
    }
}