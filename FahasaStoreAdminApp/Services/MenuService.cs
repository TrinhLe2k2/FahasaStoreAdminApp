using FahasaStoreAPI.Entities;
using Newtonsoft.Json;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public interface IMenuService
    {
        Task<ICollection<Menu>> GetMenusAsync();
        Task<Menu> GetMenuByIdAsync(int id);
        Task<int> AddMenuAsync(Menu Menu);
        Task<int> UpdateMenuAsync(int id, Menu Menu);
        Task<bool> DeleteMenuAsync(int id);
    }
    public class MenuService : IMenuService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<Menu>> GetMenusAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync("https://localhost:7069/api/Menus");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<Menu>>(content);
                    return data ?? new List<Menu>();
                }
            }
            catch (HttpRequestException ex)
            {
                // Xử lý exception, có thể ghi log hoặc thực hiện các hành động phù hợp khác
                throw new Exception("Error occurred while fetching Menus from API.", ex);
            }
            catch (JsonException ex)
            {
                // Xử lý exception phân tích cú pháp JSON
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<Menu> GetMenuByIdAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"https://localhost:7069/api/Menus/{id}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var Menu = JsonConvert.DeserializeObject<Menu>(content);
                    return Menu ?? new Menu();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching Menu with ID {id} from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> AddMenuAsync(Menu Menu)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Menu), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:7069/api/Menus", content);
                    response.EnsureSuccessStatusCode();
                    var createdContent = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(createdContent))
                    {
                        throw new Exception("Error: Empty response received from API while adding Menu.");
                    }

                    var createdMenu = JsonConvert.DeserializeObject<Menu>(createdContent);

                    if (createdMenu == null)
                    {
                        throw new Exception("Error: Failed to deserialize response from API while adding Menu.");
                    }

                    return createdMenu.MenuId;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while adding Menu to API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> UpdateMenuAsync(int id, Menu Menu)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Menu), Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"https://localhost:7069/api/Menus/{id}", content);
                    response.EnsureSuccessStatusCode();
                    return id;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while updating Menu with ID {id} in API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<bool> DeleteMenuAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.DeleteAsync($"https://localhost:7069/api/Menus/{id}");
                    response.EnsureSuccessStatusCode();
                    return true;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while deleting Menu with ID {id} from API.", ex);
            }
        }
    }
}
