using System;

namespace Olbrasoft.Data.Querying
{
    public interface IQueryExecutorFactory
    {
        IQueryExecutor<TResult> Get<TResult>(Type executorType);
    }
}