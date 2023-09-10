using System;
namespace MetaFac.CG4.TestOrg.Models.Personel.Contracts
{
    internal static class PersonelHelpers
    {
        public static bool ValueEquals(this DayOfWeek self, in DayOfWeek other)
        {
            return self == other;
        }
        public static bool ValueEquals(this DayOfWeek? self, in DayOfWeek? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            return self.Value == other.Value;
        }
        public static bool ValueEquals(this GenderEnum self, in GenderEnum other)
        {
            return self == other;
        }
        public static bool ValueEquals(this GenderEnum? self, in GenderEnum? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            return self.Value == other.Value;
        }
    }
}
