
using RealEstate.Application.Property.Dtos;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Domain.Persistance.Read
{
    public interface IPropertyReadRepository
    {
        Task<Result<IEnumerable<DomainProperty>>> FetchPropertiesByFilters(PropertyFilters filters);
        Task<Result<DomainProperty>> FetchPropertyById(long id);
    }
}
