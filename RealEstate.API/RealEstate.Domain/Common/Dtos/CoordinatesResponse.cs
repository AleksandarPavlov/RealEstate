
using Newtonsoft.Json;

namespace RealEstate.Domain.Common.Dtos
{
   public record CoordinatesResponse([JsonProperty("lat")] string Lat, [JsonProperty("lon")] string Lon)
   {
   }
}
