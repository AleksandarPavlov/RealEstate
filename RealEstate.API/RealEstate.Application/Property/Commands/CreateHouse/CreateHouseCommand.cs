using MediatR;
using Microsoft.AspNetCore.Http;
using RealEstate.Domain.Common.Enums;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Commands.CreateHouse
{
    public record CreateHouseCommand(
        string Name,
        PropertyListingType ListingType,
        string City,
        string? Address,
        int Price,
        double SizeInMmSquared,
        bool IsPremium,
        bool IsFurnished,
        string FloorNumber,
        int NumberOfRooms,
        IEnumerable<IFormFile>? Images
     ) : IRequest<Result<DomainProperty>>;
}
