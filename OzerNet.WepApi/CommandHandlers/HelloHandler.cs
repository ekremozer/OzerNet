using OzerNet.Commands;
using OzerNet.Commands.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OzerNet.Bll.Abstract.Users;
using OzerNet.Commands.Commands;
using OzerNet.Commands.Commands.Users;
using OzerNet.Dal.EntityFrameWork;
using OzerNet.WepApi.Infrastructure;

namespace OzerNet.WepApi.CommandHandlers
{
    public class HelloHandler : CommandHandler<Hello>
    {
        public override dynamic Handle(Hello command)
        {
            //var password = "ekrem";

            //var pToMd5 = CryptoService.ToMd5(password);
            //var pToSha1 = CryptoService.ToSha1(password);
            //var pToSha256 = CryptoService.ToSha256(password);
            //var pToSha384 = CryptoService.ToSha384(password);
            //var pToSha512 = CryptoService.ToSha512(password);

            //var pToDesEncryption = CryptoService.ToDesEncryption(password);
            //var pToDesDecrypt = CryptoService.ToDesDecrypt(pToDesEncryption);

            //var pToTripleDesEncryption = CryptoService.ToTripleDesEncryption(password);
            //var pToTripleDesDecrypt = CryptoService.ToTripleDesDecrypt(pToTripleDesEncryption);

            //var pToRc2Encryption = CryptoService.ToRc2Encryption(password);
            //var pToRc2Decrypt = CryptoService.ToRc2Decrypt(pToRc2Encryption);

            //var pToTripleDesMd5Encryption = CryptoService.ToTripleDesMd5Encryption(password);
            //var pToTripleDesMd5Decrypt = CryptoService.ToTripleDesMd5Decrypt(pToTripleDesMd5Encryption);

            //var userManager = IOC.Container.Resolve<IUserManager>();
            //var getUser = new GetUser {Uid = new Guid("95DF9C6F-5800-4753-A9D8-6FD4634F00DE")};
            //var user = userManager.GetUser(getUser);

            if (command.IsPaging)
            {
                command.GetSkipTake(out var skip, out var take);
            }
            var result = new
            {
                Response = $"Hello {command.Name}!"
            };

            return result;
        }
    }
}
