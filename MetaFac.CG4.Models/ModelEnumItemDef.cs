using System;
using System.Text.Json;

namespace MetaFac.CG4.Models
{
    public class ModelEnumItemDef : IEquatable<ModelEnumItemDef>
    {
        public readonly string Name;
        public readonly int Value;
        public readonly ModelItemInfo? Info;
        public readonly ModelItemState? State;

        public ModelEnumItemDef(string name, int value, ModelItemInfo? info, ModelItemState? state = null)
        {
            Name = name;
            Value = value;
            Info = info;
            State = state;
        }

        public ModelEnumItemDef(JsonEnumItemDef? source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Name = source.Name ?? throw new ArgumentNullException(nameof(source.Name));
            Value = source.Value;
            Info = source.Info is null ? null : new ModelItemInfo(source.Info);
            State = source.State is null ? null : new ModelItemState(source.State);
        }

        public string ToJson()
        {
            var member = new JsonEnumItemDef(this);
            return JsonSerializer.Serialize(member);
        }

        public static ModelEnumItemDef FromJson(string json)
        {
            var member = JsonSerializer.Deserialize<JsonEnumItemDef>(json);
            return new ModelEnumItemDef(member);
        }

        public bool Equals(ModelEnumItemDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Name, other.Name)
                   && Value == other.Value
                   && Equals(Info, other.Info)
                   && Equals(State, other.State)
                   ;
        }

        public override bool Equals(object? obj) => obj is ModelEnumItemDef other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Name, Value, Info, State);
    }
}