
using IOU.Models;

namespace IOU.Services.Interfaces
{
   public interface IRegistrationService
    {
        Task<User> Login(string email, string password);
        Task <bool> Register(User user);
    }
}
