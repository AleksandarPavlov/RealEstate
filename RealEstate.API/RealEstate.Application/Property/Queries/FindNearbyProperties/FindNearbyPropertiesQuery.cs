using DomainProperty = RealEstate.Domain.Property.Property;
using MediatR;
using RealEstate.Domain.Common.Enums;

namespace RealEstate.Application.Property.Queries.FindNearbyProperties
{
    public record FindNearbyPropertiesQuery
    (
        string Lat,
        string Lon,
        int Distance,
        PropertyListingType? ListingType

    ) : IRequest<Result<IEnumerable<DomainProperty>>>;

}
