
using RealEstate.Application.Property.Dtos;
using RealEstate.Domain.Common.Dtos;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Domain.Persistance.Read
{
    public interface IPropertyReadRepository
    {
        Task<Result<IEnumerable<DomainProperty>>> FetchPropertiesByFilters(PropertyFilters filters);
        Task<Result<DomainProperty>> FetchPropertyById(long id);
        Task<Result<IEnumerable<DomainProperty>>> FetchLatestProperties(int amount);
        Task<Result<IEnumerable<DomainProperty>>> FindNearbyProperties(int distance, double lat, double lon);
    }
}
