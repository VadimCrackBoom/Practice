using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TodoApiClient.Interfaces;
using TodoApiClient.Models.Requests;
using TodoApiClient.Models.Responses;

namespace TodoApiClient.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://45.144.64.179/api/auth/";
        private string _currentUserEmail;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("login",
                    new { Email = email, Password = password });

                if (response.IsSuccessStatusCode)
                {
                    var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();
                    _currentUserEmail = email;
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", authResponse.Token);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RegisterAsync(string name, string email, string password)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("register",
                    new { Email = email, Password = password, Name = name });

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public string GetCurrentUserEmail() => _currentUserEmail;
        public bool IsAuthenticated() => !string.IsNullOrEmpty(_currentUserEmail);
    }
}