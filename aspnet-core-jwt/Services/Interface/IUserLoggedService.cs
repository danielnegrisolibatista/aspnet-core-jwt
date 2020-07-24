using aspnet_core_jwt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_jwt.Services.Interface
{
    public interface IUserLoggedService
    {
        public UserLogged GetLoggedUser();
    }
}
