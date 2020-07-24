using System;
using System.Collections.Generic;
using aspnet_core_jwt.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_core_jwt.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserLoggedService _userLoggedService;
        public UserController(IUserLoggedService userLoggedService)
        {
            _userLoggedService = userLoggedService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IActionResult response = Unauthorized();

            var userLogged = _userLoggedService.GetLoggedUser();

            if (userLogged != null)
            {
                response = Ok(userLogged);
            }

            return response;
        }
    }
}