using RealEstate.Domain.Common.Enums;
using DomainProperty = RealEstate.Domain.Property.Property;
namespace RealEstate.Domain.Persistance.Write
{
    public interface IPropertyWriteRepository
    {
        void Add(DomainProperty entity);
        Task<Result<DomainProperty>> ChangeStatus(PropertyStatus status, long id);
    }
}
