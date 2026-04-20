using Online_L_Platform2.DTOs;
using Online_L_Platform2.Models;

namespace Online_L_Platform2.Service.interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(RegisterDto model);

        Task<string> LoginAsync(string email, string password);
    }
}