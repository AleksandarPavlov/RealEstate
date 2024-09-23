
using RealEstate.Domain.Common.Enums;

namespace RealEstate.API.Contracts.Property;

public record PropertiesByFilterRequest
(
    string? City,
    PropertyListingType? ListingType,
    PropertyType? PropertyType,
    double? SizeFrom,
    int? PriceTo,
    bool? GroundFloor,
    int? NumberOfRooms,
    int Page = 0,
    int PageSize = 10        
);

