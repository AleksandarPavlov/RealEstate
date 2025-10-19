
namespace RealEstate.API.Contracts.Advertiser
{
    public record AdvertiserResponse
        (
        string? FullName,
        string? ContactNumber,
        string? EmailAddress,
        string? SocialMediaLink 
        )
    {}
}
