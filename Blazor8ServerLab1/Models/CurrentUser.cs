using System.Security.Claims;

namespace Blazor8ServerLab1.Models
{
    /// <summary>
    /// 當前登入使用者實體定義
    /// </summary>
    public class CurrentUser : LoginRequest
    {
        public bool IsAuthenticated { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
