using MediatR;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Queries.FetchPropertiesForApproval
{
    public record FetchPropertiesForApprovalQuery
        (
        int Page = 0,
        int PageSize = 10
        ) : IRequest<Result<IEnumerable<DomainProperty>>>;
}
