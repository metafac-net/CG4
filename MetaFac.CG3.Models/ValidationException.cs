using System;

namespace MetaFac.CG3.Models
{
    public class ValidationException : Exception
    {
        public ValidationException(ValidationError error) : base(error.Message)
        {
        }
    }
}