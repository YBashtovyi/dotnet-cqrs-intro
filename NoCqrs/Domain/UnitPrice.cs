using System;

namespace NoCqrs.Domain
{
    public class UnitPrice
    {
        public decimal Value { get; private set; }
        public TimeSpan Unit { get; private set; }

        public UnitPrice(decimal value, TimeSpan unit)
        {
            Value = value;
            Unit = unit;
        }

        public decimal Multiply(TimeSpan qt)
        {
            return (qt.Days / qt.Days) * Value;
        }
    }
}