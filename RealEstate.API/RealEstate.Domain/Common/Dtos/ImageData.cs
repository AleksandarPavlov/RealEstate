

using Newtonsoft.Json;

namespace RealEstate.Domain.Common.Dtos
{
    public record ImageData([JsonProperty("display_url")] string DisplayUrl);
}
