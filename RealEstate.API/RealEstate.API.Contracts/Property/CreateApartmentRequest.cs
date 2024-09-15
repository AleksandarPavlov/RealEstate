
using RealEstate.Domain.Common.Enums;

namespace RealEstate.API.Contracts.Property
{
    public record CreateApartmentRequest
    (
        string name,
        PropertyListingType listingType,
        string location,
        int price,
        double sizeInMmSquared,
        bool? isFurnished,
        string? floorNumber,
        int? numberOfRooms
    );

}

