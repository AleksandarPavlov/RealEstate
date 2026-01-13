
using DomainAdvertiser = RealEstate.Domain.Advertiser.Advertiser;

namespace RealEstate.API.Contracts.Advertiser
{
    public static class AdvertiserResponseExtension
    {
        public static AdvertiserResponse? ToContract(DomainAdvertiser? advertiser) =>
           (advertiser != null)
               ? new AdvertiserResponse(
                   advertiser.FullName,
                   advertiser.ContactNumber,
                   advertiser.EmailAddress?.Value ?? null,
                   advertiser.SocialMediaLink)
               : null;
    }
}
