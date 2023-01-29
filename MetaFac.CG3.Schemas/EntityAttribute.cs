using System;

namespace MetaFac.CG3.Schemas
{
    public class EntityAttribute : Attribute
    {
        public readonly int Tag;

        public EntityAttribute(int tag)
        {
            if (tag <= 0) throw new ArgumentOutOfRangeException(nameof(tag));
            Tag = tag;
        }
    }

}
