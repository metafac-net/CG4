﻿using System.Collections.Generic;
using System;
using System.Linq;

namespace MetaFac.CG4.Models
{
    public class JsonEnumTypeDef : IEquatable<JsonEnumTypeDef>
    {
        public string? Name { get; set; }
        public List<JsonEnumItemDef>? EnumItemDefs { get; set; }

        public JsonEnumTypeDef() { }

        public JsonEnumTypeDef(ModelEnumTypeDef source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Name = source.Name;
            EnumItemDefs = source.EnumItemDefs.Select(fd => new JsonEnumItemDef(fd)).ToList();
        }

        public bool Equals(JsonEnumTypeDef? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;
            return string.Equals(Name, other.Name)
                   && EnumItemDefs.IsEqualTo(other.EnumItemDefs)
                   ;
        }

        public override bool Equals(object? obj)
        {
            return obj is JsonEnumTypeDef other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Name?.GetHashCode() ?? 0;
                // ordered
                if (EnumItemDefs != null)
                {
                    hashCode = hashCode * 397 ^ EnumItemDefs.Count;
                    foreach (var fd in EnumItemDefs)
                    {
                        hashCode = hashCode * 397 ^ fd.GetHashCode();
                    }
                }
                return hashCode;
            }
        }
    }
}
