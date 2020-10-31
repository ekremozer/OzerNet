using System;
using System.Collections.Generic;
using System.Text;
using OzerNet.Commands.Commands.Common;

namespace OzerNet.Service.Abstract.Common
{
    public interface ICommonService
    {
        object CreateDatabase(CreateDatabase command, string connectionString);
    }
}
