
using RealEstate.Domain.Common.Enums;
using RealEstate.Domain.Common.Errors;
using RealEstate.Domain.Property.ValueObjects;

namespace RealEstate.Domain.Property
{
    public partial class Property
    {
        public static Result<Property> CreateApartmentProperty(
        string name,
        PropertyListingType listingType,
        string location,
        int price,
        double sizeInMmSquared,
        bool isFurnished,
        string floorNumber,
        int numberOfRooms)
    {
            var nameResult = PropertyName.Create(name);
            var locationResult = PropertyLocation.Create(location);
            var priceResult = PropertyPrice.Create(price);
            var sizeInMmSquaredResult = PropertySize.Create(sizeInMmSquared);
            var propertyType = PropertyType.APARTMENT;      
            var numberOfRoomsResult = PropertyNumberOfRooms.Create(numberOfRooms);
            

            var combinedResult = ResultExtensions.CombineResults(
               nameResult,
               locationResult,
               priceResult,
               sizeInMmSquaredResult,
               numberOfRoomsResult
           );

            return combinedResult.Match(
             success =>
             {
                 var (propertyName, propertyLocation, propertyPrice, propertySize, propertyNumberOfRooms) = success;
                 var property = new Property(propertyName, listingType, propertyType, propertyLocation, propertyPrice, propertySize, isFurnished, floorNumber, propertyNumberOfRooms);
                 return Result<Property>.Success(property);
             },
             Result<Property>.Failure
         );

        }
    }
}
