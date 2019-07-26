using Microsoft.AspNetCore.Http;

namespace Olbrasoft.Commanding.DependencyInjection.Microsoft
{
    public class CommandFactoryWithHttpContextAccessor : BaseCommandFactory
    {

        private readonly IHttpContextAccessor _accessor;

        public CommandFactoryWithHttpContextAccessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public override T Create<T>()
        {

            return (T)_accessor.HttpContext.RequestServices.GetService(typeof(T));
        }
    }
}