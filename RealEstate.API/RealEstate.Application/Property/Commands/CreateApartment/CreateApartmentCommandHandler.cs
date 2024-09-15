
using MediatR;
using RealEstate.Domain.Persistance;
using RealEstate.Infrastructure.Persistance;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Commands.CreateApartment
{
    public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommand, Result<DomainProperty>>
    {
        private readonly IEntityRepository<DomainProperty> _propertyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateApartmentCommandHandler(IEntityRepository<DomainProperty> propertyRepository, IUnitOfWork unitOfWork)
        {
            _propertyRepository = propertyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DomainProperty>> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.floorNumber + " " + request.name + " " + request.isFurnished);
            var apartmentResult = DomainProperty.CreateApartmentProperty(
                request.name,
                request.listingType,
                request.location,
                request.price,
                request.sizeInMmSquared,
                request.isFurnished,
                request.floorNumber,
                request.numberOfRooms
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
