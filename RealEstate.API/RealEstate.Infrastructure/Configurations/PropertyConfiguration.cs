using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Property;
using RealEstate.Domain.Property.ValueObjects;

namespace RealEstate.Infrastructure.Configurations
{
    internal class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.Property(p => p.Name).HasConversion(
                propertyName => propertyName.Value,
                value => PropertyName.Create(value).Value);
        }
    }
}
