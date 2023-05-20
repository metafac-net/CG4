namespace MetaFac.CG4.Models
{
    public class ValidationError
    {
        public readonly ValidationErrorCode ErrorCode;
        public readonly string ModelName;
        public readonly TagName ModelEntityDef;
        public readonly TagName? FieldDef;
        public readonly TagName? OtherEntityDef;
        public readonly TagName? OtherFieldDef;

        public string Message
        {
            get
            {
                return ErrorCode switch
                {
                    ValidationErrorCode.MissingEntityTag => $"{ModelName}.{ModelEntityDef?.Name}: Entity tag is missing",
                    ValidationErrorCode.InvalidEntityTag => $"{ModelName}.{ModelEntityDef?.Name}: Entity tag ({ModelEntityDef?.Tag}) is invalid",
                    ValidationErrorCode.DuplicateEntityTag => $"{ModelName}.{ModelEntityDef?.Name}: Entity tag ({ModelEntityDef?.Tag}) is same as class: {OtherEntityDef?.Name}",
                    ValidationErrorCode.DuplicateEntityName => $"{ModelName}.{ModelEntityDef?.Name}({ModelEntityDef?.Tag}) has same name as: {OtherEntityDef?.Name}({OtherEntityDef?.Tag})",
                    ValidationErrorCode.MissingFieldTag => $"{ModelName}.{ModelEntityDef?.Name}.{FieldDef?.Name}: Field tag is missing",
                    ValidationErrorCode.DuplicateFieldTag => $"{ModelName}.{ModelEntityDef?.Name}.{FieldDef?.Name}: Field tag ({FieldDef?.Tag}) is same as field: {OtherFieldDef?.Name}",
                    ValidationErrorCode.DuplicateFieldName => $"{ModelName}.{ModelEntityDef?.Name}.{FieldDef?.Name}({FieldDef?.Tag}): Field name is same as field: {OtherFieldDef?.Name}({OtherFieldDef?.Tag})",
                    ValidationErrorCode.UnknownFieldType => $"{ModelName}.{ModelEntityDef?.Name}.{FieldDef?.Name}({FieldDef?.Tag}): Unknown field type: {FieldDef?.InnerType}",
                    ValidationErrorCode.CircularReference => $"{ModelName}.{ModelEntityDef?.Name}.{FieldDef?.Name}({FieldDef?.Tag}): Circular reference to: {FieldDef?.InnerType}",
                    ValidationErrorCode.UnknownParent => $"{ModelName}.{ModelEntityDef?.Name}({ModelEntityDef?.Tag}): Unknown parent: {OtherEntityDef?.Name}",
                    ValidationErrorCode.RedefinedEntityTag => $"{ModelName}.{ModelEntityDef.Name}: Entity tag ({ModelEntityDef.Tag}) redefined by: {OtherEntityDef}",
                    ValidationErrorCode.ParentNotSupported => $"{ModelName}.{ModelEntityDef} parent not supported: {OtherEntityDef}",
                    ValidationErrorCode.NonAbstractParent => $"{ModelName}.{ModelEntityDef?.Name}({ModelEntityDef?.Tag}): Non-abstract parent: {OtherEntityDef?.Name}({OtherEntityDef?.Tag})",
                    ValidationErrorCode.InvalidArrayRank => $"{ModelName}.{ModelEntityDef?.Name}.{FieldDef?.Name}({FieldDef?.Tag}): Invalid array rank",
                    _ => $"{ModelName}.{ModelEntityDef?.Name}.{FieldDef?.Name}: Error: {ErrorCode}.",
                };
            }
        }

        public ValidationError(ValidationErrorCode errorCode,
            string modelName, TagName entityDef, TagName? fieldDef,
            TagName? otherEntityDef, TagName? otherFieldDef)
        {
            ErrorCode = errorCode;
            ModelName = modelName;
            ModelEntityDef = entityDef;
            FieldDef = fieldDef;
            OtherEntityDef = otherEntityDef;
            OtherFieldDef = otherFieldDef;
        }
    }
}