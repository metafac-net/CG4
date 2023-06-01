using System;
using System.Collections.Generic;
using System.Text;

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

    /// <summary>
    /// Marks a type in the model as a proxy for an external type.
    /// </summary>
    public class ProxyAttribute : Attribute
    {
        public readonly string ExternalName;
        public readonly string ConcreteName;

        public ProxyAttribute(string externalName, string concreteName)
        {
            ExternalName = externalName;
            ConcreteName = concreteName;
        }
    }
}
