
using RealEstate.Domain.Common.Dtos;

namespace RealEstate.Domain.Services
{
    public interface ICoordinatesService
    {
        Task<Coordinates?> FetchCoordinates(string address);
    }
}
