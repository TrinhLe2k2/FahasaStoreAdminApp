﻿using FahasaStoreAdminApp.Interfaces;
using FahasaStoreAPI.Models.EntitiesModels;
using FahasaStoreAPI.Models.FormModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<CategoryEntities>> GetCategorysAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync("https://localhost:7069/api/Categories");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<CategoryEntities>>(content);
                    return data ?? new List<CategoryEntities>();
                }
            }
            catch (HttpRequestException ex)
            {
                // Xử lý exception, có thể ghi log hoặc thực hiện các hành động phù hợp khác
                throw new Exception("Error occurred while fetching Categorys from API.", ex);
            }
            catch (JsonException ex)
            {
                // Xử lý exception phân tích cú pháp JSON
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<CategoryEntities> GetCategoryByIdAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"https://localhost:7069/api/Categories/{id}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var Category = JsonConvert.DeserializeObject<CategoryEntities>(content);
                    return Category ?? new CategoryEntities();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching Category with ID {id} from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> AddCategoryAsync(CategoryForm Category)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Category), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:7069/api/Categories", content);
                    response.EnsureSuccessStatusCode();
                    var createdContent = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(createdContent))
                    {
                        throw new Exception("Error: Empty response received from API while adding Category.");
                    }

                    var createdCategory = JsonConvert.DeserializeObject<CategoryEntities>(createdContent);

                    if (createdCategory == null)
                    {
                        throw new Exception("Error: Failed to deserialize response from API while adding Category.");
                    }

                    return createdCategory.CategoryId;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while adding Category to API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> UpdateCategoryAsync(int id, CategoryForm Category)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Category), Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"https://localhost:7069/api/Categories/{id}", content);
                    response.EnsureSuccessStatusCode();
                    return id;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while updating Category with ID {id} in API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.DeleteAsync($"https://localhost:7069/api/Categories/{id}");
                    response.EnsureSuccessStatusCode();
                    return true;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while deleting Category with ID {id} from API.", ex);
            }
        }
    }
}
