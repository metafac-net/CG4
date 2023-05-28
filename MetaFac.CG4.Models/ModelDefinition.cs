using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.Text.Json;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class ModelDefinition : IEquatable<ModelDefinition>
    {
        public readonly string Name;
        public readonly int? Tag;
        public readonly ImmutableList<ModelEntityDef> EntityDefs;
        public readonly ImmutableList<ModelEnumTypeDef> EnumTypeDefs;

        private ModelDefinition(string name, int? tag, ImmutableList<ModelEntityDef> entityDefs, ImmutableList<ModelEnumTypeDef> enumTypeDefs)
        {
            Name = name;
            Tag = tag;
            EntityDefs = entityDefs;
            EnumTypeDefs = enumTypeDefs;
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
            IEnumerable<ModelEnumTypeDef>? enumTypeDefs = null)
        {
            Name = modelName;
            Tag = tag;
            EntityDefs = entityDefs != null
                ? ImmutableList<ModelEntityDef>.Empty.AddRange(entityDefs.Where(cd => cd != null))
                : ImmutableList<ModelEntityDef>.Empty;
            EnumTypeDefs = enumTypeDefs != null
                ? ImmutableList<ModelEnumTypeDef>.Empty.AddRange(enumTypeDefs.Where(cd => cd != null))
                : ImmutableList<ModelEnumTypeDef>.Empty;
        }

        public ModelDefinition(JsonModelDef? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Tag = source.Tag;
            Name = source.Name ?? "Unknown_Model";
            EntityDefs = ImmutableList<ModelEntityDef>.Empty.AddRange(source.EntityDefs.NotNullRange(ModelEntityDef.From));
            EnumTypeDefs = ImmutableList<ModelEnumTypeDef>.Empty.AddRange(source.EnumTypeDefs.NotNullRange(ModelEnumTypeDef.From));
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
                   && EntityDefs.IsEqualTo(other.EntityDefs)
                   && EnumTypeDefs.IsEqualTo(other.EnumTypeDefs)
                   ;
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
                // ordered
                hashCode = hashCode * 397 ^ EntityDefs.Count;
                foreach (var cd in EntityDefs)
                {
                    hashCode = hashCode * 397 ^ cd.GetHashCode();
                }
                hashCode = hashCode * 397 ^ EnumTypeDefs.Count;
                foreach (var ed in EnumTypeDefs)
                {
                    hashCode = hashCode * 397 ^ ed.GetHashCode();
                }

                return hashCode;
            }
        }
    }
}