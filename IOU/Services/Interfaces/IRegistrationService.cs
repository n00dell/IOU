
using IOU.Models;

namespace IOU.Services.Interfaces
{
    internal interface IRegistrationService
    {
        Task<User> Login(string email, string password);
        void Register(User user);
    }
}
