using System;

namespace MetaFac.CG4.TestOrg.Models.BasicTypes.Contracts
{
    internal static class BasicTypesHelpers
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
        public static bool ValueEquals(this MyCustomEnum self, in MyCustomEnum other)
        {
            return self == other;
        }
        public static bool ValueEquals(this MyCustomEnum? self, in MyCustomEnum? other)
        {
            if (self is null) return other is null;
            if (other is null) return false;
            return self.Value == other.Value;
        }
    }
}
