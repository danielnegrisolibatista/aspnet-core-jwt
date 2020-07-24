using aspnet_core_jwt.Models;

namespace aspnet_core_jwt.Services.Interface
{
    public interface IJwtAuthenticationService
    {
        public object Authentication(UserLogged userLogged);
    }
}
