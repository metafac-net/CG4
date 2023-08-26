using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class ModelDefinition : IEquatable<ModelDefinition>
    {
        public readonly string Name;
        public readonly int? Tag;
        public readonly ImmutableDictionary<string, string> Tokens;
        private readonly ImmutableList<ModelEntityDef> _entityDefs;
        private readonly ImmutableList<ModelEnumTypeDef> _enumTypeDefs;

        public ImmutableList<ModelEntityDef> AllEntityDefs => _entityDefs;
        public IEnumerable<ModelEntityDef> EntityDefs => _entityDefs.Where(ed => !ed.IsRedacted);

        public ImmutableList<ModelEnumTypeDef> AllEnumTypeDefs => _enumTypeDefs;
        public IEnumerable<ModelEnumTypeDef> EnumTypeDefs => _enumTypeDefs.Where(etd => !etd.IsRedacted);

        private ModelDefinition(string name, int? tag, ImmutableList<ModelEntityDef> entityDefs, ImmutableList<ModelEnumTypeDef> enumTypeDefs, ImmutableDictionary<string, string> tokens)
        {
            Name = name;
            Tag = tag;
            Tokens = tokens;
            _entityDefs = entityDefs;
            _enumTypeDefs = enumTypeDefs;
        }

        private static IEnumerable<ModelEntityDef> DescendentsOf(string entityName, IImmutableList<ModelEntityDef> entityDefs)
        {
            foreach (var entityDef in entityDefs)
            {
                if (entityDef.ParentName == entityName)
                    yield return entityDef;
            }
        }

        private static IEnumerable<ModelEntityDef> AllDescendentsOf(string entityName, IImmutableList<ModelEntityDef> entityDefs)
        {
            foreach (var entityDef in DescendentsOf(entityName, entityDefs))
            {
                yield return entityDef;
                foreach (var derived in AllDescendentsOf(entityDef.Name, entityDefs))
                {
                    yield return derived;
                }
            }
        }

        private static ImmutableList<ModelEntityDef> FixEntityHierarchy(ImmutableList<ModelEntityDef> sourceEntities)
        {
            // derive class hierarchy
            var updatedEntities = ImmutableList<ModelEntityDef>.Empty.ToBuilder();
            foreach (var entityDef in sourceEntities)
            {
                var allDescendents = AllDescendentsOf(entityDef.Name, sourceEntities);
                var updatedEntityDef = entityDef.SetAllDescendents(allDescendents);
                updatedEntities.Add(updatedEntityDef);
            }

            return updatedEntities.ToImmutable();
        }

        public ModelDefinition(string modelName, int? tag,
            IEnumerable<ModelEntityDef>? entityDefs = null,
            IEnumerable<ModelEnumTypeDef>? enumTypeDefs = null,
            IEnumerable<KeyValuePair<string, string>>? tokens = null)
        {
            Name = modelName;
            Tag = tag;
            var newEntityDefs = entityDefs != null
                ? ImmutableList<ModelEntityDef>.Empty.AddRange(entityDefs.Where(cd => cd != null))
                : ImmutableList<ModelEntityDef>.Empty;
            _entityDefs = FixEntityHierarchy(newEntityDefs);
            _enumTypeDefs = enumTypeDefs != null
                ? ImmutableList<ModelEnumTypeDef>.Empty.AddRange(enumTypeDefs.Where(cd => cd != null))
                : ImmutableList<ModelEnumTypeDef>.Empty;
            Tokens = tokens is null
                ? ImmutableDictionary<string, string>.Empty
                : ImmutableDictionary<string, string>.Empty.AddRange(tokens);
        }

        public ModelDefinition(JsonModelDef? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Tag = source.Tag;
            Name = source.Name ?? "Unknown_Model";
            var newEntityDefs = ImmutableList<ModelEntityDef>.Empty.AddRange(source.EntityDefs.NotNullRange(ModelEntityDef.From));
            _entityDefs = FixEntityHierarchy(newEntityDefs);
            _enumTypeDefs = ImmutableList<ModelEnumTypeDef>.Empty.AddRange(source.EnumTypeDefs.NotNullRange(ModelEnumTypeDef.From));
            Tokens = source.Tokens is null
                ? ImmutableDictionary<string, string>.Empty
                : ImmutableDictionary<string, string>.Empty.AddRange(source.Tokens);
        }

        public bool Equals(ModelDefinition? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return Tag == other.Tag
                   && string.Equals(Name, other.Name)
                   && _entityDefs.IsEqualTo(other._entityDefs)
                   && _enumTypeDefs.IsEqualTo(other._enumTypeDefs)
                   && Tokens.IsEqualTo(other.Tokens)
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
                // order ignored
                foreach (var kvp in Tokens)
                {
                    hashCode = hashCode ^ kvp.Key.GetHashCode();
                    if (kvp.Value != null) hashCode = hashCode ^ kvp.Value.GetHashCode();
                }
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