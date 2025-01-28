using IOU.Models;
using IOU.Services.Interfaces;
using System.Net.Http.Json;

namespace IOU.Services.Implementations
{
    internal class RegistrationService : IRegistrationService
    {
        private readonly HttpClient _client;
        public RegistrationService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7010/api/user");
        }
        public async Task<User> Login(string email, string password)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"?email={email}&password={password}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<User>();
                }               
                return null;
                
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return null;
            }
        }

        public async Task<bool> Register(User user)
        {
            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync("register", user);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return false;
            }
        }
    }
}
