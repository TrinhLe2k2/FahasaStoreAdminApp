using FahasaStoreAdminApp.Interfaces;
using FahasaStoreAPI.Models.EntitiesModels;
using FahasaStoreAPI.Models.FormModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public class PartnerTypeService : IPartnerTypeService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public PartnerTypeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<PartnerTypeEntities>> GetPartnerTypesAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync("https://localhost:7069/api/PartnerTypes");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<PartnerTypeEntities>>(content);
                    return data ?? new List<PartnerTypeEntities>();
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

        public async Task<PartnerTypeEntities> GetPartnerTypeByIdAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"https://localhost:7069/api/PartnerTypes/{id}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var PartnerType = JsonConvert.DeserializeObject<PartnerTypeEntities>(content);
                    return PartnerType ?? new PartnerTypeEntities();
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

        public async Task<int> AddPartnerTypeAsync(PartnerTypeForm PartnerType)
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

                    var createdPartnerType = JsonConvert.DeserializeObject<PartnerTypeEntities>(createdContent);

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

        public async Task<int> UpdatePartnerTypeAsync(int id, PartnerTypeForm PartnerType)
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
