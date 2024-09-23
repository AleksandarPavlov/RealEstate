
using RealEstate.Domain.Common.Enums;
using RealEstate.Domain.Common.Errors;
using RealEstate.Domain.Property.ValueObjects;

namespace RealEstate.Domain.Property
{
    public partial class Property
    {
        public static Result<Property> CreateApartmentProperty(
            long id,
            string name,
            PropertyListingType listingType,
            string location,
            int price,
            double sizeInMmSquared,
            bool isPremium,
            bool isFurnished,
            string floorNumber,
            int numberOfRooms,
            double? latitude,
            double? longitude)
    {
            var nameResult = PropertyName.Create(name);
            var locationResult = PropertyLocation.Create(location);
            var priceResult = PropertyPrice.Create(price);
            var sizeInMmSquaredResult = PropertySize.Create(sizeInMmSquared);
            var propertyType = PropertyType.APARTMENT;      
            var numberOfRoomsResult = PropertyNumberOfRooms.Create(numberOfRooms);
            var coordinatesResult = PropertyCoordinates.Create(latitude, longitude);
            

            var combinedResult = ResultExtensions.CombineResults(
               nameResult,
               locationResult,
               priceResult,
               sizeInMmSquaredResult,
               numberOfRoomsResult,
               coordinatesResult
           );

            return combinedResult.Match(
             success =>
             {
                 var (propertyName, propertyLocation, propertyPrice, propertySize, propertyNumberOfRooms, propertyCoordinates) = success;
                 var property = new Property(id, propertyName, listingType, propertyType, propertyLocation, propertyPrice, propertySize, isPremium, isFurnished, floorNumber, propertyNumberOfRooms, propertyCoordinates);
                 return Result<Property>.Success(property);
             },
             Result<Property>.Failure
         );

        }
    }
}
