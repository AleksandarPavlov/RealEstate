
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Property;

namespace RealEstate.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Property> Property { get; set; }

    }
}
