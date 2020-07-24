using aspnet_core_jwt.Models;
using aspnet_core_jwt.Services;
using aspnet_core_jwt.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace aspnet_core_jwt.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        private readonly IUserAuthorizationService _userAuthorizationService;
        public LoginController(
            IJwtAuthenticationService jwtAuthenticationService, 
            IUserAuthorizationService userAuthorizationService)
        {
            _jwtAuthenticationService = jwtAuthenticationService;
            _userAuthorizationService = userAuthorizationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] UserLogin user)
        {
            IActionResult response = Unauthorized();

            var userAuthenticate = _userAuthorizationService.Authorization(user);

            if (userAuthenticate?.ID > 0)
            {
                var jwt = _jwtAuthenticationService.Authentication(userAuthenticate);

                response = Ok(jwt);
            }

            return response;
        }
    }
}
