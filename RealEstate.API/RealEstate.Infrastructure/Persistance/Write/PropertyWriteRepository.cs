
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Persistance.Write;
using RealEstate.Infrastructure.Persistance.Entities;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Infrastructure.Persistance.Write
{
    public class PropertyWriteRepository : IPropertyWriteRepository
    {
        private readonly DbSet<Property> _dbSet;

        public PropertyWriteRepository(ApplicationDbContext dbContext)
        {
            _dbSet = dbContext.Set<Property>();
        }

        public void Add(DomainProperty entity)
        {
            var property = Property.FromDomain(entity);
            _dbSet.Add(property);

        }
    }
}
