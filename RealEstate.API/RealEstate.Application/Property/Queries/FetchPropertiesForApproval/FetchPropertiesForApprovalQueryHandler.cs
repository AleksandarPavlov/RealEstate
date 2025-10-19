using MediatR;
using RealEstate.Application.Property.Dtos;
using RealEstate.Domain.Persistance.Read;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Queries.FetchPropertiesForApproval
{
    public class FetchPropertiesForApprovalQueryHandler : IRequestHandler<FetchPropertiesForApprovalQuery, Result<IEnumerable<DomainProperty>>>
    {
        private readonly IPropertyReadRepository _propertyRepository;

        public FetchPropertiesForApprovalQueryHandler(IPropertyReadRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        public async Task<Result<IEnumerable<DomainProperty>>> Handle(FetchPropertiesForApprovalQuery request, CancellationToken cancellationToken)
        {
            var filters = new PropertyFilters(
                City: null,
                ListingType: null,
                PropertyType: null,
                SizeFrom: null,
                PriceTo: null,
                GroundFloor: null,
                NumberOfRooms: null,
                Page: request.Page,
                PageSize: request.PageSize
            );

            var result = await _propertyRepository.FetchPropertiesForApproval(filters);

            return result;
        }
    }
}
