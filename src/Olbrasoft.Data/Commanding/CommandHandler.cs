using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data.Mapping;

namespace Olbrasoft.Data.Commanding
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        public void Handle(TCommand command)
        {
            HandleAsync(command).RunSynchronously();
        }

        public Task HandleAsync(TCommand command)
        {
            return HandleAsync(command, default);
        }

        public abstract Task HandleAsync(TCommand command, CancellationToken token);
    }
}