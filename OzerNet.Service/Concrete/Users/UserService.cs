using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OzerNet.Commands.Commands.Users;
using OzerNet.Commands.Infrastructure;
using OzerNet.Dal.EntityFrameWork;
using OzerNet.Dal.EntityFrameWork.Base;
using OzerNet.Service.Abstract.Users;
using OzerNet.Utility.Helper;

namespace OzerNet.Service.Concrete.Users
{
    public class UserService : IUserService
    {
        private readonly IContextFactory _contextFactory;

        public UserService(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public object GetUser(GetUser command)
        {
            using var context = _contextFactory.Create();
            var user = context.Users.Include(x => x.UserRole).AsNoTracking().Select(x => new
            {
                x.Id,
                x.Name,
                Role = x.UserRole.Name,
                RoleCode = x.UserRole.Code,
            }).FirstOrDefault(x => x.Id == command.Id);

            return user;
        }

        public UserLoginModel Login(Login command)
        {
            using var context = _contextFactory.Create();
            var user = context.Users
                .Include(x => x.UserRole.RoleAuthorities)
                .ThenInclude(x => x.ModuleAuthority.Module).Where(x => x.Email == command.Email && x.Password == CryptoService.ToMd5(command.Password)).AsNoTracking().Select(x =>
                    new UserLoginModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Email = x.Email,
                        RoleName = x.UserRole != null ? x.UserRole.Name : string.Empty,
                        RoleKey = x.UserRole != null ? x.UserRole.Code : string.Empty,
                        Authorities = (x.UserRole != null && x.UserRole.RoleAuthorities != null) ? x.UserRole.RoleAuthorities.Select(y => new UserLoginAuthority
                        {
                            ModuleKey = y.ModuleAuthority.Module.Key,
                            ModuleAuthorityKey = y.ModuleAuthority.Key
                        }).ToList() : null
                    })
                .FirstOrDefault();

            return user;
        }
    }
}
