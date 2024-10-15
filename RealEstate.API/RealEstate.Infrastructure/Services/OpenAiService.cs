using System.Text;
using System.Text.Json;
using RealEstate.Domain.Common.Enums;
using RealEstate.Domain.Services;
using Microsoft.Extensions.Configuration;
using RealEstate.Domain.Common.Errors;

namespace RealEstate.Infrastructure.Services;

    public class OpenAiService : IOpenAiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string? _apiKey;
        private readonly string? _openAiApiUrl;

        public OpenAiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiKey = _configuration["OpenAI:Key"];
            _openAiApiUrl = _configuration["OpenAI:ApiUrl"];
        }
        
        public async Task<Result<string?>> GeneratePropertyDescription(string address, string size, PropertyListingType listingType,
            PropertyType propertyType)
        {

            if (string.IsNullOrEmpty(_apiKey) || string.IsNullOrEmpty(_openAiApiUrl))
            {
                throw new InvalidOperationException("Invalid configuration");
            }
            
            var requestBody = new
            {
                model = "gpt-3.5-turbo", 
                messages = new[]
                {
                    new { role = "user", content = $"Write a professional property description in Serbian language of max 200 characters. This is the given property: address is {address}, size is {size}, listing type is {listingType} and property type is {propertyType}." }
                }
            };
            
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            
            var response = await _httpClient.PostAsync($"{_openAiApiUrl}", content);

            if (!response.IsSuccessStatusCode) return Result<string?>.Failure(new Error("PropertyDescription", "Failed to generate property description."));
            
            var responseContent = await response.Content.ReadAsStringAsync();
            
            var jsonResponse = JsonDocument.Parse(responseContent);
            
            var contentText = jsonResponse.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return Result<string?>.Success(contentText);

        }
    }