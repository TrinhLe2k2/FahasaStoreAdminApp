using FahasaStoreAdminApp.Interfaces;
using FahasaStoreAPI.Models.EntitiesModels;
using FahasaStoreAPI.Models.FormModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public class SubcategoryService : ISubcategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SubcategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<SubcategoryEntities>> GetSubcategoriesAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync("https://localhost:7069/api/Subcategories");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<SubcategoryEntities>>(content);
                    return data ?? new List<SubcategoryEntities>();
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

        public async Task<SubcategoryEntities> GetSubcategoryByIdAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"https://localhost:7069/api/Subcategories/{id}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var Subcategory = JsonConvert.DeserializeObject<SubcategoryEntities>(content);
                    return Subcategory ?? new SubcategoryEntities();
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

        public async Task<int> AddSubcategoryAsync(SubcategoryForm Subcategory)
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

                    var createdSubcategory = JsonConvert.DeserializeObject<SubcategoryEntities>(createdContent);

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

        public async Task<int> UpdateSubcategoryAsync(int id, SubcategoryForm Subcategory)
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

        public async Task<ICollection<SubcategoryEntities>> GetSubcategoriesByCategoryID(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var url = $"https://localhost:7069/api/Subcategories/GetSubcategoriesByCategoryID/{id}";
                    if (id == 0)
                    {
                        url = "https://localhost:7069/api/Subcategories";
                    }
                    var response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<SubcategoryEntities>>(content);
                    return data ?? new List<SubcategoryEntities>();
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
    }
}
