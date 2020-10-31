using System;
using System.Collections.Generic;
using System.Text;
using OzerNet.Commands.Commands.Users;
using OzerNet.Commands.Infrastructure;

namespace OzerNet.Service.Abstract.Users
{
    public interface IUserService
    {
        object GetUser(GetUser command);
        UserLoginModel Login(Login command);
    }
}
