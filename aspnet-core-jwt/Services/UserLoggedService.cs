using aspnet_core_jwt.Models;
using aspnet_core_jwt.Services.Interface;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace aspnet_core_jwt.Services
{
    public class UserLoggedService : IUserLoggedService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserLoggedService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserLogged GetLoggedUser()
        {
            var identity = _httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;

            if (identity?.IsAuthenticated ?? false)
            {
                var userData = identity?.FindFirst("UserData")?.Value;
                var userLogged = JsonSerializer.Deserialize<UserLogged>(userData);
                return userLogged;
            }

            return new UserLogged();
        }
    }
}
