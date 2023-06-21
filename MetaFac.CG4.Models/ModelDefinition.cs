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
        private readonly ImmutableList<ModelEntityDef> _entityDefs;
        private readonly ImmutableList<ModelEnumTypeDef> _enumTypeDefs;

        public ImmutableList<ModelEntityDef> AllEntityDefs => _entityDefs;
        public IEnumerable<ModelEntityDef> EntityDefs => _entityDefs.Where(ed => !ed.IsRedacted);

        public ImmutableList<ModelEnumTypeDef> AllEnumTypeDefs => _enumTypeDefs;
        public IEnumerable<ModelEnumTypeDef> EnumTypeDefs => _enumTypeDefs.Where(etd => !etd.IsRedacted);

        private ModelDefinition(string name, int? tag, ImmutableList<ModelEntityDef> entityDefs, ImmutableList<ModelEnumTypeDef> enumTypeDefs)
        {
            Name = name;
            Tag = tag;
            _entityDefs = entityDefs;
            _enumTypeDefs = enumTypeDefs;
        }

        public IEnumerable<ModelEntityDef> DescendentsOf(string entityName)
        {
            foreach (var entityDef in _entityDefs)
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
            _entityDefs = entityDefs != null
                ? ImmutableList<ModelEntityDef>.Empty.AddRange(entityDefs.Where(cd => cd != null))
                : ImmutableList<ModelEntityDef>.Empty;
            _enumTypeDefs = enumTypeDefs != null
                ? ImmutableList<ModelEnumTypeDef>.Empty.AddRange(enumTypeDefs.Where(cd => cd != null))
                : ImmutableList<ModelEnumTypeDef>.Empty;
        }

        public ModelDefinition(JsonModelDef? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Tag = source.Tag;
            Name = source.Name ?? "Unknown_Model";
            _entityDefs = ImmutableList<ModelEntityDef>.Empty.AddRange(source.EntityDefs.NotNullRange(ModelEntityDef.From));
            _enumTypeDefs = ImmutableList<ModelEnumTypeDef>.Empty.AddRange(source.EnumTypeDefs.NotNullRange(ModelEnumTypeDef.From));
        }

        public bool Equals(ModelDefinition? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return Tag == other.Tag
                   && string.Equals(Name, other.Name)
                   && _entityDefs.IsEqualTo(other._entityDefs)
                   && _enumTypeDefs.IsEqualTo(other._enumTypeDefs)
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
                hashCode = hashCode * 397 ^ _entityDefs.Count;
                foreach (var cd in _entityDefs)
                {
                    hashCode = hashCode * 397 ^ cd.GetHashCode();
                }
                hashCode = hashCode * 397 ^ _enumTypeDefs.Count;
                foreach (var ed in _enumTypeDefs)
                {
                    hashCode = hashCode * 397 ^ ed.GetHashCode();
                }

                return hashCode;
            }
        }
    }
}