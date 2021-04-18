using Microsoft.Extensions.Options;
using OzerNet.Bll.Abstract.Common;
using OzerNet.Commands.Commands.Common;
using OzerNet.Utility.Infrastructure;
using OzerNet.WepApi.Infrastructure;

namespace OzerNet.WepApi.CommandHandlers.Common
{
    public class CreateDatabaseHandler : CommandHandler<CreateDatabase>
    {
        private readonly ICommonManager _commonManager;

        public CreateDatabaseHandler(ICommonManager commonManager)
        {
            _commonManager = commonManager;
        }

        public override dynamic Handle(CreateDatabase command)
        {
            return _commonManager.CreateDatabase(command, AppParameters.ConnectionString, AppParameters.AppSettings.DbCreatePassword);
        }
    }
}
