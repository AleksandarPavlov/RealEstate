using DomainAdvertiser = RealEstate.Domain.Advertiser.Advertiser;
namespace RealEstate.Domain.Persistance.Write

{
    public interface IAdvertiserWriteRepository
    {
        void Add(DomainAdvertiser entity);
    }
}
