
using RealEstate.Domain.Common;
using RealEstate.Domain.Common.Errors;
using System.Diagnostics.Metrics;

namespace RealEstate.Domain.Property.ValueObjects
{
    public class PropertyLocation : BaseValueObject
    {
        private PropertyLocation(string value)
        {
            Value = value;
        }

        public string Value { get; }
        public static Result<PropertyLocation> Create(string value)
        {
            return string.IsNullOrWhiteSpace(value)
               ? Result<PropertyLocation>.Failure(new Error("PropertyLocation", $"Invalid value '{value}' for PropertyLocation"))
               : Result<PropertyLocation>.Success(new PropertyLocation(value));
        }
        public override string ToString()
        {
            return Value;
        }
        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
