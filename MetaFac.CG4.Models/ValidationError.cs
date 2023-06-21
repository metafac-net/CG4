namespace MetaFac.CG4.Models
{
    public class ValidationError
    {
        public readonly ValidationErrorCode ErrorCode;
        public readonly string ModelName;
        public readonly TagName EntityDef;
        public readonly TagName? MemberDef;
        public readonly TagName? OtherEntityDef;
        public readonly TagName? OtherMemberDef;

        public string Message
        {
            get
            {
                return ErrorCode switch
                {
                    ValidationErrorCode.MissingEntityTag => $"{ModelName}.{EntityDef?.Name}: Entity tag is missing",
                    ValidationErrorCode.InvalidEntityTag => $"{ModelName}.{EntityDef?.Name}: Entity tag ({EntityDef?.Tag}) is invalid",
                    ValidationErrorCode.DuplicateEntityTag => $"{ModelName}.{EntityDef?.Name}: Entity tag ({EntityDef?.Tag}) is same as class: {OtherEntityDef?.Name}",
                    ValidationErrorCode.DuplicateEntityName => $"{ModelName}.{EntityDef?.Name}({EntityDef?.Tag}) has same name as: {OtherEntityDef?.Name}({OtherEntityDef?.Tag})",
                    ValidationErrorCode.MissingFieldTag => $"{ModelName}.{EntityDef?.Name}.{MemberDef?.Name}: Field tag is missing",
                    ValidationErrorCode.DuplicateFieldTag => $"{ModelName}.{EntityDef?.Name}.{MemberDef?.Name}: Field tag ({MemberDef?.Tag}) is same as field: {OtherMemberDef?.Name}",
                    ValidationErrorCode.DuplicateFieldName => $"{ModelName}.{EntityDef?.Name}.{MemberDef?.Name}({MemberDef?.Tag}): Field name is same as field: {OtherMemberDef?.Name}({OtherMemberDef?.Tag})",
                    ValidationErrorCode.UnknownFieldType => $"{ModelName}.{EntityDef?.Name}.{MemberDef?.Name}({MemberDef?.Tag}): Unknown field type: {MemberDef?.InnerType}",
                    ValidationErrorCode.CircularReference => $"{ModelName}.{EntityDef?.Name}.{MemberDef?.Name}({MemberDef?.Tag}): Circular reference to: {MemberDef?.InnerType}",
                    ValidationErrorCode.UnknownParent => $"{ModelName}.{EntityDef?.Name}({EntityDef?.Tag}): Unknown parent: {OtherEntityDef?.Name}",
                    ValidationErrorCode.RedefinedEntityTag => $"{ModelName}.{EntityDef.Name}: Entity tag ({EntityDef.Tag}) redefined by: {OtherEntityDef}",
                    ValidationErrorCode.ParentNotSupported => $"{ModelName}.{EntityDef} parent not supported: {OtherEntityDef}",
                    ValidationErrorCode.NonAbstractParent => $"{ModelName}.{EntityDef?.Name}({EntityDef?.Tag}): Non-abstract parent: {OtherEntityDef?.Name}({OtherEntityDef?.Tag})",
                    ValidationErrorCode.InvalidArrayRank => $"{ModelName}.{EntityDef?.Name}.{MemberDef?.Name}({MemberDef?.Tag}): Invalid array rank",
                    _ => $"{ModelName}.{EntityDef?.Name}.{MemberDef?.Name}: Error: {ErrorCode}.",
                };
            }
        }

        public ValidationError(ValidationErrorCode errorCode,
            string modelName, TagName entityDef, TagName? memberDef,
            TagName? otherEntityDef, TagName? otherMemberDef)
        {
            ErrorCode = errorCode;
            ModelName = modelName;
            EntityDef = entityDef;
            MemberDef = memberDef;
            OtherEntityDef = otherEntityDef;
            OtherMemberDef = otherMemberDef;
        }
    }
}