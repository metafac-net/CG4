using System;
using System.Collections.Generic;

namespace MetaFac.CG4.ModelReader
{
    internal class EntityDefInfo
    {
        public readonly Type Type;
        public readonly int? Tag;

        public EntityDefInfo(Type type, int? tag)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Tag = tag;
        }
    }
}
