using System;

namespace MetaFac.CG4.Models
{
    public class ValidationException : Exception
    {
        public ValidationException(ValidationError error) : base(error.Message)
        {
        }
    }
}