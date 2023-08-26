namespace MetaFac.CG4.Models
{
    internal static class Extensions
    {
        public static TagName ToTagName(this ModelEntityDef entityDef)
        {
            return new TagName(entityDef.Tag, entityDef.Name);
        }

        public static TagName ToTagName(this ModelMemberDef memberDef)
        {
            return new TagName(memberDef.Tag, memberDef.Name, memberDef.InnerType);
        }
    }
}