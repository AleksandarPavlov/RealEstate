
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


            var imagesResult = (request.Images != null && request.Images.Any()) 
                ? await _imageStorageService.UploadToExternalApi(request.Images) 
                : null;

            
            var apartmentResult = DomainProperty.CreateApartmentProperty(
                0,
                request.Name,
                request.ListingType,
                request.City,
                request.Address,
                request.Price,
                request.SizeInMmSquared,
                DateTime.Now,
                request.IsPremium,
                request.IsFurnished,
                request.FloorNumber,
                request.NumberOfRooms,
                latitude,
                longitude,
                imagesResult?.Select(image => image.DisplayUrl),
                request.Description
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
