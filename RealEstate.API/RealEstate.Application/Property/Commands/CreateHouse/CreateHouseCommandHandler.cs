using MediatR;
using RealEstate.Domain.Persistance;
using RealEstate.Domain.Services;
using RealEstate.Infrastructure.Persistance;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Commands.CreateHouse
{
    public class CreateHouseCommandHandler : IRequestHandler<CreateHouseCommand, Result<DomainProperty>>
    {
        private readonly IEntityRepository<DomainProperty> _propertyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoordinatesService _coordinatesService;

        public CreateHouseCommandHandler(IEntityRepository<DomainProperty> propertyRepository, IUnitOfWork unitOfWork, ICoordinatesService coordinatesService)
        {
            _propertyRepository = propertyRepository;
            _unitOfWork = unitOfWork;
            _coordinatesService = coordinatesService;
        }

        public async Task<Result<DomainProperty>> Handle(CreateHouseCommand request, CancellationToken cancellationToken)
        {
            var locationCoordinates = await _coordinatesService.FetchCoordinates(request.location);

            double? latitude = null;
            double? longitude = null;

            if (locationCoordinates != null)
            {
                latitude = double.Parse(locationCoordinates.Lat);
                longitude = double.Parse(locationCoordinates.Lon);
            }

            var houseResult = DomainProperty.CreateHouseProperty(
                request.name,
                request.listingType,
                request.location,
                request.price,
                request.sizeInMmSquared,
                request.isFurnished,
                request.floorNumber,
                request.numberOfRooms,
                latitude,
                longitude
            );

            return await houseResult.Match(
                async house =>
                {
                    _propertyRepository.Add(house);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    return Result<DomainProperty>.Success(house);
                },
                failure => Task.FromResult(Result<DomainProperty>.Failure(failure))
            );
        }
    }
}
