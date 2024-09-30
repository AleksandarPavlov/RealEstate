using DomainProperty = RealEstate.Domain.Property.Property;
using MediatR;

namespace RealEstate.Application.Property.Queries.FindNearbyProperties
{
    public record FindNearbyPropertiesQuery
    (
        string Lat,
        string Lon,
        int Distance
             
    ) : IRequest<Result<IEnumerable<DomainProperty>>>;

}
