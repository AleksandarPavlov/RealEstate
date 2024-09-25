using RealEstate.Domain.Common.Enums;

namespace RealEstate.API.Contracts.Property;

public record CreateLandRequest
(
    string Name,
    PropertyListingType ListingType,
    string City, 
    string? Address,
    int Price,
    double SizeInMmSquared,
    bool IsPremium
);
