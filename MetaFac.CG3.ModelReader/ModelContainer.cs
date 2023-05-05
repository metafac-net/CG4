using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;

namespace MetaFac.CG3.ModelReader
{

    public sealed class ModelContainer : IEquatable<ModelContainer>
    {
        public readonly ImmutableList<ModelDefinition> ModelDefs;
        public readonly ImmutableDictionary<string, string> Tokens;

        public ModelContainer(ModelDefinition modelDef, IEnumerable<KeyValuePair<string, string>>? tokens = null)
        {
            if (modelDef is null) throw new ArgumentNullException(nameof(modelDef));
            ModelDefs = ImmutableList<ModelDefinition>.Empty.Add(modelDef);
            Tokens = tokens != null
                ? ImmutableDictionary<string, string>.Empty.AddRange(tokens)
                : ImmutableDictionary<string, string>.Empty;
        }

        public ModelContainer(IEnumerable<ModelDefinition>? modelDefs = null, IEnumerable<KeyValuePair<string, string>>? tokens = null)
        {
            if (modelDefs is null) throw new ArgumentNullException(nameof(modelDefs));
            ModelDefs = ImmutableList<ModelDefinition>.Empty.AddRange(modelDefs.Where(m => m != null));
            Tokens = tokens != null
                ? ImmutableDictionary<string, string>.Empty.AddRange(tokens)
                : ImmutableDictionary<string, string>.Empty;
        }

        public ModelContainer(JsonMetadata? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            ModelDefs = source.ModelDefs != null
                ? ImmutableList<ModelDefinition>.Empty.AddRange(source.ModelDefs.Where(md => md != null).Select(md => new ModelDefinition(md)))
                : ImmutableList<ModelDefinition>.Empty;
            Tokens = source.Tokens != null
                ? ImmutableDictionary<string, string>.Empty.AddRange(source.Tokens)
                : ImmutableDictionary<string, string>.Empty;
        }

        public bool Equals(ModelContainer? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return ModelDefs.IsEqualTo(other.ModelDefs)
                && Tokens.IsEqualTo(other.Tokens);
        }

        public override bool Equals(object? obj)
        {
            return obj is ModelContainer other && Equals(other);
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (var model in ModelDefs)
            {
                hashCode = hashCode * 397 ^ model.GetHashCode();
            }
            // order ignored
            foreach (var kvp in Tokens)
            {
                hashCode = hashCode ^ kvp.Key.GetHashCode();
                if (kvp.Value != null) hashCode = hashCode ^ kvp.Value.GetHashCode();
            }
            return hashCode;
        }

        public string ToJson(bool writeIndented = false)
        {
            var md = new JsonMetadata(this);
            var options = new JsonSerializerOptions() { WriteIndented = writeIndented };
            return JsonSerializer.Serialize(md, options);
        }

        public static ModelContainer FromJson(string? json)
        {
            if (json is null) throw new ArgumentNullException(nameof(json));
            var md = JsonSerializer.Deserialize<JsonMetadata>(json);
            return new ModelContainer(md);
        }

    }
}
