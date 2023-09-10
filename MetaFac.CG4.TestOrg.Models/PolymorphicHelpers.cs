namespace MetaFac.CG4.TestOrg.Models.Polymorphic.Contracts
{
    internal static class PolymorphicHelpers
    {
        public static bool ValueEquals(this CustomEnum self, in CustomEnum other)
        {
            return self == other;
        }
        public static bool ValueEquals(this CustomEnum? self, in CustomEnum? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            return self.Value == other.Value;
        }
    }
}
