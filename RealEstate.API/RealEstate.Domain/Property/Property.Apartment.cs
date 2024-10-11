
using RealEstate.Domain.Common.Enums;
using RealEstate.Domain.Common.Errors;
using RealEstate.Domain.Property.ValueObjects;
using DomainAdvertiser = RealEstate.Domain.Advertiser.Advertiser;

namespace RealEstate.Domain.Property
{
    public partial class Property
    {
        public static Result<Property> CreateApartmentProperty(
            long id,
            string name,
            PropertyListingType listingType,
            string city,
            string? address,
            int price,
            double sizeInMmSquared,
            DateTime creationTime,
            bool isPremium,
            bool isFurnished,
            DomainAdvertiser? advertiser,
            string floorNumber,
            int numberOfRooms,
            double? latitude,
            double? longitude,
            IEnumerable<string>? images,
            string? description)
    {
            var nameResult = PropertyName.Create(name);
            var locationResult = PropertyLocation.Create(city, address);
            var priceResult = PropertyPrice.Create(price);
            var sizeInMmSquaredResult = PropertySize.Create(sizeInMmSquared);
            const PropertyType propertyType = PropertyType.APARTMENT;      
            var numberOfRoomsResult = PropertyNumberOfRooms.Create(numberOfRooms);
            var coordinatesResult = PropertyCoordinates.Create(latitude, longitude);
            var descriptionResult = PropertyDescription.Create(description);
            

            var combinedResult = ResultExtensions.CombineResults(
               nameResult,
               locationResult,
               priceResult,
               sizeInMmSquaredResult,
               numberOfRoomsResult,
               coordinatesResult,
               descriptionResult
           );

            return combinedResult.Match(
             success =>
             {
                 var (propertyName, propertyLocation, propertyPrice, propertySize, propertyNumberOfRooms, propertyCoordinates, propertyDescription) = success;

                 var property = new Property(
                     id, 
                     propertyName, 
                     listingType, 
                     propertyType, 
                     propertyLocation, 
                     propertyPrice, 
                     propertySize, 
                     creationTime,
                     isPremium, 
                     advertiser,
                     isFurnished, 
                     floorNumber, 
                     propertyNumberOfRooms, 
                     propertyCoordinates, 
                     images,
                     propertyDescription);

                 return Result<Property>.Success(property);
             },
             Result<Property>.Failure
         );

        }
    }
}
