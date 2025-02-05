using IOU.Models;
using IOU.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace IOU.Services.Implementations
{
    public class RegistrationService : IRegistrationService
    {
        private readonly HttpClient _client;
        private readonly ILogger<RegistrationService> _logger;
        public RegistrationService(HttpClient client,ILogger<RegistrationService> logger)
        {
            _logger = logger;
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:7010/");
        }
        public async Task<User> Login(string email, string password)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    _logger.LogError("Email or password is null or empty.");
                    throw new ArgumentException("Email and password are required.");
                }

                // Ensure HttpClient and BaseAddress are initialized
                if (_client == null)
                {
                    _logger.LogError("HttpClient is null.");
                    throw new InvalidOperationException("HttpClient is not initialized.");
                }

                if (_client.BaseAddress == null)
                {
                    _logger.LogError("HttpClient.BaseAddress is null.");
                    throw new InvalidOperationException("HttpClient.BaseAddress is not set.");
                }

                // Encode email and password for URL
                string encodedEmail = Uri.EscapeDataString(email);
                string encodedPassword = Uri.EscapeDataString(password);

                // Construct the full URL
                string url = $"api/user/login?email={encodedEmail}&password={encodedPassword}";

                _logger.LogInformation($"Attempting login request to: {_client.BaseAddress}{url}");

                // Send the HTTP GET request
                HttpResponseMessage response = await _client.GetAsync(url);

                _logger.LogInformation($"Response status code: {response.StatusCode}");

                // Read the raw response content
                string rawResponse = await response.Content.ReadAsStringAsync();
                _logger.LogInformation($"Response content: {rawResponse}");

                // Handle the response
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response into a User object
                    var userResponse = await response.Content.ReadFromJsonAsync<User>();
                    if (userResponse == null)
                    {
                        _logger.LogError("Failed to deserialize user response.");
                        throw new InvalidOperationException("Invalid response from server.");
                    }

                    return userResponse;
                }

                _logger.LogError($"Failed request. Status: {response.StatusCode}, Content: {rawResponse}");
                throw new HttpRequestException($"Login failed: {rawResponse}");
            }
            catch (HttpRequestException httpEx)
            {
                _logger.LogError($"HTTP request failed: {httpEx.Message}");
                _logger.LogError($"Stack trace: {httpEx.StackTrace}");
                throw;
            }
            catch (JsonException jsonEx)
            {
                _logger.LogError($"Failed to deserialize response: {jsonEx.Message}");
                _logger.LogError($"Stack trace: {jsonEx.StackTrace}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception during login: {ex.Message}");
                _logger.LogError($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        public async Task<bool> Register(User user)
        {
            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync("api/user", user);
                if (!response.IsSuccessStatusCode)
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    await Shell.Current.DisplayAlert("Error", errorResponse, "Ok");
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return false;
            }
        }
        public async Task<bool> RegisterStudent(Student student)
        {
            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync("api/student", student);
                if (!response.IsSuccessStatusCode)
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    await Shell.Current.DisplayAlert("Error", errorResponse, "Ok");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return false;
            }
        }
        public async Task<bool> RegisterGuardian(Guardian guardian, StudentGuardian studentGuardian)
        {
            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync("api/guardian", guardian);
                if (!response.IsSuccessStatusCode)
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    await Shell.Current.DisplayAlert("Error", errorResponse, "Ok");
                    return false;
                }
                HttpResponseMessage response2 = await _client.PostAsJsonAsync("api/studentguardian", studentGuardian);
                if (!response2.IsSuccessStatusCode)
                {
                    string errorResponse = await response2.Content.ReadAsStringAsync();
                    await Shell.Current.DisplayAlert("Error", errorResponse, "Ok");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return false;
            }
        }
        public async Task<bool> RegisterLender(Lender lender)
        {
            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync("api/lender", lender);
                if (!response.IsSuccessStatusCode)
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    await Shell.Current.DisplayAlert("Error", errorResponse, "Ok");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return false;
            }
        }
    }
}
