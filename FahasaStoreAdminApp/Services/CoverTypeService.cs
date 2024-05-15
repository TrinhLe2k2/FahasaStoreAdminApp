using FahasaStoreAPI.Entities;
using Newtonsoft.Json;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public interface ICoverTypeService
    {
        Task<ICollection<CoverType>> GetCoverTypesAsync();
        Task<CoverType> GetCoverTypeByIdAsync(int id);
        Task<int> AddCoverTypeAsync(CoverType CoverType);
        Task<int> UpdateCoverTypeAsync(int id, CoverType CoverType);
        Task<bool> DeleteCoverTypeAsync(int id);
    }
    public class CoverTypeService : ICoverTypeService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CoverTypeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<CoverType>> GetCoverTypesAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync("https://localhost:7069/api/CoverTypes");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<CoverType>>(content);
                    return data ?? new List<CoverType>();
                }
            }
            catch (HttpRequestException ex)
            {
                // Xử lý exception, có thể ghi log hoặc thực hiện các hành động phù hợp khác
                throw new Exception("Error occurred while fetching CoverTypes from API.", ex);
            }
            catch (JsonException ex)
            {
                // Xử lý exception phân tích cú pháp JSON
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<CoverType> GetCoverTypeByIdAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"https://localhost:7069/api/CoverTypes/{id}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var CoverType = JsonConvert.DeserializeObject<CoverType>(content);
                    return CoverType ?? new CoverType();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching CoverType with ID {id} from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> AddCoverTypeAsync(CoverType CoverType)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(CoverType), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:7069/api/CoverTypes", content);
                    response.EnsureSuccessStatusCode();
                    var createdContent = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(createdContent))
                    {
                        throw new Exception("Error: Empty response received from API while adding CoverType.");
                    }

                    var createdCoverType = JsonConvert.DeserializeObject<CoverType>(createdContent);

                    if (createdCoverType == null)
                    {
                        throw new Exception("Error: Failed to deserialize response from API while adding CoverType.");
                    }

                    return createdCoverType.CoverTypeId;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while adding CoverType to API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> UpdateCoverTypeAsync(int id, CoverType CoverType)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(CoverType), Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"https://localhost:7069/api/CoverTypes/{id}", content);
                    response.EnsureSuccessStatusCode();
                    return id;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while updating CoverType with ID {id} in API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<bool> DeleteCoverTypeAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.DeleteAsync($"https://localhost:7069/api/CoverTypes/{id}");
                    response.EnsureSuccessStatusCode();
                    return true;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while deleting CoverType with ID {id} from API.", ex);
            }
        }
    }
}
