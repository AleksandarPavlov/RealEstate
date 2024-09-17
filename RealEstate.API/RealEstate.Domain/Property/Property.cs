
using RealEstate.Domain.Common.Enums;
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
        public bool? IsFurnished { get; private set; }
        public string? FloorNumber { get; private set; }
        public PropertyNumberOfRooms? NumberOfRooms { get; private set; }
        public PropertyCoordinates? Coordinates { get; private set; }
        private Property(
            PropertyName name, 
            PropertyListingType listingType, 
            PropertyType type, 
            PropertyLocation location, 
            PropertyPrice price, 
            PropertySize sizeInMmSquared, 
            bool? isFurnished, 
            string? floorNumber, 
            PropertyNumberOfRooms? numberOfRooms, 
            PropertyCoordinates? coordinates)
        {
            Name = name;
            ListingType = listingType;
            Type = type;
            Location = location;
            Price = price;
            SizeInMmSquared = sizeInMmSquared;
            IsFurnished = isFurnished;
            FloorNumber = floorNumber;
            NumberOfRooms = numberOfRooms;
            Coordinates = coordinates;
        }
    }
}
