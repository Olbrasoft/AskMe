using Microsoft.AspNetCore.Http;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public class QueryFactoryWithHttpContextAccessor : BaseQueryFactory
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public QueryFactoryWithHttpContextAccessor(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public override T Create<T>()
        {
            return (T)_contextAccessor.HttpContext.RequestServices.GetService(typeof(T));
        }
    }
}