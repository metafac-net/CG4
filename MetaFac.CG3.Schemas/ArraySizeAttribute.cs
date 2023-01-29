using System;

namespace MetaFac.CG3.Schemas
{
    public class ArraySizeAttribute : Attribute
    {
        public readonly int ArraySize;

        public ArraySizeAttribute(int arraySize = 0)
        {
            if (arraySize < 0) throw new ArgumentOutOfRangeException(nameof(arraySize), arraySize, null);
            ArraySize = arraySize;
        }
    }
}
