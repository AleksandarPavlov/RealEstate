
using MediatR;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Queries.FetchLatestProperties
{
    public record FetchLatestPropertiesQuery(int Amount) : IRequest<Result<IEnumerable<DomainProperty>>>;
  
}
