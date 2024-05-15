using FahasaStoreAPI.Entities;
using Newtonsoft.Json;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public interface ISocialMediaLinkService
    {
        Task<ICollection<SocialMediaLink>> GetSocialMediaLinksAsync();
        Task<SocialMediaLink> GetSocialMediaLinkByIdAsync(int id);
        Task<int> AddSocialMediaLinkAsync(SocialMediaLink SocialMediaLink);
        Task<int> UpdateSocialMediaLinkAsync(int id, SocialMediaLink SocialMediaLink);
        Task<bool> DeleteSocialMediaLinkAsync(int id);
    }
    public class SocialMediaLinkService : ISocialMediaLinkService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SocialMediaLinkService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<SocialMediaLink>> GetSocialMediaLinksAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync("https://localhost:7069/api/SocialMediaLinks");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<SocialMediaLink>>(content);
                    return data ?? new List<SocialMediaLink>();
                }
            }
            catch (HttpRequestException ex)
            {
                // Xử lý exception, có thể ghi log hoặc thực hiện các hành động phù hợp khác
                throw new Exception("Error occurred while fetching SocialMediaLinks from API.", ex);
            }
            catch (JsonException ex)
            {
                // Xử lý exception phân tích cú pháp JSON
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<SocialMediaLink> GetSocialMediaLinkByIdAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"https://localhost:7069/api/SocialMediaLinks/{id}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var SocialMediaLink = JsonConvert.DeserializeObject<SocialMediaLink>(content);
                    return SocialMediaLink ?? new SocialMediaLink();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching SocialMediaLink with ID {id} from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> AddSocialMediaLinkAsync(SocialMediaLink SocialMediaLink)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(SocialMediaLink), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:7069/api/SocialMediaLinks", content);
                    response.EnsureSuccessStatusCode();
                    var createdContent = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(createdContent))
                    {
                        throw new Exception("Error: Empty response received from API while adding SocialMediaLink.");
                    }

                    var createdSocialMediaLink = JsonConvert.DeserializeObject<SocialMediaLink>(createdContent);

                    if (createdSocialMediaLink == null)
                    {
                        throw new Exception("Error: Failed to deserialize response from API while adding SocialMediaLink.");
                    }

                    return createdSocialMediaLink.LinkId;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while adding SocialMediaLink to API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> UpdateSocialMediaLinkAsync(int id, SocialMediaLink SocialMediaLink)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(SocialMediaLink), Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"https://localhost:7069/api/SocialMediaLinks/{id}", content);
                    response.EnsureSuccessStatusCode();
                    return id;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while updating SocialMediaLink with ID {id} in API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<bool> DeleteSocialMediaLinkAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.DeleteAsync($"https://localhost:7069/api/SocialMediaLinks/{id}");
                    response.EnsureSuccessStatusCode();
                    return true;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while deleting SocialMediaLink with ID {id} from API.", ex);
            }
        }
    }
}
