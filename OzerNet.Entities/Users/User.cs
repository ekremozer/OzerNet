using System;
using System.Collections.Generic;
using OzerNet.Entities.Users;

namespace OzerNet.Entities.Users
{
    public class User : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime BirthDate { get; set; }

        public virtual Guid UserRoleUid { get; set; }
        public virtual UserRole UserRole { get; set; }

        public virtual ICollection<User> CreatedUsers { get; set; }
        public virtual ICollection<User> UpdatedUsers { get; set; }
        public virtual ICollection<User> DeletedUsers { get; set; }

        public virtual ICollection<UserRole> CreatedUserRoles { get; set; }
        public virtual ICollection<UserRole> UpdatedUserRoles { get; set; }
        public virtual ICollection<UserRole> DeletedUserRoles { get; set; }

        public virtual ICollection<Module> CreatedUserModules { get; set; }
        public virtual ICollection<Module> UpdatedUserModules { get; set; }
        public virtual ICollection<Module> DeletedUserModules { get; set; }

        public virtual ICollection<ModuleAuthority> CreatedUserModuleAuthorities { get; set; }
        public virtual ICollection<ModuleAuthority> UpdatedUserModuleAuthorities { get; set; }
        public virtual ICollection<ModuleAuthority> DeletedUserModuleAuthorities { get; set; }

        public virtual ICollection<RoleAuthority> CreatedUserRoleAuthorities { get; set; }
        public virtual ICollection<RoleAuthority> UpdatedUserRoleAuthorities { get; set; }
        public virtual ICollection<RoleAuthority> DeletedUserRoleAuthorities { get; set; }

        public User()
        {
            CreatedUsers = new HashSet<User>();
            UpdatedUsers = new HashSet<User>();
            DeletedUsers = new HashSet<User>();

            CreatedUserRoles = new HashSet<UserRole>();
            UpdatedUserRoles = new HashSet<UserRole>();
            DeletedUserRoles = new HashSet<UserRole>();

            CreatedUserModules = new HashSet<Module>();
            UpdatedUserModules = new HashSet<Module>();
            DeletedUserModules = new HashSet<Module>();

            CreatedUserModuleAuthorities = new HashSet<ModuleAuthority>();
            UpdatedUserModuleAuthorities = new HashSet<ModuleAuthority>();
            DeletedUserModuleAuthorities = new HashSet<ModuleAuthority>();

            CreatedUserRoleAuthorities = new HashSet<RoleAuthority>();
            UpdatedUserRoleAuthorities = new HashSet<RoleAuthority>();
            DeletedUserRoleAuthorities = new HashSet<RoleAuthority>();
        }
    }
}
