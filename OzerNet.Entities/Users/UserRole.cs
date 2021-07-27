using System;
using System.Collections.Generic;
using System.Text;

namespace OzerNet.Entities.Users
{
    public class UserRole : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<RoleAuthority> RoleAuthorities { get; set; }

        public UserRole()
        {
            Users = new HashSet<User>();
            RoleAuthorities = new HashSet<RoleAuthority>();
        }
    }
}
