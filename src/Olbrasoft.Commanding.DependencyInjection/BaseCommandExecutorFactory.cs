using System;

namespace Olbrasoft.Commanding.DependencyInjection
{
    public abstract class BaseCommandExecutorFactory :ICommandExecutorFactory
    {
        public abstract ICommandExecutor Get(Type executorType);
    }
}