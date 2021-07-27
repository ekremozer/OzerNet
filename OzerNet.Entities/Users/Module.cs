using System;
using System.Collections.Generic;
using System.Text;

namespace OzerNet.Entities.Users
{
    public class Module : BaseEntity
    {
        public string Name { get; set; }
        public string Key { get; set; }

        public ICollection<ModuleAuthority> ModuleAuthorities { get; set; }

        public Module()
        {
            ModuleAuthorities = new HashSet<ModuleAuthority>();
        }
    }
}
