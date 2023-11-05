using System;

namespace MetaFac.CG4.Models
{
    public class ValidationException : Exception
    {
        public ValidationError ValidationError { get; }
        public ValidationException(ValidationError error) : base(error.Message)
        {
            ValidationError = error;
        }
    }
}