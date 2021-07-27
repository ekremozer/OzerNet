using System;
using System.Collections.Generic;
using System.Text;
using OzerNet.Commands.Infrastructure;

namespace OzerNet.Commands.Commands.Users
{
    [Describe(Module.User, Process.Read, "Kullanıcı Bilgisi")]
    [AccessAuthorityAttribute(Module = "user", Authority = "UR", ErrorMessage = "Kullanıcı bilgisi görme yetkiniz yoktur.")]
    public class GetUser : Command
    {
        public int Id { get; set; }
    }
}
