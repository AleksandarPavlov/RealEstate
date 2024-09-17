using MediatR;
using RealEstate.Domain.Common.Enums;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Commands.CreateHouse
{
    public record CreateHouseCommand(
     string name,
     PropertyListingType listingType,
     string location,
     int price,
     double sizeInMmSquared,
     bool? isFurnished,
     string? floorNumber,
     int? numberOfRooms
     ) : IRequest<Result<DomainProperty>>;
}
