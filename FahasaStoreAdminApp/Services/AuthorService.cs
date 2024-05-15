using FahasaStoreAPI.Entities;
using Newtonsoft.Json;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public interface IAuthorService
    {
        Task<ICollection<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<int> AddAuthorAsync(Author Author);
        Task<int> UpdateAuthorAsync(int id, Author Author);
        Task<bool> DeleteAuthorAsync(int id);
    }
    public class AuthorService : IAuthorService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AuthorService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<Author>> GetAuthorsAsync()
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync("https://localhost:7069/api/Authors");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ICollection<Author>>(content);
                    return data ?? new List<Author>();
                }
            }
            catch (HttpRequestException ex)
            {
                // Xử lý exception, có thể ghi log hoặc thực hiện các hành động phù hợp khác
                throw new Exception("Error occurred while fetching Authors from API.", ex);
            }
            catch (JsonException ex)
            {
                // Xử lý exception phân tích cú pháp JSON
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"https://localhost:7069/api/Authors/{id}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var Author = JsonConvert.DeserializeObject<Author>(content);
                    return Author ?? new Author();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while fetching Author with ID {id} from API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> AddAuthorAsync(Author Author)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Author), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:7069/api/Authors", content);
                    response.EnsureSuccessStatusCode();
                    var createdContent = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(createdContent))
                    {
                        throw new Exception("Error: Empty response received from API while adding Author.");
                    }

                    var createdAuthor = JsonConvert.DeserializeObject<Author>(createdContent);

                    if (createdAuthor == null)
                    {
                        throw new Exception("Error: Failed to deserialize response from API while adding Author.");
                    }

                    return createdAuthor.AuthorId;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while adding Author to API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<int> UpdateAuthorAsync(int id, Author Author)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(Author), Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"https://localhost:7069/api/Authors/{id}", content);
                    response.EnsureSuccessStatusCode();
                    return id;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while updating Author with ID {id} in API.", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.DeleteAsync($"https://localhost:7069/api/Authors/{id}");
                    response.EnsureSuccessStatusCode();
                    return true;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while deleting Author with ID {id} from API.", ex);
            }
        }
    }
}
