
using MediatR;
using RealEstate.Domain.Persistance.Read;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Queries.FetchPropertyById
{
    public class FetchPropertyByIdQueryHandler : IRequestHandler<FetchPropertyByIdQuery, Result<DomainProperty>>
    {
        private readonly IPropertyReadRepository _propertyRepository;

        public FetchPropertyByIdQueryHandler(IPropertyReadRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<Result<DomainProperty>> Handle(FetchPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            return await _propertyRepository.FetchPropertyById(request.Id);
        }
    }
}
