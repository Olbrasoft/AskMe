using System;
using Olbrasoft.Dependence;

namespace Olbrasoft.Data.Querying.Factories
{
    public class QueryExecutorFactory : IQueryExecutorFactory
    {
        protected IResolver ObjectResolver { get; }

        public QueryExecutorFactory(IResolver objectResolver)
        {
            ObjectResolver = objectResolver;
        }

        public IQueryExecutor<TResult> Get<TResult>(Type executorType)
        {
            return (IQueryExecutor<TResult>)ObjectResolver.Resolve(executorType);
        }
    }
}