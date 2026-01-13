
using RealEstate.Domain.Common.Errors;

namespace RealEstate.Domain.Property.ValueObjects
{
    public class PropertyLocation
    {
        private PropertyLocation(string city, string? address)
        {
            City = city;
            Address = address;
        }

        public string City { get; }
        public string? Address { get; }
        public static Result<PropertyLocation> Create(string city, string? address)
        {
            return string.IsNullOrWhiteSpace(city)
               ? Result<PropertyLocation>.Failure(new Error("PropertyLocation", $"Invalid value '{city}' and '{address}' for PropertyLocation"))
               : Result<PropertyLocation>.Success(new PropertyLocation(city, address));
        }
        public override string ToString()
        {
            return Address + ", " + City;
        }

    }
}
