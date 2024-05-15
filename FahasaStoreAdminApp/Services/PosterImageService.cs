using FahasaStoreAPI.Entities;
using Newtonsoft.Json;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public interface IPosterImageService
    {
        Task<ICollection<PosterImage>> GetPosterImagesAsync();
        Task<PosterImage> GetPosterImageByIdAsync(int id);
        Task<int> AddPosterImageAsync(PosterImage PosterImage);
        Task<int> UpdatePosterImageAsync(int id, PosterImage PosterImage);
        Task<bool> DeletePosterImageAsync(int id);
    }

    public class PosterImageService : IPosterImageService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public PosterImageService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<PosterImage>> GetPosterImagesAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync("https://localhost:7069/api/PosterImages");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<PosterImage>>(content);
                    return data ?? new List<PosterImage>();
                }
            }
            catch (HttpRequestException ex)
            {
                // Xử lý exception, có thể ghi log hoặc thực hiện các hành động phù hợp khác
                throw new Exception("Error occurred while fetching PosterImages from API.", ex);
            }
            catch (JsonException ex)
            {
                // Xử lý exception phân tích cú pháp JSON
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<PosterImage> GetPosterImageByIdAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"https://localhost:7069/api/PosterImages/{id}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var PosterImage = JsonConvert.DeserializeObject<PosterImage>(content);
                    return PosterImage ?? new PosterImage();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching PosterImage with ID {id} from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> AddPosterImageAsync(PosterImage PosterImage)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(PosterImage), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:7069/api/PosterImages", content);
                    response.EnsureSuccessStatusCode();
                    var createdContent = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(createdContent))
                    {
                        throw new Exception("Error: Empty response received from API while adding PosterImage.");
                    }

                    var createdPosterImage = JsonConvert.DeserializeObject<PosterImage>(createdContent);

                    if (createdPosterImage == null)
                    {
                        throw new Exception("Error: Failed to deserialize response from API while adding PosterImage.");
                    }

                    return createdPosterImage.PosterImgageId;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while adding PosterImage to API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> UpdatePosterImageAsync(int id, PosterImage PosterImage)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(PosterImage), Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"https://localhost:7069/api/PosterImages/{id}", content);
                    response.EnsureSuccessStatusCode();
                    return id;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while updating PosterImage with ID {id} in API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<bool> DeletePosterImageAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.DeleteAsync($"https://localhost:7069/api/PosterImages/{id}");
                    response.EnsureSuccessStatusCode();
                    return true;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while deleting PosterImage with ID {id} from API.", ex);
            }
        }
    }
}
