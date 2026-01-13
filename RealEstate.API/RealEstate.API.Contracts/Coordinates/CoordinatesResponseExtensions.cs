
using RealEstate.Domain.Property.ValueObjects;

namespace RealEstate.API.Contracts.Coordinates
{
    public static class CoordinatesResponseExtensions
    {
        public static CoordinatesResponse? ToContract(PropertyCoordinates? coordinates) =>
            (coordinates != null && coordinates.Latitude.HasValue && coordinates.Longitude.HasValue)
                ? new CoordinatesResponse(
                    coordinates.Latitude.Value.ToString(),
                    coordinates.Longitude.Value.ToString())
                : null;
    }
}
