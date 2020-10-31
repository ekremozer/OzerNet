using System;
using System.Collections.Generic;
using System.Text;

namespace OzerNet.Commands.Infrastructure
{
    public static class CommandHelper
    {
        public static void GetSkipTake(this Command command, out int skip, out int take)
        {
            skip = command.PageNumber <= 1 ? 0 : (command.PageNumber - 1) * command.PageSize;
            take = command.PageSize != 0 ? command.PageSize : 20;
        }
    }
}
