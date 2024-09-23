
using RealEstate.Domain.Common.Errors;

namespace RealEstate.Domain.Property.ValueObjects
{
    public class PropertySize
    {
        private PropertySize(double value)
        {
            Value = value;
        }

        public double Value { get; }
        public static Result<PropertySize> Create(double value)
        {
            return value < 0
               ? Result<PropertySize>.Failure(new Error("PropertySize", $"Invalid value '{value}' for PropertySize"))
               : Result<PropertySize>.Success(new PropertySize(value));
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
