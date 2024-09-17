﻿
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RealEstate.Domain.Common.Dtos;
using RealEstate.Domain.Services;

namespace RealEstate.Infrastructure.Services
{
    public class CoordinatesService : ICoordinatesService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string? _apiKey;

        public CoordinatesService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiKey = _configuration["Geocode:Key"];
        }

        public async Task<CoordinatesResponse?> FetchCoordinates(string address)
        {
            try
            {
                var url = $"https://geocode.maps.co/search?q={Uri.EscapeDataString(address)}&api_key={_apiKey}";

                var response = await _httpClient.GetStringAsync(url);

                var coordinatesList = JsonConvert.DeserializeObject<List<CoordinatesResponse>>(response);

                if (coordinatesList == null || coordinatesList.Count == 0)
                {
                    return null;
                }

                return coordinatesList[0];

                }

                catch (HttpRequestException e)
                {
                    throw new Exception("Error fetching coordinates", e);
                }
        
        }

    }
}

