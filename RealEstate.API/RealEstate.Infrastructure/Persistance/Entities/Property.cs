
using RealEstate.Domain.Common.Enums;
using RealEstate.Domain.Common.Errors;
using RealEstate.Domain.Property.ValueObjects;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Infrastructure.Persistance.Entities
{
    public class Property
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public PropertyListingType ListingType { get; private set; } = PropertyListingType.UNKNOWN;
        public PropertyType Type { get; private set; } = PropertyType.UNKNOWN;
        public string Location { get; private set; } = string.Empty;
        public int Price { get; private set; }
        public double SizeInMmSquared { get; private set; }
        public bool IsPremium { get; private set; } = false;
        public bool? IsFurnished { get; private set; }
        public string? FloorNumber { get; private set; }
        public int? NumberOfRooms { get; private set; }
        public string? Coordinates { get; private set; }

        public Property(
            long id,
            string name,
            PropertyListingType listingType,
            PropertyType type,
            string location,
            int price,
            double sizeInMmSquared,
            bool isPremium,
            bool? isFurnished,
            string? floorNumber,
            int? numberOfRooms,
            string? coordinates)
        {
            Id = id;
            Name = name;
            ListingType = listingType;
            Type = type;
            Location = location;
            Price = price;
            SizeInMmSquared = sizeInMmSquared;
            IsPremium = isPremium;
            IsFurnished = isFurnished;
            FloorNumber = floorNumber;
            NumberOfRooms = numberOfRooms;
            Coordinates = coordinates?.ToString();
        }
        public static Result<DomainProperty> ToDomain(Property entity) 
        {
            var coordinates = PropertyCoordinates.CreateCoordinatesFromString(entity.Coordinates);

            switch (entity.Type)
            {
                case PropertyType.APARTMENT:
                    return DomainProperty.CreateApartmentProperty
                        (
                        entity.Id,
                        entity.Name,
                        entity.ListingType,
                        entity.Location,
                        entity.Price,
                        entity.SizeInMmSquared,
                        entity.IsPremium,
                        entity.IsFurnished ?? false,
                        entity.FloorNumber ?? string.Empty,
                        entity.NumberOfRooms ?? 0,
                        coordinates.Latitude,
                        coordinates.Longitude                     
                        ) ;

                case PropertyType.HOUSE:
                    return DomainProperty.CreateHouseProperty
                        (
                        entity.Id,
                        entity.Name,
                        entity.ListingType,
                        entity.Location,
                        entity.Price,
                        entity.SizeInMmSquared,
                        entity.IsPremium,
                        entity.IsFurnished ?? false,
                        entity.FloorNumber ?? string.Empty,
                        entity.NumberOfRooms ?? 0,
                        coordinates.Latitude,
                        coordinates.Longitude
                        );

                case PropertyType.LAND:
                    return DomainProperty.CreateLandProperty
                        (
                        entity.Id,
                        entity.Name,
                        entity.ListingType,
                        entity.Location,
                        entity.Price,
                        entity.SizeInMmSquared,
                        entity.IsPremium,
                        coordinates.Latitude,
                        coordinates.Longitude
                        ); ;

                default:
                    return Result<DomainProperty>.Failure(new Error("PropertyType", "Unknown property type"));
            }

        }

        public static Property FromDomain(DomainProperty entity) {

            return new Property
                (
                entity.Id,
                entity.Name.Value,
                entity.ListingType,
                entity.Type,
                entity.Location.Value,
                entity.Price.Value,
                entity.SizeInMmSquared.Value,
                entity.IsPremium,
                entity.IsFurnished,
                entity.FloorNumber,
                entity.NumberOfRooms?.Value,
                entity.Coordinates?.ToString()
                );

        }

    }
}
