

using Microsoft.AspNetCore.Http;
using RealEstate.Domain.Common.Dtos;

namespace RealEstate.Domain.Services
{
    public interface IImageStorageService
    {
        Task<IEnumerable<ImageData>> UploadToExternalApi(IEnumerable<IFormFile> images);
    }
}
