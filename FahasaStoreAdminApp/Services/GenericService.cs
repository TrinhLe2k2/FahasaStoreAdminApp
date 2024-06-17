using Azure.Core;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.Response;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public interface IGenericService<TEntity, TModel, DTO, TKey>
    where TEntity : class
    where TModel : class
    where DTO : class
    where TKey : IEquatable<TKey>
    {
        Task<ICollection<DTO>> GetAllAsync();
        Task<DTO> GetByIdAsync(TKey id);
        Task<TModel> AddAsync(TModel model);
        Task<TModel> GetItemUpdateByIdAsync(TKey id);
        Task<TKey> UpdateAsync(TKey id, TModel model);
        Task<bool> DeleteAsync(TKey id);
        Task<PaginatedResponse<DTO>> GetListByAsync(string propertyName, string value, int page = 1, int size = 10);
        Task<PaginatedResponse<DTO>> GetPagination(int page = 1, int size = 10);
        Task<PaginatedResponse<DTO>> GetFilteredPagination(
            Dictionary<string, string>? filters,
            string? sortField,
            string? sortDirection,
            int page = 1,
            int size = 10);
    }

    public abstract class GenericService<TEntity, TModel, DTO, TKey> : IGenericService<TEntity, TModel, DTO, TKey>
        where TEntity : class
        where TModel : class
        where DTO : class
        where TKey : IEquatable<TKey>
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly string _apiUrl;
        private readonly UserLogined _userLogined;
        public GenericService(IHttpClientFactory httpClientFactory, string apiUrl, UserLogined userLogined)
        {
            _httpClientFactory = httpClientFactory;
            _apiUrl = apiUrl;
            _userLogined = userLogined;
        }

        public virtual async Task<ICollection<DTO>> GetAllAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                    var response = await httpClient.GetAsync($"{_apiUrl}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<DTO>>(content);
                    return data ?? new List<DTO>();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while fetching data from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }
        public virtual async Task<DTO> GetByIdAsync(TKey id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                    var response = await httpClient.GetAsync($"{_apiUrl}/{id}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<DTO>(content);
                    return data ?? throw new Exception("Received null data from API.");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching ${nameof(TEntity)} with ID {id} from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }
        public virtual async Task<TModel> AddAsync(TModel model)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(_apiUrl, content);
                    response.EnsureSuccessStatusCode();
                    var createdContent = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(createdContent))
                    {
                        throw new Exception($"Error: Empty response received from API while adding ${typeof(TEntity).Name}.");
                    }

                    var created = JsonConvert.DeserializeObject<TModel>(createdContent);

                    if (created == null)
                    {
                        throw new Exception($"Error: Failed to deserialize response from API while adding ${typeof(TEntity).Name}.");
                    }

                    return created;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while adding ${nameof(TEntity)} to API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }
        public virtual async Task<TModel> GetItemUpdateByIdAsync(TKey id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                    var response = await httpClient.GetAsync($"{_apiUrl}/{id}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<TModel>(content);
                    return data ?? throw new Exception("Received null data from API.");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching ${nameof(TEntity)} with ID {id} from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }
        public virtual async Task<TKey> UpdateAsync(TKey id, TModel model)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"{_apiUrl}/{id}", content);
                    response.EnsureSuccessStatusCode();
                    return id;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while updating ${nameof(TEntity)} with ID {id} in API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }
        public virtual async Task<bool> DeleteAsync(TKey id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                    var response = await httpClient.DeleteAsync($"{_apiUrl}/{id}");
                    response.EnsureSuccessStatusCode();
                    return true;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while deleting ${nameof(TEntity)} with ID {id} from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }
        public virtual async Task<PaginatedResponse<DTO>> GetListByAsync(string propertyName, string value, int page = 1, int size = 10)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                    var response = await httpClient.GetAsync($"{_apiUrl}/GetListBy/{propertyName}/{value}?page={page}&size={size}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<PaginatedResponse<DTO>>(content);
                    return data ?? new PaginatedResponse<DTO>();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching list of {nameof(TEntity)} with {propertyName} '{value}' from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }
        public virtual async Task<PaginatedResponse<DTO>> GetPagination(int page = 1, int size = 10)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                    var response = await httpClient.GetAsync($"{_apiUrl}/Pagination?page={page}&size={size}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<PaginatedResponse<DTO>>(content);
                    return data ?? new PaginatedResponse<DTO>();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching list from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }
        public virtual async Task<PaginatedResponse<DTO>> GetFilteredPagination(
            Dictionary<string, string>? filters,
            string? sortField,
            string? sortDirection,
            int page = 1,
            int size = 10)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                    // Xử lý filters để thêm vào URL query
                    var filtersQuery = string.Empty;
                    if (filters != null && filters.Count > 0)
                    {
                        filtersQuery = string.Join("&", filters.Select(kv => $"{kv.Key}={kv.Value}"));
                    }

                    // Tạo URL truy vấn với filters và các tham số khác
                    var endpointUrl = $"{_apiUrl}/FilterPagination?page={page}&size={size}";
                    if (!string.IsNullOrEmpty(filtersQuery))
                    {
                        endpointUrl += $"&{filtersQuery}";
                    }

                    var response = await httpClient.GetAsync(endpointUrl);
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<PaginatedResponse<DTO>>(content);
                    return data ?? new PaginatedResponse<DTO>();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching list from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }
    }
}
