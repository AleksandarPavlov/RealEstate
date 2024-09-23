using DomainProperty = RealEstate.Domain.Property.Property;
namespace RealEstate.Domain.Persistance.Write
{
    public interface IPropertyWriteRepository
    {
        void Add(DomainProperty entity);
    }
}
