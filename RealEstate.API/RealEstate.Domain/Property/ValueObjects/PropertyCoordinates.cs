
namespace RealEstate.Domain.Property.ValueObjects
{
    public class PropertyCoordinates
    {
        private PropertyCoordinates(double? latitudeValue, double? longitudeValue)
        {
            Latitude = latitudeValue;
            Longitude = longitudeValue;
        }

        public double? Latitude { get; }
        public double? Longitude { get; }
        public static Result<PropertyCoordinates> Create(double? latitudeValue, double? longitudeValue) =>

            !latitudeValue.HasValue || !longitudeValue.HasValue
            ? Result<PropertyCoordinates>.Success(new PropertyCoordinates(null, null))
            : Result<PropertyCoordinates>.Success(new PropertyCoordinates(latitudeValue, longitudeValue));

        public override string ToString()
        {
            return Latitude.ToString() + ',' + Longitude.ToString();
        }

        public static PropertyCoordinates CreateCoordinatesFromString(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return new PropertyCoordinates(null, null);
            }

            var parts = value.Split(',');
            var latitude = double.TryParse(parts[0], out var lat) ? (double?)lat : null;
            var longitude = double.TryParse(parts[1], out var lon) ? (double?)lon : null;

            return new PropertyCoordinates(latitude, longitude);
        }
    }
}
