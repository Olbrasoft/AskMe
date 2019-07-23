using System;

namespace Olbrasoft.Querying
{
    public interface IQueryExecutorFactory
    {
        IQueryExecutor<TResult> Get<TResult>(Type executorType);
    }
}