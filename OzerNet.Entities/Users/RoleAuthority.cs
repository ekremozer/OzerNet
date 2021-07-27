using System;
using System.Collections.Generic;
using System.Text;
using OzerNet.Entities.Users;

namespace OzerNet.Entities.Users
{
    public class RoleAuthority : BaseEntity
    {
        public UserRole UserRole { get; set; }
        public int? UserRoleId { get; set; }
        public ModuleAuthority ModuleAuthority { get; set; }
        public int? ModuleAuthorityId { get; set; }
    }
}
