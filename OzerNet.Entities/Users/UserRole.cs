using System;
using System.Collections.Generic;
using System.Text;

namespace OzerNet.Entities.Users
{
    public class UserRole : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<RoleAuthority> RoleAuthorities { get; set; }
    }
}
