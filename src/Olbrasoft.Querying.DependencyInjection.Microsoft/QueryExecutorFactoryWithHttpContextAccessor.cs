using System;
using Microsoft.AspNetCore.Http;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public class QueryExecutorFactoryWithHttpContextAccessor : BaseQueryExecutorFactory
    {
        private readonly IHttpContextAccessor _accessor;

        public QueryExecutorFactoryWithHttpContextAccessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public override IQueryExecutor<TResult> Get<TResult>(Type executorType)
        {
            return (IQueryExecutor<TResult>)_accessor.HttpContext.RequestServices.GetService(executorType);
        }
    }
}