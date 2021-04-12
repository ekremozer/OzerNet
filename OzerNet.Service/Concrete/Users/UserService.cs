using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OzerNet.Commands.Commands.Users;
using OzerNet.Commands.Infrastructure;
using OzerNet.Dal.EntityFrameWork;
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
            var user = context.Users.Include(x => x.UserRole).FirstOrDefault(x => x.Uid == command.Uid);

            if (user == null)
            {
                return null;
            }

            return new
            {
                user.Name,
                UserRole = user.UserRole.Name,
                user.UserRole.Code
            };
        }

        public UserLoginModel Login(Login command)
        {
            using var context = _contextFactory.Create();
            var user = context.Users
                .Include(x => x.UserRole.RoleAuthorities)
                .ThenInclude(x => x.ModuleAuthority.Module)
                .FirstOrDefault(x => x.Email == command.Email && x.Password == CryptoService.ToMd5(command.Password));

            if (user == null)
            {
                return null;
            }
            var result = new UserLoginModel
            {
                Uid = user.Uid,
                Name = user.Name,
                Email = user.Email,
                RoleName = user.UserRole?.Name,
                RoleKey = user.UserRole?.Code,
                Authorities = user.UserRole?.RoleAuthorities?.Select(x => new UserLoginAuthority
                {
                    ModuleKey = x.ModuleAuthority.Module.Key,
                    ModuleAuthorityKey = x.ModuleAuthority.Key
                }).ToList()
            };

            return result;
        }
    }
}
