using System;
using Microsoft.AspNetCore.Http;

namespace Olbrasoft.Commanding.DependencyInjection.Microsoft
{
    public class CommandExecutorFactoryWithHttpContextAccessor:BaseCommandExecutorFactory
    {

        private readonly IHttpContextAccessor _accessor;

        public CommandExecutorFactoryWithHttpContextAccessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }


        public override ICommandExecutor Get(Type executorType)
        {
            return (ICommandExecutor)_accessor.HttpContext.RequestServices.GetService(executorType);
        }
    }
}