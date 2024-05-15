using FahasaStoreAPI.Entities;
using Newtonsoft.Json;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public interface IPartnerTypeService
    {
        Task<ICollection<PartnerType>> GetPartnerTypesAsync();
        Task<PartnerType> GetPartnerTypeByIdAsync(int id);
        Task<int> AddPartnerTypeAsync(PartnerType PartnerType);
        Task<int> UpdatePartnerTypeAsync(int id, PartnerType PartnerType);
        Task<bool> DeletePartnerTypeAsync(int id);
    }
    public class PartnerTypeService : IPartnerTypeService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public PartnerTypeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<PartnerType>> GetPartnerTypesAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync("https://localhost:7069/api/PartnerTypes");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<PartnerType>>(content);
                    return data ?? new List<PartnerType>();
                }
            }
            catch (HttpRequestException ex)
            {
                // Xử lý exception, có thể ghi log hoặc thực hiện các hành động phù hợp khác
                throw new Exception("Error occurred while fetching PartnerTypes from API.", ex);
            }
            catch (JsonException ex)
            {
                // Xử lý exception phân tích cú pháp JSON
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<PartnerType> GetPartnerTypeByIdAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"https://localhost:7069/api/PartnerTypes/{id}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var PartnerType = JsonConvert.DeserializeObject<PartnerType>(content);
                    return PartnerType ?? new PartnerType();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching PartnerType with ID {id} from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> AddPartnerTypeAsync(PartnerType PartnerType)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(PartnerType), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:7069/api/PartnerTypes", content);
                    response.EnsureSuccessStatusCode();
                    var createdContent = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(createdContent))
                    {
                        throw new Exception("Error: Empty response received from API while adding PartnerType.");
                    }

                    var createdPartnerType = JsonConvert.DeserializeObject<PartnerType>(createdContent);

                    if (createdPartnerType == null)
                    {
                        throw new Exception("Error: Failed to deserialize response from API while adding PartnerType.");
                    }

                    return createdPartnerType.PartnerTypeId;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while adding PartnerType to API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> UpdatePartnerTypeAsync(int id, PartnerType PartnerType)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(PartnerType), Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"https://localhost:7069/api/PartnerTypes/{id}", content);
                    response.EnsureSuccessStatusCode();
                    return id;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while updating PartnerType with ID {id} in API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<bool> DeletePartnerTypeAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.DeleteAsync($"https://localhost:7069/api/PartnerTypes/{id}");
                    response.EnsureSuccessStatusCode();
                    return true;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while deleting PartnerType with ID {id} from API.", ex);
            }
        }
    }
}
