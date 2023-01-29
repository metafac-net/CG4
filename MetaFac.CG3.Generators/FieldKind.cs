using System;

namespace MetaFac.CG3.Generators
{
    [Flags]
    public enum FieldKind
    {
        // flags
        IsNullable = 0x01,
        IsArrayType = 0x02,
        IsModelType = 0x04,
        IsIndexType = 0x08,
        IsBufferType = 0x10,
        IsStringType = 0x20,
        // derived
        UnaryModel = IsModelType,
        ArrayModel = IsModelType + IsArrayType,
        IndexModel = IsModelType + IsArrayType + IsIndexType,
        UnaryMaybe = IsNullable,
        ArrayMaybe = IsNullable + IsArrayType,
        IndexMaybe = IsNullable + IsArrayType + IsIndexType,
        UnaryOther = 0x00,
        ArrayOther = IsArrayType,
        IndexOther = IsArrayType + IsIndexType,
        UnaryBuffer = IsBufferType,
        ArrayBuffer = IsBufferType + IsArrayType,
        IndexBuffer = IsBufferType + IsArrayType + IsIndexType,
        UnaryString = IsStringType,
        ArrayString = IsStringType + IsArrayType,
        IndexString = IsStringType + IsArrayType + IsIndexType,
    }
}