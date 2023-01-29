namespace MetaFac.CG3.ModelReader
{
    public enum ValidationErrorCode
    {
        MissingClassTag,
        InvalidClassTag,
        DuplicateClassTag,
        RedefinedClassTag,
        DuplicateClassName,
        MissingFieldTag,
        DuplicateFieldTag,
        DuplicateFieldName,
        UnknownFieldType,
        CircularReference,
        UnknownBaseClass,
        BaseClassNotSupported,
        NonAbstractBaseClass,
    }
}
