using System;

namespace MetaCode.Exceptions
{
    public abstract class MetaCodeException : Exception
    {
        public MetaCodeException(string message) : base(message)
        {
        }
    }
}
