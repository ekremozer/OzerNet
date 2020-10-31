using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzerNet.Bll.Abstract.Users;
using OzerNet.Commands.Commands.Users;
using OzerNet.WepApi.Infrastructure;

namespace OzerNet.WepApi.CommandHandlers.Users
{
    public class LoginHandler : CommandHandler<Login>
    {
        private readonly IUserManager _userManager;

        public LoginHandler(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public override dynamic Handle(Login command)
        {
            return _userManager.Login(command);
        }
    }
}
