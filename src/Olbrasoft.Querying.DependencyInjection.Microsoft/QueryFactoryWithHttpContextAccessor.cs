using Microsoft.AspNetCore.Http;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public class QueryFactoryWithHttpContextAccessor : BaseQueryFactory
    {
        private readonly IHttpContextAccessor _accessor;

        public QueryFactoryWithHttpContextAccessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public override T Create<T>()
        {
            return (T)_accessor.HttpContext.RequestServices.GetService(typeof(T));
        }
    }
}