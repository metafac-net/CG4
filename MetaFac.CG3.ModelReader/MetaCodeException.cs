using System;

namespace MetaFac.CG3.ModelReader
{
    public abstract class MetaCodeException : Exception
    {
        public MetaCodeException(string message) : base(message)
        {
        }
    }
}
