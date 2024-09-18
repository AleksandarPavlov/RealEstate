
using Newtonsoft.Json;

namespace RealEstate.API.Contracts.Coordinates
{
    public record CoordinatesResponse([JsonProperty("lat")] string Lat, [JsonProperty("lon")] string Lon)
    {
    }
}
