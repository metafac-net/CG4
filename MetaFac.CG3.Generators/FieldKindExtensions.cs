namespace MetaFac.CG3.Generators
{
    public static class FieldKindExtensions
    {
        public static bool IsModelType(this FieldKind kind) => kind.HasFlag(FieldKind.IsModelType);
        public static bool IsNullable(this FieldKind kind) => kind.HasFlag(FieldKind.IsNullable);
        public static bool IsIndexType(this FieldKind kind) => kind.HasFlag(FieldKind.IsIndexType);
        public static bool IsArrayType(this FieldKind kind) => kind.HasFlag(FieldKind.IsArrayType);
        public static bool IsBufferType(this FieldKind kind) => kind.HasFlag(FieldKind.IsBufferType);
        public static bool IsStringType(this FieldKind kind) => kind.HasFlag(FieldKind.IsStringType);
    }
}