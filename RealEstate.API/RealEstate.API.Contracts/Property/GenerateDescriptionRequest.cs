using RealEstate.Domain.Common.Enums;

namespace RealEstate.API.Contracts.Property;

    public record GenerateDescriptionRequest
    (
        string Address,
        string Size,
        PropertyType PropertyType,
        PropertyListingType ListingType
    
    );