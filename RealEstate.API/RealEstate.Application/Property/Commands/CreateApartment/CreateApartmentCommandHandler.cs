
using MediatR;
using RealEstate.Domain.Persistance;
using RealEstate.Domain.Persistance.Write;
using RealEstate.Domain.Services;
using DomainProperty = RealEstate.Domain.Property.Property;


namespace RealEstate.Application.Property.Commands.CreateApartment
{
    public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommand, Result<DomainProperty>>
    {
        private readonly IPropertyWriteRepository _propertyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoordinatesService _coordinatesService;

        public CreateApartmentCommandHandler(IPropertyWriteRepository propertyRepository, IUnitOfWork unitOfWork, ICoordinatesService coordinatesService)
        {
            _propertyRepository = propertyRepository;
            _unitOfWork = unitOfWork;
            _coordinatesService = coordinatesService;
        }

        public async Task<Result<DomainProperty>> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
        {
            var locationCoordinates = await _coordinatesService.FetchCoordinates(request.Location);

            double? latitude = null;
            double? longitude = null;

            if (locationCoordinates != null) {
                latitude = double.Parse(locationCoordinates.Lat);
                longitude = double.Parse(locationCoordinates.Lon);
            }

            var apartmentResult = DomainProperty.CreateApartmentProperty(
                0,
                request.Name,
                request.ListingType,
                request.Location,
                request.Price,
                request.SizeInMmSquared,
                request.IsPremium,
                request.IsFurnished,
                request.FloorNumber,
                request.NumberOfRooms,
                latitude,
                longitude
            );

            return await apartmentResult.Match(
                async apartment =>
                {
                    _propertyRepository.Add(apartment);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    return Result<DomainProperty>.Success(apartment);
                },
                failure => Task.FromResult(Result<DomainProperty>.Failure(failure))
            );
        }
    }
}
