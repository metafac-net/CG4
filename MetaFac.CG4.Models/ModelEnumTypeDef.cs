using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.Text.Json;
using System.Linq;
using System.Diagnostics;

namespace MetaFac.CG4.Models
{
    internal static class ModelHelpers
    {
        public static IEnumerable<TTarget> NotNullRange<TSource, TTarget>(this IEnumerable<TSource>? source, Func<TSource, TTarget?> converter)
        {
            if (source is not null)
            {
                foreach (var item in source)
                {
                    TTarget? target = converter(item);
                    if (target is not null)
                    {
                        yield return target;
                    }
                }
            }
        }
    }

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

        public static ModelEnumTypeDef? From(JsonEnumTypeDef? source)
        {
            if (source is null) return null;
            return new ModelEnumTypeDef(
                source.Name ?? throw new ArgumentNullException(nameof(source.Name)),
                ModelItemInfo.From(source.Info),
                ModelItemState.From(source.State),
                source.EnumItemDefs.NotNullRange(ModelEnumItemDef.From));
        }

        public string ToJson()
        {
            var ed = new JsonEnumTypeDef(this);
            return JsonSerializer.Serialize(ed);
        }

        public static ModelEnumTypeDef? FromJson(string json)
        {
            var cd = JsonSerializer.Deserialize<JsonEnumTypeDef>(json);
            return ModelEnumTypeDef.From(cd);
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