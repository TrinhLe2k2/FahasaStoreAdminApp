using FahasaStoreAPI.Entities;
using Newtonsoft.Json;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public interface IPartnerService
    {
        Task<ICollection<Partner>> GetPartnersAsync();
        Task<ICollection<Partner>> GetPartnersByType(int id);
        Task<Partner> GetPartnerByIdAsync(int id);
        Task<int> AddPartnerAsync(Partner Partner);
        Task<int> UpdatePartnerAsync(int id, Partner Partner);
        Task<bool> DeletePartnerAsync(int id);
    }

    public class PartnerService : IPartnerService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public PartnerService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<Partner>> GetPartnersAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync("https://localhost:7069/api/Partners");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<Partner>>(content);
                    return data ?? new List<Partner>();
                }
            }
            catch (HttpRequestException ex)
            {
                // Xử lý exception, có thể ghi log hoặc thực hiện các hành động phù hợp khác
                throw new Exception("Error occurred while fetching Partners from API.", ex);
            }
            catch (JsonException ex)
            {
                // Xử lý exception phân tích cú pháp JSON
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<Partner> GetPartnerByIdAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"https://localhost:7069/api/Partners/{id}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var Partner = JsonConvert.DeserializeObject<Partner>(content);
                    return Partner ?? new Partner();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching Partner with ID {id} from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> AddPartnerAsync(Partner Partner)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Partner), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:7069/api/Partners", content);
                    response.EnsureSuccessStatusCode();
                    var createdContent = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(createdContent))
                    {
                        throw new Exception("Error: Empty response received from API while adding Partner.");
                    }

                    var createdPartner = JsonConvert.DeserializeObject<Partner>(createdContent);

                    if (createdPartner == null)
                    {
                        throw new Exception("Error: Failed to deserialize response from API while adding Partner.");
                    }

                    return createdPartner.PartnerId;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while adding Partner to API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> UpdatePartnerAsync(int id, Partner Partner)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Partner), Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"https://localhost:7069/api/Partners/{id}", content);
                    response.EnsureSuccessStatusCode();
                    return id;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while updating Partner with ID {id} in API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<bool> DeletePartnerAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.DeleteAsync($"https://localhost:7069/api/Partners/{id}");
                    response.EnsureSuccessStatusCode();
                    return true;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while deleting Partner with ID {id} from API.", ex);
            }
        }

        public async Task<ICollection<Partner>> GetPartnersByType(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var url = $"https://localhost:7069/api/PartnerTypes/GetPartnersByType/{id}";
                    if (id == 0)
                    {
                        url = "https://localhost:7069/api/Partners";
                    }
                    var response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<Partner>>(content);
                    return data ?? new List<Partner>();
                }
            }
            catch (HttpRequestException ex)
            {
                // Xử lý exception, có thể ghi log hoặc thực hiện các hành động phù hợp khác
                throw new Exception("Error occurred while fetching Partners from API.", ex);
            }
            catch (JsonException ex)
            {
                // Xử lý exception phân tích cú pháp JSON
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }
    }
}
