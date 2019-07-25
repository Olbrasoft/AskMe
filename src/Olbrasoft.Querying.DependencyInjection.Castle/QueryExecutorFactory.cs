using System;
using Castle.Windsor;

namespace Olbrasoft.Querying.DependencyInjection.Castle
{
    public class QueryExecutorFactory : BaseQueryExecutorFactory
    { 
        private readonly IWindsorContainer _container;

        public QueryExecutorFactory(IWindsorContainer container)
        {
            _container = container;
        }
        
        public override IQueryExecutor<TResult> Get<TResult>(Type executorType)
        {
            return (IQueryExecutor<TResult>)_container.Resolve(executorType);
    
        }
    }
}