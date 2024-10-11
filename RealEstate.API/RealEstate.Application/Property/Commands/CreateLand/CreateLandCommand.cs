using MediatR;
using Microsoft.AspNetCore.Http;
using RealEstate.Application.Property.Dtos;
using RealEstate.Domain.Common.Enums;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Application.Property.Commands.CreateHouse
{
    public record CreateLandCommand(
        string Name,
        PropertyListingType ListingType,
        string City,
        string? Address,
        int Price,
        double SizeInMmSquared,
        bool IsPremium,
        AdvertiserData AdvertiserData,
        IEnumerable<IFormFile>? Images,
        string? Description
     ) : IRequest<Result<DomainProperty>>;
}
