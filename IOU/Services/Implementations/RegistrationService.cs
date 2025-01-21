using IOU.Models;
using IOU.Services.Interfaces;

namespace IOU.Services.Implementations
{
    internal class RegistrationService : IRegistrationService
    {
        public Task<User> Login(string email, string password)
        {
            var client = new HttpClient();
            string url = "https://localhost:7010/api/Users/Login";  
            throw new NotImplementedException();
        }

        public void Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
