
using RealEstate.Domain.Common.Errors;

namespace RealEstate.Domain.Property.ValueObjects
{
    public class PropertyPrice
    {
        private PropertyPrice(int value)
        {
            Value = value;
        }

        public int Value { get; }
        public static Result<PropertyPrice> Create(int value)
        {
            return value < 0 
               ? Result<PropertyPrice>.Failure(new Error("PropertyPrice", $"Invalid value '{value}' for PropertyPrice"))
               : Result<PropertyPrice>.Success(new PropertyPrice(value));
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
