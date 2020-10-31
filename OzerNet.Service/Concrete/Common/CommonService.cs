using System;
using System.Collections.Generic;
using System.Text;
using OzerNet.Commands.Commands.Common;
using OzerNet.Dal.EntityFrameWork;
using OzerNet.Entities.Users;
using OzerNet.Entities.Users;
using OzerNet.Service.Abstract.Common;
using OzerNet.Utulity.Helper;

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
                using var context = new EfContext(connectionString);
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
            using (var context = _contextFactory.Create())
            using (var transaction = context.Database.BeginTransaction())
            {
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
                    UserRoleUid = userAdminRole.Uid
                };
                userAdmin.CreatedBy = userAdmin.Uid;

                context.Users.Add(userAdmin);
                context.SaveChanges();
                #endregion

                #region UserRoleUpdate
                userAdminRole.CreatedBy = userAdmin.Uid;
                context.SaveChanges();
                #endregion

                #region Modules
                #region UserModule
                var userModule = new Module
                {
                    Name = "User",
                    Key = "user",
                    CreatedBy = userAdmin.Uid
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
                    ModuleUid = userModule.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.ModuleAuthorities.Add(userModuleCreateAuthority);
                context.SaveChanges();

                var userModuleReadAuthority = new ModuleAuthority
                {
                    Name = "User Read",
                    Key = "UR",
                    ModuleUid = userModule.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.ModuleAuthorities.Add(userModuleReadAuthority);
                context.SaveChanges();

                var userModuleUpdateAuthority = new ModuleAuthority
                {
                    Name = "User Update",
                    Key = "UU",
                    ModuleUid = userModule.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.ModuleAuthorities.Add(userModuleUpdateAuthority);
                context.SaveChanges();

                var userModuleDeleteAuthority = new ModuleAuthority
                {
                    Name = "User Delete",
                    Key = "UD",
                    ModuleUid = userModule.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.ModuleAuthorities.Add(userModuleDeleteAuthority);
                context.SaveChanges();
                #endregion

                #region RoleModuleAuthority
                var roleModuleCreateAuthority = new ModuleAuthority
                {
                    Name = "User Role Create",
                    Key = "URC",
                    ModuleUid = userModule.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.ModuleAuthorities.Add(roleModuleCreateAuthority);
                context.SaveChanges();

                var roleModuleReadAuthority = new ModuleAuthority
                {
                    Name = "User Role Read",
                    Key = "URR",
                    ModuleUid = userModule.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.ModuleAuthorities.Add(roleModuleReadAuthority);
                context.SaveChanges();

                var roleModuleUpdateAuthority = new ModuleAuthority
                {
                    Name = "User Role Update",
                    Key = "URU",
                    ModuleUid = userModule.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.ModuleAuthorities.Add(roleModuleUpdateAuthority);
                context.SaveChanges();

                var roleModuleDeleteAuthority = new ModuleAuthority
                {
                    Name = "User Role Delete",
                    Key = "URD",
                    ModuleUid = userModule.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.ModuleAuthorities.Add(roleModuleDeleteAuthority);
                context.SaveChanges();
                #endregion

                #region AuthorityModuleAuthority
                var authorityModuleCreateAuthority = new ModuleAuthority
                {
                    Name = "Authority Create",
                    Key = "AC",
                    ModuleUid = userModule.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.ModuleAuthorities.Add(authorityModuleCreateAuthority);
                context.SaveChanges();

                var authorityModuleReadAuthority = new ModuleAuthority
                {
                    Name = "Authority Read",
                    Key = "AR",
                    ModuleUid = userModule.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.ModuleAuthorities.Add(authorityModuleReadAuthority);
                context.SaveChanges();

                var authorityModuleUpdateAuthority = new ModuleAuthority
                {
                    Name = "Authority Update",
                    Key = "AU",
                    ModuleUid = userModule.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.ModuleAuthorities.Add(authorityModuleUpdateAuthority);
                context.SaveChanges();

                var authorityModuleDeleteAuthority = new ModuleAuthority
                {
                    Name = "Authority Delete",
                    Key = "D",
                    ModuleUid = userModule.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.ModuleAuthorities.Add(authorityModuleDeleteAuthority);
                context.SaveChanges();
                #endregion
                #endregion

                #region RoleAuthority
                #region UserModuleRoleAuthority
                var userCreateRoleAuthority = new RoleAuthority
                {
                    UserRoleUid = userAdminRole.Uid,
                    ModuleAuthorityUid = userModuleCreateAuthority.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.RoleAuthorities.Add(userCreateRoleAuthority);
                context.SaveChanges();

                var userReadRoleAuthority = new RoleAuthority
                {
                    UserRoleUid = userAdminRole.Uid,
                    ModuleAuthorityUid = userModuleReadAuthority.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.RoleAuthorities.Add(userReadRoleAuthority);
                context.SaveChanges();

                var userUpdateRoleAuthority = new RoleAuthority
                {
                    UserRoleUid = userAdminRole.Uid,
                    ModuleAuthorityUid = userModuleUpdateAuthority.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.RoleAuthorities.Add(userUpdateRoleAuthority);
                context.SaveChanges();

                var userDeleteRoleAuthority = new RoleAuthority
                {
                    UserRoleUid = userAdminRole.Uid,
                    ModuleAuthorityUid = userModuleDeleteAuthority.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.RoleAuthorities.Add(userDeleteRoleAuthority);
                context.SaveChanges();
                #endregion

                #region RoleModuleRoleAuthority
                var roleCreateRoleAuthority = new RoleAuthority
                {
                    UserRoleUid = userAdminRole.Uid,
                    ModuleAuthorityUid = roleModuleCreateAuthority.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.RoleAuthorities.Add(roleCreateRoleAuthority);
                context.SaveChanges();

                var roleReadRoleAuthority = new RoleAuthority
                {
                    UserRoleUid = userAdminRole.Uid,
                    ModuleAuthorityUid = roleModuleReadAuthority.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.RoleAuthorities.Add(roleReadRoleAuthority);
                context.SaveChanges();

                var roleUpdateRoleAuthority = new RoleAuthority
                {
                    UserRoleUid = userAdminRole.Uid,
                    ModuleAuthorityUid = roleModuleUpdateAuthority.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.RoleAuthorities.Add(roleUpdateRoleAuthority);
                context.SaveChanges();

                var roleDeleteRoleAuthority = new RoleAuthority
                {
                    UserRoleUid = userAdminRole.Uid,
                    ModuleAuthorityUid = roleModuleDeleteAuthority.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.RoleAuthorities.Add(roleDeleteRoleAuthority);
                context.SaveChanges();
                #endregion

                #region AuthorityMoludeRoleAuthority
                var authorityCreateRoleAuthority = new RoleAuthority
                {
                    UserRoleUid = userAdminRole.Uid,
                    ModuleAuthorityUid = authorityModuleCreateAuthority.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.RoleAuthorities.Add(authorityCreateRoleAuthority);
                context.SaveChanges();

                var authorityReadRoleAuthority = new RoleAuthority
                {
                    UserRoleUid = userAdminRole.Uid,
                    ModuleAuthorityUid = authorityModuleReadAuthority.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.RoleAuthorities.Add(authorityReadRoleAuthority);
                context.SaveChanges();

                var authorityUpdateRoleAuthority = new RoleAuthority
                {
                    UserRoleUid = userAdminRole.Uid,
                    ModuleAuthorityUid = authorityModuleUpdateAuthority.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.RoleAuthorities.Add(authorityUpdateRoleAuthority);
                context.SaveChanges();

                var authorityDeleteRoleAuthority = new RoleAuthority
                {
                    UserRoleUid = userAdminRole.Uid,
                    ModuleAuthorityUid = authorityModuleDeleteAuthority.Uid,
                    CreatedBy = userAdmin.Uid
                };
                context.RoleAuthorities.Add(authorityDeleteRoleAuthority);
                context.SaveChanges();


                #endregion
                #endregion

                transaction.Commit();
            }
            return true;
        }
    }
}
