using OzerNet.Commands.Commands.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace OzerNet.Bll.Abstract.Users
{
    public interface IUserManager
    {
        object GetUser(GetUser command);
        object Login(Login command);
    }
}
