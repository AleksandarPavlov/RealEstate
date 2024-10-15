using RealEstate.Domain.Common.Enums;

namespace RealEstate.Domain.Services;

public interface IOpenAiService
{
    Task<Result<string?>> GeneratePropertyDescription(string address, string size, PropertyListingType listingType, PropertyType propertyType);
}