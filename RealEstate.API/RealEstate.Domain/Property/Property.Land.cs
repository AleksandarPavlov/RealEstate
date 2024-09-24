
using RealEstate.Domain.Common.Enums;
using RealEstate.Domain.Common.Errors;
using RealEstate.Domain.Property.ValueObjects;

namespace RealEstate.Domain.Property
{
    public partial class Property
    {
        public static Result<Property> CreateLandProperty(
            long id,
            string name,
            PropertyListingType listingType,
            string city,
            string? address,
            int price,
            double sizeInMmSquared,
            bool isPremium,
            double? latitude,
            double? longitude,
            IEnumerable<string>? images)
            {
                var nameResult = PropertyName.Create(name);
                var locationResult = PropertyLocation.Create(city, address);
                var priceResult = PropertyPrice.Create(price);
                var sizeInMmSquaredResult = PropertySize.Create(sizeInMmSquared);
                var propertyType = PropertyType.LAND;
                var coordinatesResult = PropertyCoordinates.Create(latitude, longitude);


                var combinedResult = ResultExtensions.CombineResults(
                   nameResult,
                   locationResult,
                   priceResult,
                   sizeInMmSquaredResult,
                   coordinatesResult
               );

                return combinedResult.Match(
                 success =>
                 {
                     var (propertyName, propertyLocation, propertyPrice, propertySize, propertyCoordinates) = success;

                     var property = new Property(
                         id, 
                         propertyName, 
                         listingType, 
                         propertyType, 
                         propertyLocation, 
                         propertyPrice, 
                         propertySize, 
                         isPremium, 
                         null, 
                         null, 
                         null, 
                         propertyCoordinates, 
                         images);

                     return Result<Property>.Success(property);
                 },
                 Result<Property>.Failure
             );
            }
    }
}

