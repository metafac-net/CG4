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
        public readonly ImmutableList<ModelEntityDef> EntityDefs;

        private ModelDefinition(string name, int? tag, ImmutableList<ModelEntityDef> entityDefs)
        {
            Name = name;
            Tag = tag;
            EntityDefs = entityDefs;
        }

        public IEnumerable<ModelEntityDef> DescendentsOf(string entityName)
        {
            foreach (var entityDef in EntityDefs)
            {
                if (entityDef.ParentName == entityName)
                    yield return entityDef;
            }
        }

        public IEnumerable<ModelEntityDef> AllDescendentsOf(string entityName)
        {
            foreach (var entityDef in DescendentsOf(entityName))
            {
                yield return entityDef;
                foreach (var derived in AllDescendentsOf(entityDef.Name))
                {
                    yield return derived;
                }
            }
        }

        public ModelDefinition(string modelName, int? tag,
            IEnumerable<ModelEntityDef>? entityDefs = null,
            IEnumerable<KeyValuePair<string, string>>? tokens = null)
        {
            Name = modelName;
            Tag = tag;
            EntityDefs = entityDefs != null
                ? ImmutableList<ModelEntityDef>.Empty.AddRange(entityDefs.Where(cd => cd != null))
                : ImmutableList<ModelEntityDef>.Empty;
        }

        public ModelDefinition(JsonModelDef? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Tag = source.Tag;
            Name = source.Name ?? "Unknown_Model";
            EntityDefs = source.EntityDefs != null
                ? ImmutableList<ModelEntityDef>.Empty.AddRange(source.EntityDefs.Where(cd => cd != null).Select(cd => new ModelEntityDef(cd)))
                : ImmutableList<ModelEntityDef>.Empty;
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

        public bool Equals(ModelDefinition? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return Tag == other.Tag
                   && string.Equals(Name, other.Name)
                   && EntityDefs.IsEqualTo(other.EntityDefs);
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
                hashCode = hashCode * 397 ^ (EntityDefs != null ? EntityDefs.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}