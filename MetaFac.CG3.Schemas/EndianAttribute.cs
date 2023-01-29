using System;

namespace MetaFac.CG3.Schemas
{
    public class EndianAttribute : Attribute
    {
        public readonly bool BigEndian;

        public EndianAttribute(bool bigEndian = false)
        {
            BigEndian = bigEndian;
        }
    }
}
