using MediatR;
using RealEstate.Domain.Common.Enums;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Commands.CreateHouse
{
    public record CreateLandCommand(
        string Name,
        PropertyListingType ListingType,
        string Location,
        int Price,
        double SizeInMmSquared,
        bool IsPremium
     ) : IRequest<Result<DomainProperty>>;
}
