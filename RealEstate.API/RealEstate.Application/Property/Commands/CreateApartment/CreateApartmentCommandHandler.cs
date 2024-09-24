
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
        private readonly IImageStorageService _imageStorageService;

        public CreateApartmentCommandHandler(IPropertyWriteRepository propertyRepository, IUnitOfWork unitOfWork, ICoordinatesService coordinatesService, IImageStorageService imageStorageService)
        {
            _propertyRepository = propertyRepository;
            _unitOfWork = unitOfWork;
            _coordinatesService = coordinatesService;
            _imageStorageService = imageStorageService;
        }

        public async Task<Result<DomainProperty>> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
        {
            var locationCoordinates = await _coordinatesService.FetchCoordinates(request.City, request.Address);

            double? latitude = null;
            double? longitude = null;

            if (locationCoordinates != null) {
                latitude = double.Parse(locationCoordinates.Lat);
                longitude = double.Parse(locationCoordinates.Lon);
            }

            var mainImageResult = await _imageStorageService.UploadToExternalApi(request.Images?.FirstOrDefault());

            IEnumerable<string>? mainImageDisplayUrl = null;

            if (mainImageResult != null) {

                mainImageDisplayUrl = new List<string> { mainImageResult.DisplayUrl };

            }

            var apartmentResult = DomainProperty.CreateApartmentProperty(
                0,
                request.Name,
                request.ListingType,
                request.City,
                request.Address,
                request.Price,
                request.SizeInMmSquared,
                request.IsPremium,
                request.IsFurnished,
                request.FloorNumber,
                request.NumberOfRooms,
                latitude,
                longitude,
                mainImageDisplayUrl
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
