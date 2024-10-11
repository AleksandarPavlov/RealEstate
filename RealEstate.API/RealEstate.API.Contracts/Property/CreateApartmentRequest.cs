using RealEstate.Domain.Common.Enums;
using RealEstate.Application.Property.Dtos;

namespace RealEstate.API.Contracts.Property;

public record CreateApartmentRequest
(
    string Name,
    PropertyListingType ListingType,
    string City,
    string? Address,
    int Price,
    double SizeInMmSquared,
    bool IsPremium,
    bool IsFurnished,
    string AdvertiserFullName,
    string AdvertiserContact,
    string AdvertiserEmailAddress,
    string AdvertiserSocialMediaLink,
    string FloorNumber,
    int NumberOfRooms,
    string? Description
);

