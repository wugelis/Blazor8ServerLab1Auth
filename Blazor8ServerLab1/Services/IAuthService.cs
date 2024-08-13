using Blazor8ServerLab1.Models;

namespace Blazor8ServerLab1.Services
{
    public interface IAuthService
    {
        Task<bool> Login(LoginRequest loginRequest);

        Task<CurrentUser> GetCurrentUser();
    }
}
