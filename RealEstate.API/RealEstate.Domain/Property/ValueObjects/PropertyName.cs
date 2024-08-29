
using RealEstate.Domain.Common.Errors;

namespace RealEstate.Domain.Property.ValueObjects
{
    public class PropertyName
    {
        private PropertyName(string value)
        {
            Value = value;
        }

        public string Value { get; }
        public static Result<PropertyName> Create(string value)
        {
            return string.IsNullOrWhiteSpace(value)
               ? Result<PropertyName>.Failure(new Error("PropertyName", $"Invalid value '{value}' for PropertyName"))
               : Result<PropertyName>.Success(new PropertyName(value));
        }
        public override string ToString()
        {
            return Value;
        }
    }
}
