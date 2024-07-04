using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.DTO;
using FahasaStoreAdminApp.Models.EModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public interface IHomeService
    {
        Task<int> UpdateWebsite(Website Website);
        Task<Website> GetWebsiteByIdAsync();
        Task<ICollection<WebsiteModel>> GetAllWebsiteAsync();
        Task<ICollection<MonthlyStatisticsDTO>> GetYearlyStatistics(int? year);
    }
    public class HomeService : IHomeService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserLogined _userLogined;
        public HomeService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
        {
            _httpClientFactory = httpClientFactory;
            _userLogined = userLogined;
        }

        public async Task<Website> GetWebsiteByIdAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
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
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
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

        public async Task<ICollection<MonthlyStatisticsDTO>> GetYearlyStatistics(int? year)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                    var response = await httpClient.GetAsync($"https://localhost:7069/api/Statistics/GetYearlyStatistics?year={year}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<MonthlyStatisticsDTO>>(content);
                    return data ?? new List<MonthlyStatisticsDTO>();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<ICollection<WebsiteModel>> GetAllWebsiteAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                    var response = await httpClient.GetAsync($"https://localhost:7069/api/Websites");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var Websites = JsonConvert.DeserializeObject<ICollection<WebsiteModel>>(content);
                    return Websites ?? new List<WebsiteModel>();
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
    }
}
