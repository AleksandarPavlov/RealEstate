
using RealEstate.Domain.Common.Enums;
using DomainAdvertiser = RealEstate.Domain.Advertiser.Advertiser;
using RealEstate.Domain.Property.ValueObjects;

namespace RealEstate.Domain.Property
{
    public partial class Property
    {
        public long Id { get; private set; }
        public PropertyName Name { get; private set; }
        public PropertyListingType ListingType { get; private set; }
        public PropertyType Type { get; private set; }
        public PropertyLocation Location { get; private set; }
        public PropertyPrice Price { get; private set; }
        public PropertySize SizeInMmSquared { get; private set; }
        public DateTime CreationTime { get; private set; }
        public bool IsPremium { get; private set; }
        public DomainAdvertiser? Advertiser { get; private set; }
        public bool? IsFurnished { get; private set; }
        public string? FloorNumber { get; private set; }
        public PropertyNumberOfRooms? NumberOfRooms { get; private set; }
        public PropertyCoordinates? Coordinates { get; private set; }
        public IEnumerable<string>? Images { get; private set; }
        public PropertyDescription? Description { get; private set; }   
        private Property(
            long id,
            PropertyName name,
            PropertyListingType listingType,
            PropertyType type,
            PropertyLocation location,
            PropertyPrice price,
            PropertySize sizeInMmSquared,
            DateTime creationTime,
            bool isPremium,
            DomainAdvertiser? advertiser,
            bool? isFurnished,
            string? floorNumber,
            PropertyNumberOfRooms? numberOfRooms,
            PropertyCoordinates? coordinates,
            IEnumerable<string>? images,
            PropertyDescription? description)
        {
            Id = id;
            Name = name;
            ListingType = listingType;
            Type = type;
            Location = location;
            Price = price;
            SizeInMmSquared = sizeInMmSquared;
            CreationTime = creationTime;
            IsPremium = isPremium;
            Advertiser = advertiser;
            IsFurnished = isFurnished;
            FloorNumber = floorNumber;
            NumberOfRooms = numberOfRooms;
            Coordinates = coordinates;
            Images = images;
            Description = description;
        }
    }
}
