using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Commanding
{
    public class Command : ICommand
    {
        public Command(ICommandDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }

        protected ICommandDispatcher Dispatcher { get; }

        public void Execute()
        {
            Dispatcher.Dispatch(this);
        }

        public Task ExecuteAsync(CancellationToken token)
        {
            return Dispatcher.DispatchAsync(this, token);
        }
    }

    public class Command<TData> : Command, ICommand<TData>
    {
        public TData Data { get; set; }

        public Command(ICommandDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}