
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Property.Dtos;
using RealEstate.Domain.Persistance.Read;
using RealEstate.Domain.Property;

namespace RealEstate.Infrastructure.Persistance.Read
{
    public class PropertyReadRepository : IPropertyReadRepository
    {
        private ApplicationDbContext _context;
        public PropertyReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<Property>>> FetchPropertiesByFilters(PropertyFilters filters)
        {
            var res = await _context.Property
             .AsNoTracking()
             .ToListAsync();
            return res;
        }
    }
}
