
using RealEstate.API.Contracts.Coordinates;
using RealEstate.Domain.Common.Enums;

namespace RealEstate.API.Contracts.Property;

public record PropertyResponse
(
    long Id,
    string Name,
    PropertyListingType ListingType,
    PropertyType Type,
    string City,
    string? Address,
    int Price,
    double SizeInMmSquared,
    bool IsPremium,
    bool? IsFurnished,
    string? FloorNumber,
    int? NumberOfRooms,
    CoordinatesResponse? Coordinates,
    IEnumerable<string>? Images
);


