using System;
using Microsoft.AspNetCore.Http;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public class QueryExecutorFactoryWithHttpContextAccessor : BaseQueryExecutorFactory
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public QueryExecutorFactoryWithHttpContextAccessor(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public override IQueryExecutor<TResult> Get<TResult>(Type executorType)
        {
            return (IQueryExecutor<TResult>)_contextAccessor.HttpContext.RequestServices.GetService(executorType);
        }
    }
}