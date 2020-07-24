using aspnet_core_jwt.Models;
using aspnet_core_jwt.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace aspnet_core_jwt.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserLogged Get(string username, string password)
        {
            var users = new List<UserLogged>();
            users.Add(new UserLogged { ID = 1, Name = "Administrator", Username = "administrador", Email = "admin@system.com", IsAdmin = true, Role = "ADMINISTRATOR" });
            users.Add(new UserLogged { ID = 2, Name = "User", Username = "user", Email = "user@system.com", IsAdmin = true, Role = "USER" });

            return users.Where(s => s.Username == username.Trim()).FirstOrDefault();
        }
    }
}
