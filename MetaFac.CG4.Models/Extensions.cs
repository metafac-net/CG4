namespace MetaFac.CG4.Models
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