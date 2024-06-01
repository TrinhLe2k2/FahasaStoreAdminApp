using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Models.DTOModel;
using FahasaStoreAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace FahasaStoreAdminApp.Services
{
    public interface IAccountService
    {
        public Task<string> LogInAsync(LogInModel model);
        Task<bool> LogOutAsync(string accessToken);
    }
    public class AccountService : IAccountService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AccountService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> LogInAsync(LogInModel model)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:7069/api/Accounts/SignIn", content);
                    response.EnsureSuccessStatusCode();
                    var createdContent = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrWhiteSpace(createdContent))
                    {
                        throw new Exception("Error: Empty response received from API while logging in.");
                    }
                    return createdContent;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while logging in.", ex);
            }
        }

        public async Task<bool> LogOutAsync(string accessToken)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7069/api/Accounts/SignOut");
                    // Thêm token vào header Authorization
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    var response = await httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    return true;
                }
            }
            catch (HttpRequestException ex)
            {
                // Xử lý exception, có thể ghi log hoặc thực hiện các hành động phù hợp khác
                throw new Exception("Error occurred while logging out via API.", ex);
            }
            catch (JsonException ex)
            {
                // Xử lý exception phân tích cú pháp JSON
                throw new Exception("Error occurred while parsing JSON response.", ex);
            }
        }

    }
}
