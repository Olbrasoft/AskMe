using System;

namespace Olbrasoft.Data.Commanding
{
    public interface ICommandExecutorFactory
    {
        ICommandExecutor Get(Type executorType);
    }
}