using System;
using System.Collections.Generic;
using System.Text;
using OzerNet.Commands.Infrastructure;

namespace OzerNet.Commands.Commands.Users
{
    [Describe(Module.User, Process.Read, "User Login"), AuthorizedAttribute]
    public class Login : Command
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
