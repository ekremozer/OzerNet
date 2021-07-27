using System;
using System.Collections.Generic;
using System.Text;

namespace OzerNet.Entities.Users
{
    public class ModuleAuthority : BaseEntity
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public Module Module { get; set; }
        public int ModuleId { get; set; }
        public ICollection<RoleAuthority> RoleAuthorities { get; set; }
        public ModuleAuthority()
        {
            RoleAuthorities = new HashSet<RoleAuthority>();
        }
    }
}
