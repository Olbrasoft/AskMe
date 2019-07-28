using System;

namespace Olbrasoft.Querying
{
    public interface IQueryExecutorFactory
    {
        IQueryExecutor<TResult> CreateExecutor<TResult>(Type executorType);
    }
}