﻿using System;

namespace MetaFac.CG4.Models
{
    public class JsonEnumItemDef : IEquatable<JsonEnumItemDef>
    {
        public string? Name { get; set; }
        public int Value { get; set; }
        public string? Summary { get; set; }
        public JsonItemState? State { get; set; }

        public JsonEnumItemDef() { }

        public JsonEnumItemDef(ModelEnumItemDef source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Name = source.Name;
            Value = source.Value;
            Summary = source.Summary;
            State = JsonItemState.From(source.State);
        }

        public bool Equals(JsonEnumItemDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Name, other.Name)
                   && Value == other.Value
                   && string.Equals(Summary, other.Summary)
                   && Equals(State, other.State)
                   ;
        }

        public override bool Equals(object? obj)
        {
            return obj is JsonEnumItemDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Value, Summary, State);
        }
    }
}