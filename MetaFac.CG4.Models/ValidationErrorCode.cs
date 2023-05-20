namespace MetaFac.CG4.Models
{
    public enum ValidationErrorCode
    {
        MissingEntityTag,
        InvalidEntityTag,
        DuplicateEntityTag,
        RedefinedEntityTag,
        DuplicateEntityName,
        MissingFieldTag,
        DuplicateFieldTag,
        DuplicateFieldName,
        UnknownFieldType,
        CircularReference,
        UnknownParent,
        ParentNotSupported,
        NonAbstractParent,
        InvalidArrayRank,
    }
}