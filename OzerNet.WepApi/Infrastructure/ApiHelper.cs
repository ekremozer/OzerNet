using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using OzerNet.Commands.Infrastructure;

namespace OzerNet.WepApi.Infrastructure
{
    public static class ApiHelper
    {
        public static Command DeserializeObject(dynamic json, Type commandType, out bool jsonParse, out string jsonParseError)
        {
            try
            {
                jsonParse = true;
                jsonParseError = string.Empty;
                return (Command)JsonConvert.DeserializeObject(json, commandType);
            }
            catch
            {
                jsonParse = false;
                jsonParseError = "Json Parse Error!";
                return (Command)null;
            }
        }

        public static object CheckToken(this Command command, string userToken, string ip, out bool tokenStatus, out string message)
        {
            var authorizedAttribute = command.GetType().GetTypeInfo().GetCustomAttribute<AuthorizedAttribute>();
            if (authorizedAttribute != null)
            {
                tokenStatus = true;
                message = "Login successful";
                return true;
            }

            var tokenParse = Guid.TryParse(userToken, out var userTokenGuid);
            if (!tokenParse)
            {
                tokenStatus = false;
                message = "The token format is incorrect";
                return false;
            }

            var memoryCache = IOC.Container.Resolve<IMemoryCache>();
            var isLogin = memoryCache.TryGetValue(userTokenGuid, out TokenModel tokenModel);

            if (!isLogin)
            {
                tokenStatus = false;
                message = "Login Failed";
                return false;
            }

            var ipControl = tokenModel.Ip == ip;
            if (!ipControl)
            {
                tokenStatus = false;
                message = "Login Failed";
                return false;
            }

            memoryCache.Set(tokenModel.Token, userToken, new MemoryCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(6) });

            var commandAuthority = command.GetType().GetTypeInfo().GetCustomAttribute<AccessAuthorityAttribute>();
            if (commandAuthority == null)
            {
                tokenStatus = true;
                message = "Login successful";
                return true;
            }

            var accessAuthority = tokenModel.UserLoginModel.Authorities.Any(x => x.ModuleKey == commandAuthority.Module && x.ModuleAuthorityKey == commandAuthority.Authority);

            if (accessAuthority)
            {
                tokenStatus = true;
                message = "Login successful";
                return true;
            }

            tokenStatus = true;
            message = "Access authorization error";

            var accessAuthorityError = new
            {
                Authority = $"{commandAuthority.Module} - {commandAuthority.Authority}",
                commandAuthority.ErrorMessage
            };

            return accessAuthorityError;
        }
    }
}
