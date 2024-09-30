
using RealEstate.Domain.Common.Errors;

namespace RealEstate.Domain.Property.ValueObjects
{
    public class PropertyDescription
    {
        private PropertyDescription(string? value)
        {
            Value = value;
        }

        public string? Value { get; }
        public static Result<PropertyDescription> Create(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) { 
                return Result<PropertyDescription>.Success(new PropertyDescription(null));
            }

            return value.Length > 200
               ? Result<PropertyDescription>.Failure(new Error("PropertyDescription", $"Maximum number of characters (200) reached for PropertyDescription"))
               : Result<PropertyDescription>.Success(new PropertyDescription(value));
        }
        public override string? ToString()
        {
            return Value;
        }
    }
}
