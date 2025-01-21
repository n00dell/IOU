
using IOU.Models;

namespace IOU.Services.Interfaces
{
    internal interface IRegistrationService
    {
        Task<User> Login(string email, string password);
        Task<User> Register(User user);
    }
}
