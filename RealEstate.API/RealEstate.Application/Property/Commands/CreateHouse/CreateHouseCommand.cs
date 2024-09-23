using MediatR;
using RealEstate.Domain.Common.Enums;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Commands.CreateHouse
{
    public record CreateHouseCommand(
        string Name,
        PropertyListingType ListingType,
        string Location,
        int Price,
        double SizeInMmSquared,
        bool IsPremium,
        bool IsFurnished,
        string FloorNumber,
        int NumberOfRooms
     ) : IRequest<Result<DomainProperty>>;
}
