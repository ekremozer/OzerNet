using System;
using System.Collections.Generic;
using System.Text;

namespace OzerNet.Entities.Users
{
    public class ModuleAuthority : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Key { get; set; }
        public virtual Module Module { get; set; }
        public virtual Guid ModuleUid { get; set; }
        public virtual ICollection<RoleAuthority> RoleAuthorities { get; set; }
        public ModuleAuthority()
        {
            RoleAuthorities = new HashSet<RoleAuthority>();
        }
    }
}
