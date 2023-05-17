using System;

namespace MetaFac.CG4.Schemas
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MemberAttribute : Attribute
    {
        public readonly int Tag;

        public MemberAttribute(int tag)
        {
            if (tag <= 0) throw new ArgumentOutOfRangeException(nameof(tag), tag, "Must be > 0");
            Tag = tag;
        }
    }
}
