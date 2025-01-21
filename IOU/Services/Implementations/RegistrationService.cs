using IOU.Models;
using IOU.Services.Interfaces;
using System.Net.Http.Json;

namespace IOU.Services.Implementations
{
    internal class RegistrationService : IRegistrationService
    {
        public async Task<User> Login(string email, string password)
        {
            try
            {
                var client = new HttpClient();
                string url = "https://localhost:7010/api/user/login";
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    User user = await response.Content.ReadFromJsonAsync<User>();
                    return await Task.FromResult(user);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return null;
            }
        }

        public void Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
