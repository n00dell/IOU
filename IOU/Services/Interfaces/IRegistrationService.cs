
using IOU.Models;

namespace IOU.Services.Interfaces
{
   public interface IRegistrationService
    {
        Task<User> Login(string email, string password);
        Task <bool> Register(User user);
        Task<bool> RegisterStudent(Student student);

        Task<bool> RegisterGuardian(Guardian guardian, StudentGuardian studentGuardian);

        Task<bool> RegisterLender(Lender lender);

    }
}
