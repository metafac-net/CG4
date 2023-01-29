namespace MetaCode.Exceptions
{

    public class ValidationException : MetaCodeException
    {
        public ValidationException(ValidationError error) : base(error.Message)
        {
        }
    }
}
