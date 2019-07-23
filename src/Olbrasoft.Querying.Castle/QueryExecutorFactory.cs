using System;
using Castle.Windsor;

namespace Olbrasoft.Querying.Castle
{
    public class QueryExecutorFactory : IQueryExecutorFactory
    {
        private readonly IWindsorContainer _container;

        public QueryExecutorFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public IQueryExecutor<TResult> Get<TResult>(Type executorType)
        {
            return (IQueryExecutor<TResult>)_container.Resolve(executorType);
        }
    }
}