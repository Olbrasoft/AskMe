using System;

namespace Olbrasoft.Commanding
{
    public interface ICommandExecutorFactory
    {
        ICommandExecutor Get(Type executorType);
    }
}