using System;
using System.Collections.Generic;
using System.Text;

namespace OzerNet.Entities.Users
{
    public class Module : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Key { get; set; }

        public virtual ICollection<ModuleAuthority> ModuleAuthorities { get; set; }

        public Module()
        {
            ModuleAuthorities = new HashSet<ModuleAuthority>();
        }
    }
}
