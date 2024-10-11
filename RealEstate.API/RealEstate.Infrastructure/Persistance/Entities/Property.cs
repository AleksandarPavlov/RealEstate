
using RealEstate.Domain.Common.Enums;
using RealEstate.Domain.Common.Errors;
using DomainProperty = RealEstate.Domain.Property.Property;

namespace RealEstate.Infrastructure.Persistance.Entities
{
    public class Property
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public PropertyListingType ListingType { get; private set; } = PropertyListingType.UNKNOWN;
        public PropertyType Type { get; private set; } = PropertyType.UNKNOWN;
        public string City { get; private set; } = string.Empty;
        public string? Address { get; private set; }
        public int Price { get; private set; }
        public double SizeInMmSquared { get; private set; }
        public DateTime CreationTime { get; private set; }
        public bool IsPremium { get; private set; } = false;
        public Advertiser? Advertiser { get; private set; }
        public bool? IsFurnished { get; private set; }
        public string? FloorNumber { get; private set; }
        public int? NumberOfRooms { get; private set; }
        public double? Lat { get; private set; }
        public double? Lon { get; private set; }
        public ICollection<PropertyImage>? Images { get; private set; }
        public string? Description { get; private set; }

        public Property(
            long id,
            string name,
            PropertyListingType listingType,
            PropertyType type,
            string city,
            string? address,
            int price,
            double sizeInMmSquared,
            DateTime creationTime,
            bool isPremium,
            bool? isFurnished,
            string? floorNumber,
            int? numberOfRooms,
            double? lat,
            double? lon,
            string? description)
        {
            Id = id;
            Name = name;
            ListingType = listingType;
            Type = type;
            City = city;
            Address = address;
            Price = price;
            SizeInMmSquared = sizeInMmSquared;
            CreationTime = creationTime;
            IsPremium = isPremium;
            IsFurnished = isFurnished;
            FloorNumber = floorNumber;
            NumberOfRooms = numberOfRooms;
            Lat = lat;
            Lon = lon;
            Description = description;
        }
        public static Result<DomainProperty> ToDomain(Property entity) 
        {
            
            switch (entity.Type)
            {
                case PropertyType.APARTMENT:
                    return DomainProperty.CreateApartmentProperty
                        (
                        entity.Id,
                        entity.Name,
                        entity.ListingType,
                        entity.City,
                        entity.Address,
                        entity.Price,
                        entity.SizeInMmSquared,
                        entity.CreationTime,
                        entity.IsPremium,
                        entity.IsFurnished ?? false, 
                        entity.Advertiser != null ? Advertiser.ToDomain(entity.Advertiser).Value : null,
                        entity.FloorNumber ?? string.Empty,
                        entity.NumberOfRooms ?? 0,
                        entity.Lat,
                        entity.Lon,
                        entity.Images?.Select(image => image.Url),
                        entity.Description
                        );

                case PropertyType.HOUSE:
                    return DomainProperty.CreateHouseProperty
                        (
                        entity.Id,
                        entity.Name,
                        entity.ListingType,
                        entity.City,
                        entity.Address,
                        entity.Price,
                        entity.SizeInMmSquared,
                        entity.CreationTime,
                        entity.IsPremium,
                        entity.IsFurnished ?? false,
                        entity.Advertiser != null ? Advertiser.ToDomain(entity.Advertiser).Value : null,
                        entity.FloorNumber ?? string.Empty,
                        entity.NumberOfRooms ?? 0,
                        entity.Lat,
                        entity.Lon,
                        entity.Images?.Select(image => image.Url),
                        entity.Description
                        );

                case PropertyType.LAND:
                    return DomainProperty.CreateLandProperty
                        (
                        entity.Id,
                        entity.Name,
                        entity.ListingType,
                        entity.City,
                        entity.Address,
                        entity.Price,
                        entity.SizeInMmSquared,
                        entity.CreationTime,
                        entity.IsPremium,
                        entity.Advertiser != null ? Advertiser.ToDomain(entity.Advertiser).Value : null,
                        entity.Lat,
                        entity.Lon,
                        entity.Images?.Select(image => image.Url),
                        entity.Description
                        );

                default:
                    return Result<DomainProperty>.Failure(new Error("PropertyType", "Unknown property type"));
            }

        }

        public static Property FromDomain(DomainProperty entity) {

            var property = new Property
                (
                entity.Id,
                entity.Name.Value,
                entity.ListingType,
                entity.Type,
                entity.Location.City,
                entity.Location.Address,
                entity.Price.Value,
                entity.SizeInMmSquared.Value,
                entity.CreationTime,
                entity.IsPremium,
                entity.IsFurnished,
                entity.FloorNumber,
                entity.NumberOfRooms?.Value,
                entity.Coordinates?.Latitude,
                entity.Coordinates?.Longitude,
                entity.Description?.Value
                );

            if (entity.Images != null && entity.Images.Any()) {
                property.Images = entity.Images.Select(image => new PropertyImage(image)).ToList();
            }

            property.Advertiser = entity.Advertiser != null ? Advertiser.FromDomain(entity.Advertiser).Value : null;

            return property;
        }

    }
}
