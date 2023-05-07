using System.Collections.Immutable;

namespace MetaFac.CG4.Models
{
    public class ValidationResult
    {
        public bool HasErrors => Errors.Count > 0;
        public bool HasWarnings => Warnings.Count > 0;

        public readonly ValidationErrorHandling ErrorHandling;
        public readonly ImmutableList<ValidationError> Errors;
        public readonly ImmutableList<ValidationError> Warnings;

        public static ValidationResult Init(ValidationErrorHandling errorHandling)
        {
            return new ValidationResult(errorHandling);
        }

        private ValidationResult(ValidationErrorHandling errorHandling)
        {
            ErrorHandling = errorHandling;
            Errors = ImmutableList<ValidationError>.Empty;
            Warnings = ImmutableList<ValidationError>.Empty;
        }

        private ValidationResult(ValidationErrorHandling errorHandling, ImmutableList<ValidationError> errors, ImmutableList<ValidationError> warnings)
        {
            ErrorHandling = errorHandling;
            Errors = errors;
            Warnings = warnings;
        }

        public ValidationResult AddError(ValidationError error)
        {
            if (ErrorHandling == ValidationErrorHandling.ThrowOnFirst)
                throw new ValidationException(error);
            return new ValidationResult(ErrorHandling, Errors.Add(error), Warnings);
        }
        public ValidationResult AddWarning(ValidationError error)
        {
            return new ValidationResult(ErrorHandling, Errors, Warnings.Add(error));
        }
    }
}