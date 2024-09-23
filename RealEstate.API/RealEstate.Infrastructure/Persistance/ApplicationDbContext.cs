
using Microsoft.EntityFrameworkCore;
using RealEstate.Infrastructure.Persistance.Entities;

namespace RealEstate.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {
        }
/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }*/

        public DbSet<Property> Property { get; set; } = null!;

    }
}
