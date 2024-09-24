
using RealEstate.Domain.Common.Errors;

namespace RealEstate.Domain.Property.ValueObjects
{
    public class PropertyNumberOfRooms
    {
        private PropertyNumberOfRooms(int? value)
        {
            Value = value;
        }

        public int? Value { get; }
        public static Result<PropertyNumberOfRooms> Create(int? value)
        {
            if (!value.HasValue) { 
                return Result<PropertyNumberOfRooms>.Success(new PropertyNumberOfRooms(null));
            }
            return value < 0
               ? Result<PropertyNumberOfRooms>.Failure(new Error("PropertyNumberOfRooms", $"Invalid value '{value}' for PropertyNumberOfRooms"))
               : Result<PropertyNumberOfRooms>.Success(new PropertyNumberOfRooms(value));
        }
        public override string? ToString()
        {
            return Value.ToString();
        }
    }
}
