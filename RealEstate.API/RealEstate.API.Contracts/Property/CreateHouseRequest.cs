using RealEstate.Domain.Common.Enums;

namespace RealEstate.API.Contracts.Property;

public record CreateHouseRequest
(
     string Name,
     PropertyListingType ListingType,
     string Location,
     int Price,
     double SizeInMmSquared,
     bool IsPremium,
     bool IsFurnished,
     string FloorNumber,
     int NumberOfRooms
);
