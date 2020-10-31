using System;
using System.Collections.Generic;
using System.Text;
using OzerNet.Entities.Users;

namespace OzerNet.Entities.Users
{
    public class RoleAuthority : BaseEntity
    {
        public virtual UserRole UserRole { get; set; }
        public virtual Guid? UserRoleUid { get; set; }
        public virtual ModuleAuthority ModuleAuthority { get; set; }
        public virtual Guid ModuleAuthorityUid { get; set; }
    }
}
