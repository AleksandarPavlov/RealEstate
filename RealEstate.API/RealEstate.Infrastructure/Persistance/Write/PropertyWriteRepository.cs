
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Common.Enums;
using RealEstate.Domain.Common.Errors;
using RealEstate.Domain.Persistance.Write;
using RealEstate.Infrastructure.Persistance.Entities;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Infrastructure.Persistance.Write
{
    public class PropertyWriteRepository : IPropertyWriteRepository
    {
        private readonly DbSet<Property> _dbSet;
        private readonly ApplicationDbContext _dbContext;

        public PropertyWriteRepository(ApplicationDbContext dbContext)
        {
            _dbSet = dbContext.Set<Property>();
            _dbContext = dbContext;
        }

        public void Add(DomainProperty entity, long advertiserId)
        {
            var advertiser = _dbContext.Advertiser.First(a => a.Id == advertiserId);

            var property = Property.FromDomain(entity, advertiser);
            _dbSet.Add(property);

        }


        public async Task<Result<DomainProperty>> ChangeStatus(PropertyStatus status, long id)
        {
            var property = await _dbSet.FirstOrDefaultAsync(p => p.Id == id);
            if (property is null)
                return Result<DomainProperty>.Failure(new Error("Id", $"Unable to fetch property with id '{id}'"));

            property.PropertyStatus = status;
            return Result<DomainProperty>.Success(Property.ToDomain(property).Value);
        }
    }
}
