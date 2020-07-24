using aspnet_core_jwt.Models;

namespace aspnet_core_jwt.Repositories.Interface
{
    public interface IUserRepository
    {
        public UserLogged Get(string username, string password);
    }
}
