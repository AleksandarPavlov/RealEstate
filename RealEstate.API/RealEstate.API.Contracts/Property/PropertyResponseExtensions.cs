
using RealEstate.API.Contracts.Advertiser;
using RealEstate.API.Contracts.Coordinates;
using RealEstate.Domain.Common.Enums;
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
                property.PropertyStatus,
                property.Location.City,
                property.Location.Address,
                property.Price.Value,
                property.SizeInMmSquared.Value,
                property.CreationTime,
                property.IsPremium,
                property.IsFurnished,
                property.FloorNumber,
                property.NumberOfRooms?.Value,
                CoordinatesResponseExtensions.ToContract(property.Coordinates),
                AdvertiserResponseExtension.ToContract(property.Advertiser),
                property.Images,
                property.Description?.Value,
                property.ListingType == PropertyListingType.SELL
                ? (int?)(property.Price.Value / property.SizeInMmSquared.Value)
                : null
            );
        
        }
    }
}
