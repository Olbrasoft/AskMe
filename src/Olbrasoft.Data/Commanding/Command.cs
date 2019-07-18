using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Commanding
{
    public class Command<TData> : ICommand<TData>
    {
        public Command(ICommandDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
        }

        protected ICommandDispatcher Dispatcher { get; }

        public TData Data { get; set; }
        
        public void Execute()
        {
            Dispatcher.Dispatch(this);
        }

        public Task ExecuteAsync(CancellationToken cancellationToken)
        {
            return Dispatcher.DispatchAsync(this, cancellationToken);
        }

    }
}