
using Newtonsoft.Json;
using RealEstate.Domain.Common.Dtos;

namespace RealEstate.API.Contracts.Image
{
    public record ImageUploadResponse([JsonProperty("data")] ImageData Data);

}
