using System;
using Olbrasoft.Dependence;

namespace Olbrasoft.Data.Commanding.Factories
{
    public class CommandExecutorFactory : ICommandExecutorFactory
    {
        public CommandExecutorFactory(IResolver objectResolver)
        {
            ObjectResolver = objectResolver;
        }

        protected IResolver ObjectResolver { get; }


        public ICommandExecutor Get(Type executorType)
        {
            return (ICommandExecutor)ObjectResolver.Resolve(executorType);
        }
    }
}