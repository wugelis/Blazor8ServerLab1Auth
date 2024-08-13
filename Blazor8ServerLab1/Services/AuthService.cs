
using Blazor8ServerLab1.Models;
using System.Security.Claims;

namespace Blazor8ServerLab1.Services
{
    /// <summary>
    /// 提供驗證相關服務與方法
    /// </summary>
    public class AuthService : IAuthService
    {
        private static CurrentUser CurrentContextUser = new CurrentUser() { IsAuthenticated = false };

        public static List<UserInfo> userInfos = new List<UserInfo>(new UserInfo[]
            {
                new UserInfo()
                {
                    UserID = "100012",
                    //UserName = "Gelis12",
                    CreatedDate = DateTime.Now,
                    DepartmentID = "DEPART012_100012",
                    EMail = "gelis12@gmaile.com"
                },
                new UserInfo()
                {
                    UserID = "100013",
                    //UserName = "Gelis13",
                    CreatedDate = DateTime.Now,
                    DepartmentID = "DEPART012_100013",
                    EMail = "gelis14@gmaile.com"
                },
                new UserInfo()
                {
                    UserID = "100014",
                    //UserName = "Gelis14",
                    CreatedDate = DateTime.Now,
                    DepartmentID = "DEPART012_100014",
                    EMail = "gelis14@gmaile.com"
                }
            });

        public Task<bool> Login(LoginRequest loginRequest)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, loginRequest.UserName!),
                new Claim(ClaimTypes.Role, "Administrator")
            };

            CurrentContextUser = new CurrentUser()
            {
                UserName = loginRequest.UserName,
                //Password = loginRequest.Password
                Claims = claims,
            };

            return Task.FromResult(true);
        }

        public Task<CurrentUser> GetCurrentUser()
        {
            CurrentContextUser.IsAuthenticated = CurrentContextUser.UserName == "100013";
            return Task.FromResult(CurrentContextUser);

            /*
            return Task.FromResult(new CurrentUser()
            {
                UserName = CurrentContextUser.UserName,
                Password = CurrentContextUser.Password,
                IsAuthenticated = CurrentContextUser.UserName == "100013",
                Claims = claims
            });
            */
        }
    }
}
