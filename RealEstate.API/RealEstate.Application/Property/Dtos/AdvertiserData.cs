namespace RealEstate.Application.Property.Dtos;

    public record AdvertiserData
    (
        string FullName,
        string ContactNumber,
        string? EmailAddress,
        string? SocialMediaLink
    );