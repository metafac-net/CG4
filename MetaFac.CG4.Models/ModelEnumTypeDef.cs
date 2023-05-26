using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.Text.Json;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class ModelEnumTypeDef : IEquatable<ModelEnumTypeDef>
    {
        public readonly string Name;
        public readonly ModelItemInfo? Info;
        public readonly ModelItemState? State;
        public readonly ImmutableList<ModelEnumItemDef> EnumItemDefs;

        public ModelEnumTypeDef(string name, ModelItemInfo? info, ModelItemState? state,
            IEnumerable<ModelEnumItemDef> enumItemDefs)
        {
            Name = name;
            Info = info;
            State = state;
            EnumItemDefs = ImmutableList<ModelEnumItemDef>.Empty.AddRange(enumItemDefs);
        }

        public ModelEnumTypeDef(JsonEnumTypeDef? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Name = source.Name ?? throw new ArgumentNullException(nameof(source.Name));
            Info = source.Info is null ? null : new ModelItemInfo(source.Info);
            State = source.State is null ? null : new ModelItemState(source.State);
            EnumItemDefs = source.EnumItemDefs != null
                ? ImmutableList<ModelEnumItemDef>.Empty.AddRange(source.EnumItemDefs.Where(fd => fd != null).Select(fd => new ModelEnumItemDef(fd)))
                : ImmutableList<ModelEnumItemDef>.Empty;
        }

        public string ToJson()
        {
            var ed = new JsonEnumTypeDef(this);
            return JsonSerializer.Serialize(ed);
        }

        public static ModelEnumTypeDef FromJson(string json)
        {
            var cd = JsonSerializer.Deserialize<JsonEnumTypeDef>(json);
            return new ModelEnumTypeDef(cd);
        }

        public bool Equals(ModelEnumTypeDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Name, other.Name)
                   && Equals(Info, other.Info)
                   && Equals(State, other.State)
                   && EnumItemDefs.IsEqualTo(other.EnumItemDefs)
                   ;
        }

        public override bool Equals(object? obj)
        {
            return obj is ModelEnumTypeDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name.GetHashCode();
                hashCode = hashCode * 397 ^ (Info?.GetHashCode() ?? 0);
                hashCode = hashCode * 397 ^ (State?.GetHashCode() ?? 0);
                // ordered
                hashCode = hashCode * 397 ^ EnumItemDefs.Count;
                foreach (var field in EnumItemDefs)
                {
                    hashCode = hashCode * 397 ^ field.GetHashCode();
                }
                return hashCode;
            }
        }
    }
}