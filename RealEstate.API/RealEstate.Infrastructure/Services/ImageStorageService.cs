
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

        public async Task<IEnumerable<ImageData>> UploadToExternalApi(IEnumerable<IFormFile> images)
        {
            var url = $"{_storageApiUrl}?key={_apiKey}";

            var uploadTasks = images.Select(async image =>
            {
                using var imageStream = image.OpenReadStream();

                using var originalImage = Image.FromStream(imageStream);

                var resizedImage = ScaleImage(originalImage, 400);

                using var memoryStream = new MemoryStream();

                resizedImage.Save(memoryStream, ImageFormat.Jpeg);

                var imageBytes = memoryStream.ToArray();

                var base64Image = Convert.ToBase64String(imageBytes);

                var stringContent = new StringContent(base64Image);

                var form = new MultipartFormDataContent
                {
                    { stringContent, "image" }
                };

                var response = await _httpClient.PostAsync(url, form);

                var jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = JsonConvert.DeserializeObject<ImageUploadResponse>(jsonResponse);

                    return apiResponse?.Data; 
                }
                else
                {
                    return null; 
                }
            });

            var results = await Task.WhenAll(uploadTasks);

            var resultList = results.Where(data => data != null).Cast<ImageData>().ToList();

            return resultList;
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
