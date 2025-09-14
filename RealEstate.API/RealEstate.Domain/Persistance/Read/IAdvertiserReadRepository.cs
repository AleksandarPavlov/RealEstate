using DomainAdvertiser = RealEstate.Domain.Advertiser.Advertiser;
namespace RealEstate.Domain.Persistance.Read
{
    public interface IAdvertiserReadRepository
    {
        Task<Result<DomainAdvertiser>> FetchAdvertiserByUsername(string username);
    }
}
