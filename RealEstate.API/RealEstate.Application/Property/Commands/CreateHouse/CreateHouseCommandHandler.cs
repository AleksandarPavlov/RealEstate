using MediatR;
using RealEstate.Domain.Common.Enums;
using RealEstate.Domain.Common.Errors;
using RealEstate.Domain.Persistance;
using RealEstate.Domain.Persistance.Read;
using RealEstate.Domain.Persistance.Write;
using RealEstate.Domain.Services;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Commands.CreateHouse
{
    public class CreateHouseCommandHandler : IRequestHandler<CreateHouseCommand, Result<DomainProperty>>
    {
        private readonly IPropertyWriteRepository _propertyRepository;
        private readonly IAdvertiserReadRepository _advertiserReadRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoordinatesService _coordinatesService;
        private readonly IImageStorageService _imageStorageService;

        public CreateHouseCommandHandler(IPropertyWriteRepository propertyRepository, IAdvertiserReadRepository advertiserReadRepository, IUnitOfWork unitOfWork, ICoordinatesService coordinatesService, IImageStorageService imageStorageService)
        {
            _propertyRepository = propertyRepository;
            _advertiserReadRepository = advertiserReadRepository;
            _unitOfWork = unitOfWork;
            _coordinatesService = coordinatesService;
            _imageStorageService = imageStorageService;
        }

        public async Task<Result<DomainProperty>> Handle(CreateHouseCommand request, CancellationToken cancellationToken)
        {
            var locationCoordinates = await _coordinatesService.FetchCoordinates(request.City, request.Address);

            double? latitude = null;
            double? longitude = null;

            if (locationCoordinates != null)
            {
                latitude = double.Parse(locationCoordinates.Lat);
                longitude = double.Parse(locationCoordinates.Lon);
            }

            var imagesResult = (request.Images != null && request.Images.Any())
           ? await _imageStorageService.UploadToExternalApi(request.Images)
           : null;

            var advertiserResult = await _advertiserReadRepository.FetchAdvertiserByUsername(request.AdvertiserUsername);

            if (advertiserResult.IsFailure)
            {
                return Result<DomainProperty>.Failure(new Error("Advertiser", "Error fetching advertiser"));
            }

            var efAdvertiserEntity = advertiserResult.Value;

            var houseResult = DomainProperty.CreateHouseProperty(
                0,
                request.Name,
                request.ListingType,
                request.City,
                request.Address,
                request.Price,
                request.SizeInMmSquared,
                DateTime.Now,
                request.IsFurnished,
                request.IsPremium,
                null,
                request.FloorNumber,
                request.NumberOfRooms,
                latitude,
                longitude,
                imagesResult?.Select(image => image.DisplayUrl),
                request.Description,
                PropertyStatus.WAITING_APPROVAL
            );

            return await houseResult.Match(

                async house =>
                {
                    _propertyRepository.Add(house, efAdvertiserEntity.Id);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    return Result<DomainProperty>.Success(house);
                },

                failure => Task.FromResult(Result<DomainProperty>.Failure(failure))
            );
        }
    }
}
