using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using OzerNet.Commands.Infrastructure;
using OzerNet.WepApi.Infrastructure;

namespace OzerNet.WepApi.Controllers
{
    [Route("/")]
    public class ExecuteController : Controller
    {
        private static readonly ConcurrentDictionary<string, Type> Types = new ConcurrentDictionary<string, Type>();

        static ExecuteController()
        {
            var types = Assembly.GetAssembly(typeof(Command))?.DefinedTypes.Where(x => x.BaseType == typeof(Command));
            if (types == null) return;
            foreach (var type in types)
            {
                Types[type.Name.ToLowerInvariant()] = type.UnderlyingSystemType;
            }
        }

        [HttpPost("{commandName}")]
        public dynamic Post(string commandName, [FromBody] dynamic jsonData)
        {
            #region PostTypeValitaion
            if (HttpContext.Request.Method != HttpMethod.Post.Method)
            {
                return Ok();
            }
            #endregion

            #region CommandTypeValidation
            var commandType = Types[commandName.ToLowerInvariant()];
            if (!Types.ContainsKey(commandName.ToLowerInvariant()))
            {
                return new { Error = "bad command" };
            }
            #endregion

            #region CommandParseValidation
            Command command = ApiHelper.DeserializeObject(jsonData.ToString(), commandType, out bool jsonParse, out string jsonParseError);
            if (!jsonParse)
            {
                return jsonParseError;
            }
            #endregion

            #region GetCache
            var cacheResult = command.GetCache(out var readFromCache);
            if (readFromCache)
            {
                return cacheResult;
            }
            #endregion

            #region TokenValidation
            var userToken = Request.Headers["Authorization"];
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            var tokenValid = command.CheckToken(userToken, ip, out var tokenStatus, out var message);
            bool.TryParse(tokenValid.ToString(), out var tokenValidResult);
            if (tokenValidResult != true)
            {
                var commandResponse = new CommandResponse(message, tokenValid, false, tokenStatus);
                return commandResponse;
            }
            #endregion

            #region CommandValidation
            var commandValidation = command.Validation();
            bool.TryParse(commandValidation.ToString(), out var beforeResult);
            if (beforeResult != true)
            {
                var commandResponse = new CommandResponse("An error occurred", commandValidation, false, false);
                return commandResponse;
            }
            #endregion

            #region SetHandler
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);
            var handler = (ICommandHandler)IOC.Container.Resolve(handlerType);
            #endregion

            #region SetCommandVariables
            command.HttpRequest = Request;
            command.ClientIpAddress = ip;
            #endregion

            var result = handler.Handle(command);

            #region SetCache
            ApiHelper.SetCache(result,command);
            #endregion

            return result;
        }

        [HttpGet("/document")]
        public dynamic Document()
        {
            return DocumentHelper.GenerateDocument();
        }

        [HttpGet("/document/{commandName}")]
        public dynamic Document(string commandName)
        {
            return DocumentHelper.GenerateDocument(commandName); ;
        }

        [HttpGet("/document/getpostdata/{commandName}")]
        public dynamic CommandPostData(string commandName)
        {
            if (!Types.ContainsKey(commandName.ToLowerInvariant()))
            {
                return new { Error = "bad command" };
            }
            var commandType = Types[commandName.ToLowerInvariant()];
            var command = Activator.CreateInstance(commandType);
            return command;
        }

        [HttpGet]
        public dynamic Index()
        {
            return "OzerNet V1.0";
        }
    }
}