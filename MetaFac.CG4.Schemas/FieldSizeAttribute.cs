using System;

namespace MetaFac.CG4.Schemas
{
    public class FieldSizeAttribute : Attribute
    {
        public readonly int FieldSize;

        public FieldSizeAttribute(int fieldSize = 0)
        {
            if (fieldSize < 0) throw new ArgumentOutOfRangeException(nameof(fieldSize), fieldSize, null);
            FieldSize = fieldSize;
        }
    }
}
