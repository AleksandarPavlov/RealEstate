
using MediatR;
using RealEstate.Application.Property.Dtos;
using RealEstate.Domain.Persistance;
using RealEstate.Domain.Persistance.Read;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Queries.FetchPropertiesByFilters
{
    public class FetchPropertiesByFiltersQueryHandler : IRequestHandler<FetchPropertiesByFiltersQuery, Result<IEnumerable<DomainProperty>>>
    {
        private readonly IPropertyReadRepository _propertyRepository;

        public FetchPropertiesByFiltersQueryHandler(IPropertyReadRepository propertyRepository, IUnitOfWork unitOfWork)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<Result<IEnumerable<DomainProperty>>> Handle(FetchPropertiesByFiltersQuery request, CancellationToken cancellationToken)
        {
            var filters = new PropertyFilters(
                request.City, request.ListingType,
                request.PropertyType,
                request.SizeFrom,
                request.PriceTo,
                request.GroundFloor,
                request.NumberOfRooms,
                request.Page,
                request.PageSize);

            var result = await _propertyRepository.FetchPropertiesByFilters(filters);
            
            return result;
        }
    }
}
