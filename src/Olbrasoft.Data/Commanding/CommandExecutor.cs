using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Data.Commanding
{
    public class CommandExecutor<TCommand>  : ICommandExecutor where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        
        public CommandExecutor( ICommandHandler<TCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }
        
        public void Execute(ICommand command) 
        {
            _commandHandler.Handle((TCommand)command);
        }

        public Task ExecuteAsync(ICommand command, CancellationToken cancellationToken) 
        {
           return _commandHandler.HandleAsync((TCommand) command, cancellationToken);
        }
    }
}


