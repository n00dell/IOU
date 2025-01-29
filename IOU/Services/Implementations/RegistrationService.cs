using IOU.Models;
using IOU.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace IOU.Services.Implementations
{
    internal class RegistrationService : IRegistrationService
    {
        private readonly HttpClient _client;
        private readonly ILogger<RegistrationService> _logger;
        public RegistrationService(ILogger<RegistrationService> logger)
        {
            _logger = logger;
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7010/");
        }
        public async Task<User> Login(string email, string password)
        {
            try
            {
                string encodedEmail = Uri.EscapeDataString(email);
                string encodedPassword = Uri.EscapeDataString(password);
                string url = $"api/user/login?email={encodedEmail}&password={encodedPassword}";
                string fullurl = $"{_client.BaseAddress}{url}";
                _logger.LogInformation($"Attempting login request to: {fullurl}");
                HttpResponseMessage response = await _client.GetAsync(url);
                _logger.LogInformation($"Response status code: {response.StatusCode}");

                string rawResponse = await response.Content.ReadAsStringAsync();
                _logger.LogInformation($"Response content: {rawResponse}");
                if (response.IsSuccessStatusCode)
                {
                    var userresponse = await response.Content.ReadFromJsonAsync<User>();
                    return new User
                    {
                        Id = userresponse.Id,
                        FullName = userresponse.FullName,
                        Email = userresponse.Email,
                        PhoneNumber = userresponse.PhoneNumber,
                        CreatedDate = userresponse.CreatedDate,
                        IsActive = userresponse.IsActive,
                        UserType = userresponse.UserType
                    };
                }
                else
                {
                    _logger.LogError($"Failed request. Status: {response.StatusCode}, Content: {rawResponse}");
                    await Shell.Current.DisplayAlert("Error", rawResponse, "Ok");
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception during login: {ex.Message}");
                _logger.LogError($"Stack trace: {ex.StackTrace}");
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return null;
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
