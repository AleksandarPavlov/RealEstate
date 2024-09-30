using MediatR;
using RealEstate.Domain.Common.Errors;
using RealEstate.Domain.Persistance.Read;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Queries.FindNearbyProperties
{
    public class FindNearbyPropertiesQueryHandler : IRequestHandler<FindNearbyPropertiesQuery, Result<IEnumerable<DomainProperty>>>
    {
        private readonly IPropertyReadRepository _propertyRepository;

        public FindNearbyPropertiesQueryHandler(IPropertyReadRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<Result<IEnumerable<DomainProperty>>> Handle(FindNearbyPropertiesQuery request, CancellationToken cancellationToken)
        {
            if(!double.TryParse(request.Lat, out double lat) ||
               !double.TryParse(request.Lon, out double lon))
            {
                return Result<IEnumerable<DomainProperty>>.Failure(new Error("Coordinates", $"Invalid coordinates '{request.Lat}', '{request.Lon}'"));
       
            }

            return await _propertyRepository.FindNearbyProperties(request.Distance, lat, lon);
        }
    }
}
