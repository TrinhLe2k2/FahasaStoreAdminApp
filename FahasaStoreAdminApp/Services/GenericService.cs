using Newtonsoft.Json;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public interface IGenericService<TEntity, TModel, TKey>
    where TEntity : class
    where TModel : class
    where TKey : IEquatable<TKey>
    {
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        Task<TModel> AddAsync(TModel model);
        Task<TKey> UpdateAsync(TKey id, TModel model);
        Task<bool> DeleteAsync(TKey id);
        Task<ICollection<TEntity>> GetListByAsync(string propertyName, string value);
    }

    public abstract class GenericService<TEntity, TModel, TKey> : IGenericService<TEntity, TModel, TKey>
        where TEntity : class
        where TModel : class
        where TKey : IEquatable<TKey>
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly string _apiUrl;
        public GenericService(IHttpClientFactory httpClientFactory, string apiUrl)
        {
            _httpClientFactory = httpClientFactory;
            _apiUrl = apiUrl;
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"{_apiUrl}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<TEntity>>(content);
                    return data ?? new List<TEntity>();
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
        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"{_apiUrl}/{id}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<TEntity>(content);
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
        public virtual async Task<TKey> UpdateAsync(TKey id, TModel model)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
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
        public virtual async Task<ICollection<TEntity>> GetListByAsync(string propertyName, string value)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"{_apiUrl}/GetListBy/{propertyName}/{value}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<TEntity>>(content);
                    return data ?? new List<TEntity>();
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
    }
}
