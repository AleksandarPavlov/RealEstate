
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Property.Dtos;
using RealEstate.Domain.Persistance.Read;
using RealEstate.Infrastructure.Persistance.Entities;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Infrastructure.Persistance.Read
{
    public class PropertyReadRepository : IPropertyReadRepository
    {
        private ApplicationDbContext _context;
        public PropertyReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<DomainProperty>>> FetchPropertiesByFilters(PropertyFilters filters)
        {
            var query = _context.Property.AsQueryable();

            if (!string.IsNullOrEmpty(filters.City))
            {
                query = query.Where(p => p.City == filters.City);
            }

            if (filters.ListingType.HasValue)
            {
                query = query.Where(p => p.ListingType == filters.ListingType);
            }

            if (filters.PropertyType.HasValue)
            {
                query = query.Where(p => p.Type == filters.PropertyType);
            }

            if (filters.SizeFrom.HasValue)
            {
                query = query.Where(p => p.SizeInMmSquared >= filters.SizeFrom);
            }

            if (filters.PriceTo.HasValue)
            {
                query = query.Where(p => p.Price <= filters.PriceTo);
            }

            if (filters.GroundFloor.HasValue)
            {
                query = query.Where(p => p.FloorNumber != null && (p.FloorNumber == "0" == filters.GroundFloor));
            }

            if (filters.NumberOfRooms.HasValue)
            {
                query = query.Where(p => p.NumberOfRooms != null && p.NumberOfRooms == filters.NumberOfRooms);
            }

            var properties = await query.Skip(filters.Page * filters.PageSize)
                               .Take(filters.PageSize)
                               .Include(p => p.Images)
                               .ToListAsync();

            var domainProperties = properties
            .Select(Property.ToDomain)
            .Where(result => result.IsSuccess)             
            .Select(result => result.Value);

            return Result<IEnumerable<DomainProperty>>.Success(domainProperties);

        }
    }
}
