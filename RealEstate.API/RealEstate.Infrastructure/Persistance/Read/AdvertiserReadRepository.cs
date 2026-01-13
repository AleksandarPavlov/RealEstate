
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Common.Errors;
using RealEstate.Domain.Persistance.Read;
using RealEstate.Infrastructure.Persistance.Entities;
using DomainAdvertiser = RealEstate.Domain.Advertiser.Advertiser;
namespace RealEstate.Infrastructure.Persistance.Read
{
    public class AdvertiserReadRepository : IAdvertiserReadRepository
    {
        private ApplicationDbContext _context;
        public AdvertiserReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<DomainAdvertiser>> FetchAdvertiserByUsername(string username)
        {
            var advertiser = await _context.Advertiser
                                .SingleOrDefaultAsync(a => a.Username == username);

            return advertiser is not null
            ? Result<DomainAdvertiser>.Success(Advertiser.ToDomain(advertiser).Value)
            : Result<DomainAdvertiser>.Failure(new Error("Username", $"Unable to fetch advertiser with username '{username}'"));
        }
    }
}
