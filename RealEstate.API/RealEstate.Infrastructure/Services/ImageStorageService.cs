
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RealEstate.API.Contracts.Image;
using RealEstate.Domain.Common.Dtos;
using RealEstate.Domain.Services;
using System.Drawing;
using System.Drawing.Imaging;


namespace RealEstate.Infrastructure.Services
{
    public class ImageStorageService : IImageStorageService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string? _apiKey;
        private readonly string? _storageApiUrl;

        public ImageStorageService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiKey = _configuration["ImageStorage:Key"];
            _storageApiUrl = _configuration["ImageStorage:ApiUrl"];
        }

        public async Task<ImageData?> UploadToExternalApi(IFormFile? image)
        {
            if (image == null) {
                return null;
            }
            using var imageStream = image.OpenReadStream();

            using var originalImage = Image.FromStream(imageStream);

            var resizedImage = ScaleImage(originalImage, 400);

            using var memoryStream = new MemoryStream();

            resizedImage.Save(memoryStream, ImageFormat.Jpeg);

            var imageBytes = memoryStream.ToArray();

            var base64Image = Convert.ToBase64String(imageBytes);

            var form = new MultipartFormDataContent
            {
                { new StringContent(base64Image), "image" }
            };

            var url = $"{_storageApiUrl}?key={_apiKey}";

            var response = await _httpClient.PostAsync(url, form);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ImageUploadResponse>(jsonResponse);

                if (apiResponse == null) {
                    return null;
                }

                return apiResponse.Data;
            }
            else
            {           
                throw new Exception($"Image upload failed with status {response.StatusCode}");
            }
        }

        private static Image ScaleImage(Image image, int height)
        {
            double ratio = (double)height / image.Height;

            int newWidth = (int)(image.Width * ratio);

            int newHeight = (int)(image.Height * ratio);

            Bitmap newImage = new(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            image.Dispose();

            return newImage;
        }
    }
}
