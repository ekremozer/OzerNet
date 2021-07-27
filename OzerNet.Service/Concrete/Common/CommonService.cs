using System;
using System.Collections.Generic;
using System.Text;
using OzerNet.Commands.Commands.Common;
using OzerNet.Dal.EntityFrameWork;
using OzerNet.Dal.EntityFrameWork.Base;
using OzerNet.Entities.Users;
using OzerNet.Entities.Users;
using OzerNet.Service.Abstract.Common;
using OzerNet.Utility.Helper;

namespace OzerNet.Service.Concrete.Common
{
    public class CommonService : ICommonService
    {
        private readonly IContextFactory _contextFactory;

        public CommonService(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public object CreateDatabase(CreateDatabase command, string connectionString)
        {
            try
            {
                using var context = _contextFactory.Create();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                if (command.CreateBaseData)
                {
                    var created = CreateBaseData();
                }
                return true;
            }
            catch (Exception e)
            {
                return $"{e.Message}{Environment.NewLine}{e.StackTrace}";
            }
        }

        bool CreateBaseData()
        {
            using var context = _contextFactory.Create();
            using var transaction = context.Database.BeginTransaction();

            #region UserRole
            var userAdminRole = new UserRole { Name = "Admin", Code = "ADM" };
            context.UserRoles.Add(userAdminRole);
            context.SaveChanges();
            #endregion

            #region User
            var userAdmin = new User
            {
                Name = "Ekrem",
                Surname = "Özer",
                Email = "ekrem.zr@gmail.com",
                Phone = "5444444444",
                Password = CryptoService.ToMd5("123"),
                BirthDate = new DateTime(1989, 9, 15),
                UserRoleId = userAdminRole.Id
            };
            context.Users.Add(userAdmin);
            context.SaveChanges();

            userAdmin.CreatedBy = userAdmin.Id;
            context.SaveChanges();
            #endregion

            #region UserRoleUpdate
            userAdminRole.CreatedBy = userAdmin.Id;
            context.SaveChanges();
            #endregion

            #region Modules
            #region UserModule
            var userModule = new Module
            {
                Name = "User",
                Key = "user",
                CreatedBy = userAdmin.Id
            };
            context.Modules.Add(userModule);
            context.SaveChanges();
            #endregion
            #endregion

            #region ModuleAuthority
            #region UserModuleAuthority
            var userModuleCreateAuthority = new ModuleAuthority
            {
                Name = "User Create",
                Key = "UC",
                ModuleId = userModule.Id,
                CreatedBy = userAdmin.Id
            };
            context.ModuleAuthorities.Add(userModuleCreateAuthority);
            context.SaveChanges();

            var userModuleReadAuthority = new ModuleAuthority
            {
                Name = "User Read",
                Key = "UR",
                ModuleId = userModule.Id,
                CreatedBy = userAdmin.Id
            };
            context.ModuleAuthorities.Add(userModuleReadAuthority);
            context.SaveChanges();

            var userModuleUpdateAuthority = new ModuleAuthority
            {
                Name = "User Update",
                Key = "UU",
                ModuleId = userModule.Id,
                CreatedBy = userAdmin.Id
            };
            context.ModuleAuthorities.Add(userModuleUpdateAuthority);
            context.SaveChanges();

            var userModuleDeleteAuthority = new ModuleAuthority
            {
                Name = "User Delete",
                Key = "UD",
                ModuleId = userModule.Id,
                CreatedBy = userAdmin.Id
            };
            context.ModuleAuthorities.Add(userModuleDeleteAuthority);
            context.SaveChanges();
            #endregion

            #region RoleModuleAuthority
            var roleModuleCreateAuthority = new ModuleAuthority
            {
                Name = "User Role Create",
                Key = "URC",
                ModuleId = userModule.Id,
                CreatedBy = userAdmin.Id
            };
            context.ModuleAuthorities.Add(roleModuleCreateAuthority);
            context.SaveChanges();

            var roleModuleReadAuthority = new ModuleAuthority
            {
                Name = "User Role Read",
                Key = "URR",
                ModuleId = userModule.Id,
                CreatedBy = userAdmin.Id
            };
            context.ModuleAuthorities.Add(roleModuleReadAuthority);
            context.SaveChanges();

            var roleModuleUpdateAuthority = new ModuleAuthority
            {
                Name = "User Role Update",
                Key = "URU",
                ModuleId = userModule.Id,
                CreatedBy = userAdmin.Id
            };
            context.ModuleAuthorities.Add(roleModuleUpdateAuthority);
            context.SaveChanges();

            var roleModuleDeleteAuthority = new ModuleAuthority
            {
                Name = "User Role Delete",
                Key = "URD",
                ModuleId = userModule.Id,
                CreatedBy = userAdmin.Id
            };
            context.ModuleAuthorities.Add(roleModuleDeleteAuthority);
            context.SaveChanges();
            #endregion

            #region AuthorityModuleAuthority
            var authorityModuleCreateAuthority = new ModuleAuthority
            {
                Name = "Authority Create",
                Key = "AC",
                ModuleId = userModule.Id,
                CreatedBy = userAdmin.Id
            };
            context.ModuleAuthorities.Add(authorityModuleCreateAuthority);
            context.SaveChanges();

            var authorityModuleReadAuthority = new ModuleAuthority
            {
                Name = "Authority Read",
                Key = "AR",
                ModuleId = userModule.Id,
                CreatedBy = userAdmin.Id
            };
            context.ModuleAuthorities.Add(authorityModuleReadAuthority);
            context.SaveChanges();

            var authorityModuleUpdateAuthority = new ModuleAuthority
            {
                Name = "Authority Update",
                Key = "AU",
                ModuleId = userModule.Id,
                CreatedBy = userAdmin.Id
            };
            context.ModuleAuthorities.Add(authorityModuleUpdateAuthority);
            context.SaveChanges();

            var authorityModuleDeleteAuthority = new ModuleAuthority
            {
                Name = "Authority Delete",
                Key = "D",
                ModuleId = userModule.Id,
                CreatedBy = userAdmin.Id
            };
            context.ModuleAuthorities.Add(authorityModuleDeleteAuthority);
            context.SaveChanges();
            #endregion
            #endregion

            #region RoleAuthority
            #region UserModuleRoleAuthority
            var userCreateRoleAuthority = new RoleAuthority
            {
                UserRoleId = userAdminRole.Id,
                ModuleAuthorityId = userModuleCreateAuthority.Id,
                CreatedBy = userAdmin.Id
            };
            context.RoleAuthorities.Add(userCreateRoleAuthority);
            context.SaveChanges();

            var userReadRoleAuthority = new RoleAuthority
            {
                UserRoleId = userAdminRole.Id,
                ModuleAuthorityId = userModuleReadAuthority.Id,
                CreatedBy = userAdmin.Id
            };
            context.RoleAuthorities.Add(userReadRoleAuthority);
            context.SaveChanges();

            var userUpdateRoleAuthority = new RoleAuthority
            {
                UserRoleId = userAdminRole.Id,
                ModuleAuthorityId = userModuleUpdateAuthority.Id,
                CreatedBy = userAdmin.Id
            };
            context.RoleAuthorities.Add(userUpdateRoleAuthority);
            context.SaveChanges();

            var userDeleteRoleAuthority = new RoleAuthority
            {
                UserRoleId = userAdminRole.Id,
                ModuleAuthorityId = userModuleDeleteAuthority.Id,
                CreatedBy = userAdmin.Id
            };
            context.RoleAuthorities.Add(userDeleteRoleAuthority);
            context.SaveChanges();
            #endregion

            #region RoleModuleRoleAuthority
            var roleCreateRoleAuthority = new RoleAuthority
            {
                UserRoleId = userAdminRole.Id,
                ModuleAuthorityId = roleModuleCreateAuthority.Id,
                CreatedBy = userAdmin.Id
            };
            context.RoleAuthorities.Add(roleCreateRoleAuthority);
            context.SaveChanges();

            var roleReadRoleAuthority = new RoleAuthority
            {
                UserRoleId = userAdminRole.Id,
                ModuleAuthorityId = roleModuleReadAuthority.Id,
                CreatedBy = userAdmin.Id
            };
            context.RoleAuthorities.Add(roleReadRoleAuthority);
            context.SaveChanges();

            var roleUpdateRoleAuthority = new RoleAuthority
            {
                UserRoleId = userAdminRole.Id,
                ModuleAuthorityId = roleModuleUpdateAuthority.Id,
                CreatedBy = userAdmin.Id
            };
            context.RoleAuthorities.Add(roleUpdateRoleAuthority);
            context.SaveChanges();

            var roleDeleteRoleAuthority = new RoleAuthority
            {
                UserRoleId = userAdminRole.Id,
                ModuleAuthorityId = roleModuleDeleteAuthority.Id,
                CreatedBy = userAdmin.Id
            };
            context.RoleAuthorities.Add(roleDeleteRoleAuthority);
            context.SaveChanges();
            #endregion

            #region AuthorityMoludeRoleAuthority
            var authorityCreateRoleAuthority = new RoleAuthority
            {
                UserRoleId = userAdminRole.Id,
                ModuleAuthorityId = authorityModuleCreateAuthority.Id,
                CreatedBy = userAdmin.Id
            };
            context.RoleAuthorities.Add(authorityCreateRoleAuthority);
            context.SaveChanges();

            var authorityReadRoleAuthority = new RoleAuthority
            {
                UserRoleId = userAdminRole.Id,
                ModuleAuthorityId = authorityModuleReadAuthority.Id,
                CreatedBy = userAdmin.Id
            };
            context.RoleAuthorities.Add(authorityReadRoleAuthority);
            context.SaveChanges();

            var authorityUpdateRoleAuthority = new RoleAuthority
            {
                UserRoleId = userAdminRole.Id,
                ModuleAuthorityId = authorityModuleUpdateAuthority.Id,
                CreatedBy = userAdmin.Id
            };
            context.RoleAuthorities.Add(authorityUpdateRoleAuthority);
            context.SaveChanges();

            var authorityDeleteRoleAuthority = new RoleAuthority
            {
                UserRoleId = userAdminRole.Id,
                ModuleAuthorityId = authorityModuleDeleteAuthority.Id,
                CreatedBy = userAdmin.Id
            };
            context.RoleAuthorities.Add(authorityDeleteRoleAuthority);
            context.SaveChanges();


            #endregion
            #endregion

            transaction.Commit();
            return true;
        }
    }
}
