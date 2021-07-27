using System;
using System.Collections.Generic;
using OzerNet.Entities.Users;

namespace OzerNet.Entities.Users
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }

        public int? UserRoleId{ get; set; }
        public UserRole UserRole { get; set; }

        public ICollection<User> CreatedUsers { get; set; }
        public ICollection<User> UpdatedUsers { get; set; }
        public ICollection<User> DeletedUsers { get; set; }

        public ICollection<UserRole> CreatedUserRoles { get; set; }
        public ICollection<UserRole> UpdatedUserRoles { get; set; }
        public ICollection<UserRole> DeletedUserRoles { get; set; }

        public ICollection<Module> CreatedUserModules { get; set; }
        public ICollection<Module> UpdatedUserModules { get; set; }
        public ICollection<Module> DeletedUserModules { get; set; }

        public ICollection<ModuleAuthority> CreatedUserModuleAuthorities { get; set; }
        public ICollection<ModuleAuthority> UpdatedUserModuleAuthorities { get; set; }
        public ICollection<ModuleAuthority> DeletedUserModuleAuthorities { get; set; }

        public ICollection<RoleAuthority> CreatedUserRoleAuthorities { get; set; }
        public ICollection<RoleAuthority> UpdatedUserRoleAuthorities { get; set; }
        public ICollection<RoleAuthority> DeletedUserRoleAuthorities { get; set; }

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
