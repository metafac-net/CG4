using System;

namespace MetaFac.CG4.Attributes
{
    /// <summary>
    /// Annotates a model entity with a name/value pair.
    /// </summary>
    public class TokenAttribute : Attribute
    {
        public readonly string Name;
        public readonly string Value;

        public TokenAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
