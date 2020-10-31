using System;
using System.Collections.Generic;
using System.Text;
using OzerNet.Commands.Commands.Common;

namespace OzerNet.Bll.Abstract.Common
{
    public interface ICommonManager
    {
        object CreateDatabase(CreateDatabase command, string connectionString,string password);
    }
}
