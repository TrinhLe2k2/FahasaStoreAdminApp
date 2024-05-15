using FahasaStoreAPI.Entities;
using Newtonsoft.Json;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public interface IHomeService
    {
        Task<int> UpdateWebsite(Website Website);
        Task<Website> GetWebsiteByIdAsync();
    }
    public class HomeService : IHomeService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Website> GetWebsiteByIdAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"https://localhost:7069/api/Websites/1");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var Website = JsonConvert.DeserializeObject<Website>(content);
                    return Website ?? new Website();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching Website with ID  from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> UpdateWebsite(Website Website)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Website), Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"https://localhost:7069/api/Websites/1", content);
                    response.EnsureSuccessStatusCode();
                    return 1;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while updating Website with ID in API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }
    }
}
