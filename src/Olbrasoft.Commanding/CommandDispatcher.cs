﻿using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Commanding
{
    public class CommandDispatcher : ICommandDispatcher
    {
        public CommandDispatcher(ICommandExecutorFactory executorFactory)
        {
            ExecutorFactory = executorFactory;
        }

        protected ICommandExecutorFactory ExecutorFactory { get; }

        public void Dispatch(ICommand command)
        {
            Executor(command).Execute(command);
        }

        public Task DispatchAsync(ICommand command, CancellationToken token)
        {
            return Executor(command).ExecuteAsync(command, token);
        }

        private ICommandExecutor Executor(ICommand command)
        {
           return ExecutorFactory.CreateExecutor(typeof(CommandExecutor<>).MakeGenericType(command.GetType()));
        }
    }
}