
using RealEstate.Domain.Common.Dtos;

namespace RealEstate.Domain.Services
{
    public interface ICoordinatesService
    {
        Task<CoordinatesResponse?> FetchCoordinates(string address);
    }
}
