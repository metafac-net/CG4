using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class ModelDefinition : IEquatable<ModelDefinition>
    {
        public readonly string Name;
        public readonly int? Tag;
        public readonly ImmutableList<ModelClassDef> ClassDefs;

        private ModelDefinition(string name, int? tag, ImmutableList<ModelClassDef> classDefs)
        {
            Name = name;
            Tag = tag;
            ClassDefs = classDefs;
        }

        public IEnumerable<ModelClassDef> DescendentsOf(string className)
        {
            foreach (var classDef in ClassDefs)
            {
                if (classDef.BaseClassName == className)
                    yield return classDef;
            }
        }

        public IEnumerable<ModelClassDef> AllDescendentsOf(string className)
        {
            foreach (var classDef in DescendentsOf(className))
            {
                yield return classDef;
                foreach (var derived in AllDescendentsOf(classDef.Name))
                {
                    yield return derived;
                }
            }
        }

        public ModelDefinition(string modelName, int? tag,
            IEnumerable<ModelClassDef>? classDefs = null,
            IEnumerable<KeyValuePair<string, string>>? tokens = null)
        {
            Name = modelName;
            Tag = tag;
            ClassDefs = classDefs != null
                ? ImmutableList<ModelClassDef>.Empty.AddRange(classDefs.Where(cd => cd != null))
                : ImmutableList<ModelClassDef>.Empty;
        }

        public ModelDefinition(JsonModelDef? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Tag = source.Tag;
            Name = source.Name ?? "Unknown_Model";
            ClassDefs = source.ClassDefs != null
                ? ImmutableList<ModelClassDef>.Empty.AddRange(source.ClassDefs.Where(cd => cd != null).Select(cd => new ModelClassDef(cd)))
                : ImmutableList<ModelClassDef>.Empty;
        }

        internal void Write(TextWriter writer)
        {
            writer.Write($" model");
            if (Tag.HasValue)
                writer.Write($" {Tag.Value}:");
            writer.WriteLine($" {Name}");
            writer.WriteLine("{");
            foreach (ModelClassDef classDef in ClassDefs)
            {
                if (classDef != null)
                    classDef.Write(writer);
            }
            writer.WriteLine("}");
        }

        public string ToJson()
        {
            var md = new JsonModelDef(this);
            return JsonSerializer.Serialize(md);
        }

        public static ModelDefinition FromJson(string json)
        {
            var md = JsonSerializer.Deserialize<JsonModelDef>(json);
            return new ModelDefinition(md);
        }

        public void WriteTo(Stream stream)
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                Write(writer);
            }
        }

        public bool Equals(ModelDefinition? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return Tag == other.Tag
                   && string.Equals(Name, other.Name)
                   && ClassDefs.IsEqualTo(other.ClassDefs);
        }

        public override bool Equals(object? obj)
        {
            return obj is ModelDefinition other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Tag.GetHashCode();
                hashCode = hashCode * 397 ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = hashCode * 397 ^ (Tag != null ? Tag.GetHashCode() : 0);
                hashCode = hashCode * 397 ^ (ClassDefs != null ? ClassDefs.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            using (StringWriter writer = new StringWriter())
            {
                Write(writer);
                return writer.ToString();
            }
        }

    }
}