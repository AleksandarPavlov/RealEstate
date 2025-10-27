
using MediatR;
using RealEstate.Application.Property.Dtos;
using RealEstate.Domain.Persistance.Read;
using DomainProperty = RealEstate.Domain.Property.Property;


namespace RealEstate.Application.Property.Queries.FetchMyAdvertisements
{
    public class FetchMyAdvertisementsQueryHandler : IRequestHandler<FetchMyAdvertisementsQuery, Result<IEnumerable<DomainProperty>>>
    {
        private readonly IPropertyReadRepository _propertyRepository;

        public FetchMyAdvertisementsQueryHandler(IPropertyReadRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        public async Task<Result<IEnumerable<DomainProperty>>> Handle(FetchMyAdvertisementsQuery request, CancellationToken cancellationToken)
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

            return await _propertyRepository.FetchMyAdvertisements(request.Username, filters);
        }
    }
}
