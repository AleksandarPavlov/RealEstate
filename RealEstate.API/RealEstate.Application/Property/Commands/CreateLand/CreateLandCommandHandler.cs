using MediatR;
using RealEstate.Application.Property.Commands.CreateHouse;
using RealEstate.Domain.Persistance;
using RealEstate.Domain.Services;
using RealEstate.Infrastructure.Persistance;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Commands.CreateLand
{
    public class CreateLandCommandHandler : IRequestHandler<CreateLandCommand, Result<DomainProperty>>
    {
        private readonly IEntityRepository<DomainProperty> _propertyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoordinatesService _coordinatesService;

        public CreateLandCommandHandler(IEntityRepository<DomainProperty> propertyRepository, IUnitOfWork unitOfWork, ICoordinatesService coordinatesService)
        {
            _propertyRepository = propertyRepository;
            _unitOfWork = unitOfWork;
            _coordinatesService = coordinatesService;
        }

        public async Task<Result<DomainProperty>> Handle(CreateLandCommand request, CancellationToken cancellationToken)
        {
            var locationCoordinates = await _coordinatesService.FetchCoordinates(request.Location);

            double? latitude = null;
            double? longitude = null;

            if (locationCoordinates != null)
            {
                latitude = double.Parse(locationCoordinates.Lat);
                longitude = double.Parse(locationCoordinates.Lon);
            }

            var landResult = DomainProperty.CreateLandProperty(
                request.Name,
                request.ListingType,
                request.Location,
                request.Price,
                request.SizeInMmSquared,
                request.IsPremium,
                latitude,
                longitude
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
