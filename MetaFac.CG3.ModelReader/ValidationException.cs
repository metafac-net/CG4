using System;

namespace MetaFac.CG3.ModelReader
{

    public class ValidationException : Exception
    {
        public ValidationException(ValidationError error) : base(error.Message)
        {
        }
    }
}
