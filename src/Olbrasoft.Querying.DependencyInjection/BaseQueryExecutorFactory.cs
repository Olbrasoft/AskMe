using System;

namespace Olbrasoft.Querying.DependencyInjection
{
    public abstract class BaseQueryExecutorFactory :IQueryExecutorFactory
    {
        public abstract IQueryExecutor<TResult> Get<TResult>(Type executorType);
    }
}