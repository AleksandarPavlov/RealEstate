
using MediatR;
using RealEstate.Domain.Persistance.Read;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Queries.FetchLatestProperties
{
    public class FetchLatestPropertiesQueryHandler : IRequestHandler<FetchLatestPropertiesQuery, Result<IEnumerable<DomainProperty>>>
    {
        private readonly IPropertyReadRepository _propertyRepository;

        public FetchLatestPropertiesQueryHandler(IPropertyReadRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<Result<IEnumerable<DomainProperty>>> Handle(FetchLatestPropertiesQuery request, CancellationToken cancellationToken)
        {
            return await _propertyRepository.FetchLatestProperties(request.Amount);
        }

     }

}