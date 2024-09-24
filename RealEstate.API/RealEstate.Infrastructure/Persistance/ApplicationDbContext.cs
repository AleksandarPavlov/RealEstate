﻿
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

        public DbSet<Property> Property { get; set; } = null!;
        public DbSet<PropertyImage> PropertyImage { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>()
              .HasMany(p => p.Images) 
              .WithOne(img => img.Property)
              .HasForeignKey(img => img.PropertyId) 
              .OnDelete(DeleteBehavior.Cascade); 

        }
    }
}
