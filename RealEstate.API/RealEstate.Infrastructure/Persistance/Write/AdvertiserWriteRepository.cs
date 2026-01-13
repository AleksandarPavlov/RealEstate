using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Persistance.Write;
using RealEstate.Infrastructure.Persistance.Entities;
using DomainAdvertiser = RealEstate.Domain.Advertiser.Advertiser;

namespace RealEstate.Infrastructure.Persistance.Write
{
    public class AdvertiserWriteRepository : IAdvertiserWriteRepository
    {
        private readonly DbSet<Advertiser> _dbSet;

        public AdvertiserWriteRepository(ApplicationDbContext dbContext)
        {
            _dbSet = dbContext.Set<Advertiser>();
        }

        public void Add(DomainAdvertiser entity)
        {
            var advertiser = Advertiser.FromDomain(entity).Value;
            _dbSet.Add(advertiser);

        }
    }
}
