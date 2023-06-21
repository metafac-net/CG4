using System.Collections.Generic;
using System;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class JsonMetadata : IEquatable<JsonMetadata>
    {
        public List<JsonModelDef>? ModelDefs { get; set; }

        public Dictionary<string, string>? Tokens { get; set; }

        public JsonMetadata() { }

        public JsonMetadata(ModelContainer source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            ModelDefs = source.ModelDefs.Select(md => new JsonModelDef(md)).ToList();
            Tokens = new Dictionary<string, string>(source.Tokens);
        }

        public bool Equals(JsonMetadata? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return ModelDefs.IsEqualTo(other.ModelDefs)
                && Tokens.IsEqualTo(other.Tokens);
        }

        public override bool Equals(object? obj)
        {
            return obj is JsonMetadata other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                // order sensitive
                if (ModelDefs != null)
                {
                    hashCode = hashCode * 397 ^ ModelDefs.Count;
                    for (int i = 0; i < ModelDefs.Count; i++)
                    {
                        hashCode = hashCode * 397 ^ ModelDefs[i].GetHashCode();
                    }
                }
                // order ignored
                if (Tokens != null)
                {
                    hashCode = hashCode * 397 ^ Tokens.Count;
                    foreach (var kvp in Tokens)
                    {
                        hashCode = hashCode ^ kvp.Key.GetHashCode();
                        if (kvp.Value != null) hashCode = hashCode ^ kvp.Value.GetHashCode();
                    }
                }
                return hashCode;
            }
        }
    }
}