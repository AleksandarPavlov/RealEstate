
using RealEstate.Domain.Common.Enums;

namespace RealEstate.API.Contracts.Property
{
    public record FindNearbyPropertiesRequest
    (
        string Lat,
        string Lon,
        int Distance,
        PropertyListingType? ListingType
    );
}
