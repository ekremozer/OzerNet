using System;
using Microsoft.Extensions.Caching.Memory;
using OzerNet.Bll.Abstract.Users;
using OzerNet.Commands.Commands.Users;
using OzerNet.Commands.Infrastructure;
using OzerNet.Service.Abstract.Users;

namespace OzerNet.Bll.Concrete.Users
{
    public class UserManager : IUserManager
    {
        private readonly IUserService _userService;
        private readonly IMemoryCache _memoryCache;

        public UserManager(IUserService userService, IMemoryCache memoryCache)
        {
            _userService = userService;
            _memoryCache = memoryCache;
        }

        public object GetUser(GetUser command)
        {
            var readFromCache = _memoryCache.TryGetValue(command.Uid, out var user);
            if (readFromCache && !command.ClearCache)
            {
                return user;
            }
            user = _userService.GetUser(command);
            if (user == null)
            {
                return new CommandResponse("User not found", false);
            }
            _memoryCache.Set(command.Uid, user, new MemoryCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1) });
            return new CommandResponse("User Info", user);
        }

        public object Login(Login command)
        {
            var userLoginModel = _userService.Login(command);
            if (userLoginModel == null)
            {
                return new CommandResponse("User not found", false, false);
            }

            if (string.IsNullOrEmpty(userLoginModel.RoleKey))
            {
                return new CommandResponse("User role not found", false);
            }

            var userToken = new TokenModel
            {
                Token = Guid.NewGuid(),
                Ip = command.ClientIpAddress,
                UserLoginModel = userLoginModel
            };
            _memoryCache.Set(userToken.Token, userToken, new MemoryCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(6) });

            return new CommandResponse("Login success", userToken);
        }
    }
}
