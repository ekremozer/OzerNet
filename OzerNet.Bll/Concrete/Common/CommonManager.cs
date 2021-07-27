using OzerNet.Bll.Abstract.Common;
using OzerNet.Commands.Commands.Common;
using OzerNet.Commands.Infrastructure;
using OzerNet.Service.Abstract.Common;

namespace OzerNet.Bll.Concrete.Common
{
    public class CommonManager : ICommonManager
    {
        private readonly ICommonService _commonService;

        public CommonManager(ICommonService commonService)
        {
            _commonService = commonService;
        }

        public object CreateDatabase(CreateDatabase command, string connectionString, string password)
        {
            if (command.Password != password)
            {
               // return new CommandResponse("Failed", false);
            }

            var serviceResponse = _commonService.CreateDatabase(command, connectionString);
            var createDbResult = bool.TryParse(serviceResponse.ToString(), out _);

            return createDbResult ?
                new CommandResponse("Db Created") :
                new CommandResponse(serviceResponse.ToString(), false);
        }
    }
}
