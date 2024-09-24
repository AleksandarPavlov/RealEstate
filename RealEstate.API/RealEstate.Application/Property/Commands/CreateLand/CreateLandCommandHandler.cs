using MediatR;
using RealEstate.Application.Property.Commands.CreateHouse;
using RealEstate.Domain.Persistance;
using RealEstate.Domain.Persistance.Write;
using RealEstate.Domain.Services;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Commands.CreateLand
{
    public class CreateLandCommandHandler : IRequestHandler<CreateLandCommand, Result<DomainProperty>>
    {
        private readonly IPropertyWriteRepository _propertyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoordinatesService _coordinatesService;
        private readonly IImageStorageService _imageStorageService;

        public CreateLandCommandHandler(IPropertyWriteRepository propertyRepository, IUnitOfWork unitOfWork, ICoordinatesService coordinatesService, IImageStorageService imageStorageService)
        {
            _propertyRepository = propertyRepository;
            _unitOfWork = unitOfWork;
            _coordinatesService = coordinatesService;
            _imageStorageService = imageStorageService;
        }

        public async Task<Result<DomainProperty>> Handle(CreateLandCommand request, CancellationToken cancellationToken)
        {
            var locationCoordinates = await _coordinatesService.FetchCoordinates(request.City, request.Address);

            double? latitude = null;
            double? longitude = null;

            if (locationCoordinates != null)
            {
                latitude = double.Parse(locationCoordinates.Lat);
                longitude = double.Parse(locationCoordinates.Lon);
            }

            var mainImageResult = await _imageStorageService.UploadToExternalApi(request.Images?.FirstOrDefault());

            IEnumerable<string>? mainImageDisplayUrl = null;

            if (mainImageResult != null)
            {
                mainImageDisplayUrl = new List<string> { mainImageResult.DisplayUrl };
            }

            var landResult = DomainProperty.CreateLandProperty(
                0,
                request.Name,
                request.ListingType,
                request.City,
                request.Address,
                request.Price,
                request.SizeInMmSquared,
                request.IsPremium,
                latitude,
                longitude,
                mainImageDisplayUrl
            );

            return await landResult.Match(
                async land =>
                {
                    _propertyRepository.Add(land);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    return Result<DomainProperty>.Success(land);
                },
                failure => Task.FromResult(Result<DomainProperty>.Failure(failure))
            );
        }
    }
}
