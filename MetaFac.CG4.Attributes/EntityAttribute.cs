﻿using System;

namespace MetaFac.CG4.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class EntityAttribute : Attribute
    {
        public readonly int Tag;

        public EntityAttribute(int tag)
        {
            if (tag <= 0) throw new ArgumentOutOfRangeException(nameof(tag), tag, "Must be > 0");
            Tag = tag;
        }
    }
}