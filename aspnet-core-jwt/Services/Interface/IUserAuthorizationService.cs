using aspnet_core_jwt.Models;

namespace aspnet_core_jwt.Services.Interface
{
    public interface IUserAuthorizationService
    {
        public UserLogged Authorization(UserLogin user);
    }
}
