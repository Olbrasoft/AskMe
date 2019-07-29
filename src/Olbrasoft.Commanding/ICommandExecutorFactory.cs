using System;

namespace Olbrasoft.Commanding
{
    public interface ICommandExecutorFactory
    {
        ICommandExecutor CreateExecutor(Type executor);
    }
}