using Microsoft.Extensions.Options;
using OzerNet.Bll.Abstract.Common;
using OzerNet.Commands.Commands.Common;
using OzerNet.WepApi.Infrastructure;

namespace OzerNet.WepApi.CommandHandlers.Common
{
    public class CreateDatabaseHandler : CommandHandler<CreateDatabase>
    {
        private readonly ICommonManager _commonManager;
        private readonly IOptions<AppSettings> _options;

        public CreateDatabaseHandler(ICommonManager commonManager, IOptions<AppSettings> options)
        {
            _commonManager = commonManager;
            _options = options;
        }

        public override dynamic Handle(CreateDatabase command)
        {
            return _commonManager.CreateDatabase(command, _options.Value.ConnectionStrings.Data, _options.Value.DbCreatePassword);
        }
    }
}
