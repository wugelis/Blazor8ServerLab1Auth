using Blazor8ServerLab1.Models;
using Blazor8ServerLab1.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Blazor8ServerLab1.Auth
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthService _authService;

        public CustomAuthenticationStateProvider(IAuthService authService)
        {
            _authService = authService;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // 取得 Current User
            CurrentUser currentUser = await _authService.GetCurrentUser();

            ClaimsIdentity claimsIdentity = currentUser.IsAuthenticated ? new ClaimsIdentity(currentUser.Claims, "CustomAuthType") : new ClaimsIdentity();

            AuthenticationState authState = new AuthenticationState(new ClaimsPrincipal(claimsIdentity));

            return await Task.FromResult(authState);
        }

        public async Task Login(LoginRequest loginRequest)
        {
            // 登入驗證
            await _authService.Login(loginRequest);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
