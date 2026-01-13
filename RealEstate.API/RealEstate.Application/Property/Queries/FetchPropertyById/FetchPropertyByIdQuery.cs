
using MediatR;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Queries.FetchPropertyById
{
    public record FetchPropertyByIdQuery(long Id) : IRequest<Result<DomainProperty>>;

}
