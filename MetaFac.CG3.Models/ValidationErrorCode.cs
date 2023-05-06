namespace MetaFac.CG3.Models
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