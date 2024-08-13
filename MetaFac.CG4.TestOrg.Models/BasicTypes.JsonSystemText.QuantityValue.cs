using LabApps.Units;
using System;

namespace MetaFac.CG4.TestOrg.Models.BasicTypes.JsonSystemText
{
    public struct QuantityValue : IEquatable<QuantityValue>
    {
        public double Amount { get; set; }

        public long Code { get; set; }

        public QuantityValue()
        {
        }

        public QuantityValue(double amount, long code)
        {
            Amount = amount;
            Code = code;
        }

        public QuantityValue(Quantity value)
        {
            Amount = value.Amount;
            Code = value.Unit.Code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code, Amount);
        }

        public override bool Equals(object? obj)
        {
            return obj is QuantityValue other && Equals(other);
        }

        public bool Equals(QuantityValue other)
        {
            return other.Amount.Equals(Amount)
                && other.Code.Equals(Code);
        }

        public static bool operator ==(QuantityValue left, QuantityValue right) => left.Equals(right);
        public static bool operator !=(QuantityValue left, QuantityValue right) => !left.Equals(right);

        public static implicit operator QuantityValue(Quantity value) => new QuantityValue(value);

        public static implicit operator Quantity(QuantityValue value) => new Quantity(value.Amount, new Unit(value.Code));
    }

    public static class QuantityValueConverters
    {
        public static Quantity ToExternal(this QuantityValue value) => new Quantity(value.Amount, new Unit(value.Code));
        public static Quantity? ToExternal(this QuantityValue? value) => value is null ? null : new Quantity(value.Value.Amount, new Unit(value.Value.Code));
        public static QuantityValue ToInternal(this Quantity value) => new QuantityValue(value);
        public static QuantityValue? ToInternal(this Quantity? value) => value is null ? null : new QuantityValue(value.Value);
    }
}
