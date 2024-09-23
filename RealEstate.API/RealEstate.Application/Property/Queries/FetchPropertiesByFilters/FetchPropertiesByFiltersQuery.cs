
using MediatR;
using RealEstate.Domain.Common.Enums;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Queries.FetchPropertiesByFilters
{
    public record FetchPropertiesByFiltersQuery
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
        ) : IRequest<Result<IEnumerable<DomainProperty>>>;
}
