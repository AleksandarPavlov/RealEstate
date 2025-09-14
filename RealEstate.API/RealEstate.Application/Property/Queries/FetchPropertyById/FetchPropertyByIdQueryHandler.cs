
using MediatR;
using RealEstate.Domain.Common.Enums;
using RealEstate.Domain.Common.Errors;
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
           var result = await _propertyRepository.FetchPropertyById(request.Id);
            if (result.IsSuccess) {
                if (result.Value.PropertyStatus != PropertyStatus.APPROVED) {
                    return Result<DomainProperty>.Failure(new Error("Id", $"Property with id '{request.Id}' is not approved yet."));
                }
            }
            return result;
        }
    }
}
