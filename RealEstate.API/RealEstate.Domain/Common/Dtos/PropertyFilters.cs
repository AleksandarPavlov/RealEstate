
using RealEstate.Domain.Common.Enums;

namespace RealEstate.Application.Property.Dtos
{
    public record PropertyFilters
        (
        string? City,
        PropertyListingType? ListingType,
        PropertyType? PropertyType,
        double? SizeFrom,
        int? PriceTo,
        bool? GroundFloor,
        int? NumberOfRooms,
        int? Page = 0,
        int? PageSize = 10
        );
}
