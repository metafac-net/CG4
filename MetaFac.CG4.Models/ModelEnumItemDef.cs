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

        public static ModelEnumItemDef? From(JsonEnumItemDef? source)
        {
            if (source is null) return null;
            return new ModelEnumItemDef(
                source.Name ?? throw new ArgumentNullException(nameof(source.Name)),
                source.Value,
                ModelItemInfo.From(source.Info),
                ModelItemState.From(source.State));
        }

        public bool TryGetSummary(out string summary)
        {
            summary = string.Empty;
            if (Info is null) return false;
            if (Info.Summary is null) return false;
            summary = Info.Summary;
            return true;
        }

        public bool IsObsolete(out string reason, out bool isError)
        {
            reason = string.Empty;
            isError = false;
            if (State is null) return false;
            if (!State.IsObsolete) return false;
            reason = State.Reason ?? "Deprecated";
            isError = State.IsError;
            return true;
        }

        public string ToJson()
        {
            var member = new JsonEnumItemDef(this);
            return JsonSerializer.Serialize(member);
        }

        public static ModelEnumItemDef? FromJson(string json)
        {
            var member = JsonSerializer.Deserialize<JsonEnumItemDef>(json);
            return ModelEnumItemDef.From(member);
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