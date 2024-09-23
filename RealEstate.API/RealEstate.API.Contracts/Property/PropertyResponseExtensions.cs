
using RealEstate.API.Contracts.Coordinates;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.API.Contracts.Property
{
    public static class PropertyResponseExtensions
    {
        public static PropertyResponse ToContract(DomainProperty property)
        {
            return new PropertyResponse
            (
                property.Id,
                property.Name.Value,
                property.ListingType,
                property.Type,
                property.Location.Value,
                property.Price.Value,
                property.SizeInMmSquared.Value,
                property.IsPremium,
                property.IsFurnished,
                property.FloorNumber,
                property.NumberOfRooms?.Value ?? null,
                CoordinatesResponseExtensions.ToContract(property.Coordinates)
            );
        
        }
    }
}
