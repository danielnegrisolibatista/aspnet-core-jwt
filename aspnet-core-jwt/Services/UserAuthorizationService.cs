using aspnet_core_jwt.Models;
using aspnet_core_jwt.Repositories.Interface;
using aspnet_core_jwt.Services.Interface;

namespace aspnet_core_jwt.Services
{
    public class UserAuthorizationService : IUserAuthorizationService
    {
        private readonly IUserRepository _userRepository;

        public UserAuthorizationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserLogged Authorization(UserLogin user)
        {
            var userLogged = _userRepository.Get(user.Username, user.Password);
            if (userLogged != null && userLogged.ID > 0)
            {
                return userLogged;
            }

            return new UserLogged();
        }
    }
}
