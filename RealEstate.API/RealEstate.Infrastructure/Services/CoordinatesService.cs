
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RealEstate.API.Contracts.Coordinates;
using RealEstate.Domain.Common.Dtos;
using RealEstate.Domain.Services;

namespace RealEstate.Infrastructure.Services
{
    public class CoordinatesService : ICoordinatesService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string? _apiKey;
        private readonly string? _geoApiUrl;

        public CoordinatesService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiKey = _configuration["Geocode:Key"];
            _geoApiUrl = _configuration["Geocode:ApiUrl"];
        }

        public async Task<Coordinates?> FetchCoordinates(string city, string? address)
        {
            try
            {
                var location = (city + ", " + address).Trim();

                var url = $"{_geoApiUrl}/search?q={Uri.EscapeDataString(location)}&api_key={_apiKey}";

                var response = await _httpClient.GetStringAsync(url);

                var coordinatesList = JsonConvert.DeserializeObject<List<CoordinatesResponse>>(response);

                if (coordinatesList == null || coordinatesList.Count == 0)
                {
                    return null;
                }

                var firstCoordinatesMatch = coordinatesList[0];

                var coordinates = new Coordinates(firstCoordinatesMatch.Lat, firstCoordinatesMatch.Lon);

                return coordinates;

                }

                catch (HttpRequestException e)
                {
                    throw new Exception("Error fetching coordinates", e);
            }
        
        }

    }
}

