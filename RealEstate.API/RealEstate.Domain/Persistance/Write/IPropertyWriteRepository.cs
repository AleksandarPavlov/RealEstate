using DomainAdvertiser = RealEstate.Domain.Advertiser.Advertiser;
using RealEstate.Domain.Common.Enums;
using DomainProperty = RealEstate.Domain.Property.Property;
namespace RealEstate.Domain.Persistance.Write
{
    public interface IPropertyWriteRepository
    {
        void Add(DomainProperty entity, long advertiserId);
        Task<Result<DomainProperty>> ChangeStatus(PropertyStatus status, long id);
    }
}
