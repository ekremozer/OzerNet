using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzerNet.Bll.Abstract.Users;
using OzerNet.Commands;
using OzerNet.Commands.Commands.Users;
using OzerNet.WepApi.Infrastructure;

namespace OzerNet.WepApi.CommandHandlers.Users
{
    public class GetUserHandler : CommandHandler<GetUser>
    {
        private readonly IUserManager _userManager;

        public GetUserHandler(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public override dynamic Handle(GetUser command)
        {
            var user = _userManager.GetUser(command);
            
            return user;
        }
    }
}
