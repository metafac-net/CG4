namespace MetaFac.CG3.ModelReader
{
    public class ValidationError
    {
        public readonly ValidationErrorCode ErrorCode;
        public readonly string ModelName;
        public readonly TagName ModelClassDef;
        public readonly TagName? FieldDef;
        public readonly TagName? OtherClassDef;
        public readonly TagName? OtherFieldDef;

        public string Message
        {
            get
            {
                return ErrorCode switch
                {
                    ValidationErrorCode.MissingClassTag => $"{ModelName}.{ModelClassDef?.Name}: Class tag is missing",
                    ValidationErrorCode.InvalidClassTag => $"{ModelName}.{ModelClassDef?.Name}: Class tag ({ModelClassDef?.Tag}) is invalid",
                    ValidationErrorCode.DuplicateClassTag => $"{ModelName}.{ModelClassDef?.Name}: Class tag ({ModelClassDef?.Tag}) is same as class: {OtherClassDef?.Name}",
                    ValidationErrorCode.DuplicateClassName => $"{ModelName}.{ModelClassDef?.Name}({ModelClassDef?.Tag}) has same name as: {OtherClassDef?.Name}({OtherClassDef?.Tag})",
                    ValidationErrorCode.MissingFieldTag => $"{ModelName}.{ModelClassDef?.Name}.{FieldDef?.Name}: Field tag is missing",
                    ValidationErrorCode.DuplicateFieldTag => $"{ModelName}.{ModelClassDef?.Name}.{FieldDef?.Name}: Field tag ({FieldDef?.Tag}) is same as field: {OtherFieldDef?.Name}",
                    ValidationErrorCode.DuplicateFieldName => $"{ModelName}.{ModelClassDef?.Name}.{FieldDef?.Name}({FieldDef?.Tag}): Field name is same as field: {OtherFieldDef?.Name}({OtherFieldDef?.Tag})",
                    ValidationErrorCode.UnknownFieldType => $"{ModelName}.{ModelClassDef?.Name}.{FieldDef?.Name}({FieldDef?.Tag}): Unknown field type: {FieldDef?.InnerType}",
                    ValidationErrorCode.CircularReference => $"{ModelName}.{ModelClassDef?.Name}.{FieldDef?.Name}({FieldDef?.Tag}): Circular reference to: {FieldDef?.InnerType}",
                    ValidationErrorCode.UnknownBaseClass => $"{ModelName}.{ModelClassDef?.Name}({ModelClassDef?.Tag}): Unknown base class: {OtherClassDef?.Name}",
                    ValidationErrorCode.RedefinedClassTag => $"{ModelName}.{ModelClassDef.Name}: Class tag ({ModelClassDef.Tag}) redefined by: {OtherClassDef}",
                    ValidationErrorCode.BaseClassNotSupported => $"{ModelName}.{ModelClassDef} base class not supported: {OtherClassDef}",
                    ValidationErrorCode.NonAbstractBaseClass => $"{ModelName}.{ModelClassDef?.Name}({ModelClassDef?.Tag}): Non-abstract base class: {OtherClassDef?.Name}({OtherClassDef?.Tag})",
                    _ => $"{ModelName}.{ModelClassDef?.Name}.{FieldDef?.Name}: Error: {ErrorCode}.",
                };
            }
        }

        public ValidationError(ValidationErrorCode errorCode,
            string modelName, TagName classDef, TagName? fieldDef,
            TagName? otherClassDef, TagName? otherFieldDef)
        {
            ErrorCode = errorCode;
            ModelName = modelName;
            ModelClassDef = classDef;
            FieldDef = fieldDef;
            OtherClassDef = otherClassDef;
            OtherFieldDef = otherFieldDef;
        }
    }
}
