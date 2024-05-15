using FahasaStoreAPI.Entities;
using Newtonsoft.Json;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public interface ISubcategoryService
    {
        Task<ICollection<Subcategory>> GetSubcategoriesAsync();
        Task<Subcategory> GetSubcategoryByIdAsync(int id);
        Task<int> AddSubcategoryAsync(Subcategory Subcategory);
        Task<int> UpdateSubcategoryAsync(int id, Subcategory Subcategory);
        Task<bool> DeleteSubcategoryAsync(int id);
        Task<ICollection<Subcategory>> GetSubcategoriesByCategoryAsync(int id);
    }

    public class SubcategoryService : ISubcategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SubcategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<Subcategory>> GetSubcategoriesAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync("https://localhost:7069/api/Subcategories");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<Subcategory>>(content);
                    return data ?? new List<Subcategory>();
                }
            }
            catch (HttpRequestException ex)
            {
                // Xử lý exception, có thể ghi log hoặc thực hiện các hành động phù hợp khác
                throw new Exception("Error occurred while fetching Subcategorys from API.", ex);
            }
            catch (JsonException ex)
            {
                // Xử lý exception phân tích cú pháp JSON
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<Subcategory> GetSubcategoryByIdAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"https://localhost:7069/api/Subcategories/{id}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var Subcategory = JsonConvert.DeserializeObject<Subcategory>(content);
                    return Subcategory ?? new Subcategory();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching Subcategory with ID {id} from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> AddSubcategoryAsync(Subcategory Subcategory)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Subcategory), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:7069/api/Subcategories", content);
                    response.EnsureSuccessStatusCode();
                    var createdContent = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(createdContent))
                    {
                        throw new Exception("Error: Empty response received from API while adding Subcategory.");
                    }

                    var createdSubcategory = JsonConvert.DeserializeObject<Subcategory>(createdContent);

                    if (createdSubcategory == null)
                    {
                        throw new Exception("Error: Failed to deserialize response from API while adding Subcategory.");
                    }

                    return createdSubcategory.SubcategoryId;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while adding Subcategory to API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> UpdateSubcategoryAsync(int id, Subcategory Subcategory)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Subcategory), Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"https://localhost:7069/api/Subcategories/{id}", content);
                    response.EnsureSuccessStatusCode();
                    return id;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while updating Subcategory with ID {id} in API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<ICollection<Subcategory>> GetSubcategoriesByCategoryAsync(int id)
        {
            try
            {
                var url = $"https://localhost:7069/api/Categories/GetSubcategories/{id}";
                if (id == 0) url = "https://localhost:7069/api/Subcategories";
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<Subcategory>>(content);
                    return data ?? new List<Subcategory>();
                }
            }
            catch (HttpRequestException ex)
            {
                // Xử lý exception, có thể ghi log hoặc thực hiện các hành động phù hợp khác
                throw new Exception("Error occurred while fetching Subcategorys from API.", ex);
            }
            catch (JsonException ex)
            {
                // Xử lý exception phân tích cú pháp JSON
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<bool> DeleteSubcategoryAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.DeleteAsync($"https://localhost:7069/api/Subcategories/{id}");
                    response.EnsureSuccessStatusCode();
                    return true;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while deleting Subcategory with ID {id} from API.", ex);
            }
        }
    }
}
