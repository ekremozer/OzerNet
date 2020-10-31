using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using OzerNet.Commands.Infrastructure;

namespace OzerNet.WepApi.Infrastructure
{
    public interface ICommandHandler
    {
        dynamic Handle(Command command);
    }

    public interface ICommandHandler<in T> : ICommandHandler where T : Command
    {
        dynamic Handle(T command);
    }

    public abstract class CommandHandler<T> : ICommandHandler<T> where T : Command
    {
        public abstract dynamic Handle(T command);

        public dynamic Handle(Command command)
        {
            return Handle((T)command);
        }
    }
}
