namespace MetaFac.CG4.Models
{
    internal static class Extensions
    {
        public static TagName ToTagName(this ModelEntityDef entityDef)
        {
            return new TagName(entityDef.Tag, entityDef.Name);
        }
        public static TagName ToTagName(this ModelFieldDef fieldDef)
        {
            return new TagName(fieldDef.Tag, fieldDef.Name, fieldDef.InnerType);
        }
    }
}