using System;
using System.Collections.Generic;
using System.Text;

namespace OzerNet.Commands.Infrastructure
{
    public class UserLoginModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public string RoleKey { get; set; }
        public List<UserLoginAuthority> Authorities { get; set; }
    }

    public class UserLoginAuthority
    {
        public string ModuleKey { get; set; }
        public string ModuleAuthorityKey { get; set; }
    }
}
