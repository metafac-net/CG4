using MetaCode.Exceptions;
using MetaCode.Models;

namespace MetaCode.Validator
{
    internal static class Extensions
    {
        public static TagName ToTagName(this ModelClassDef classDef)
        {
            return new TagName(classDef.Tag, classDef.Name);
        }
        public static TagName ToTagName(this ModelFieldDef fieldDef)
        {
            return new TagName(fieldDef.Tag, fieldDef.Name, fieldDef.InnerType);
        }
    }
}
