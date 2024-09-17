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

            builder.Property(p => p.Location).HasConversion(
               location => location.Value,
               value => PropertyLocation.Create(value).Value);

            builder.Property(p => p.Price).HasConversion(
               price => price.Value,
               value => PropertyPrice.Create(value).Value);

            builder.Property(p => p.NumberOfRooms).HasConversion(
               numberOfRooms => numberOfRooms != null ? numberOfRooms.Value : (int?)null, 
               value => value.HasValue ? PropertyNumberOfRooms.Create(value.Value).Value : null);

            builder.Property(p => p.SizeInMmSquared).HasConversion(
               size => size.Value,
               value => PropertySize.Create(value).Value);

            builder.Property(p => p.Coordinates).HasConversion(
               coordinates => coordinates == null ? null : coordinates.ToString(),
               value => PropertyCoordinates.CreateCoordinatesFromString(value));
        }
    }
}
