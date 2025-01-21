using IOU.Models;
using IOU.Services.Interfaces;

namespace IOU.Services.Implementations
{
    internal class RegistrationService : IRegistrationService
    {
        public Task<User> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
