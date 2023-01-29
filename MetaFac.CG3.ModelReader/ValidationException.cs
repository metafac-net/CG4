namespace MetaFac.CG3.ModelReader
{

    public class ValidationException : MetaCodeException
    {
        public ValidationException(ValidationError error) : base(error.Message)
        {
        }
    }
}
