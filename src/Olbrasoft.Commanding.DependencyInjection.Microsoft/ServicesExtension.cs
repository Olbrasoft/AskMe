using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.Commanding.DependencyInjection.Microsoft
{
    public static class ServicesExtension
    {
        public static void AddCommandingOnWeb(this IServiceCollection services)
        {
            services.AddSingleton<ICommandFactory, CommandFactoryWithHttpContextAccessor>();

            services.AddScoped(typeof(CommandExecutor<>), typeof(CommandExecutor<>));

            services.AddSingleton<ICommandExecutorFactory, CommandExecutorFactoryWithHttpContextAccessor>();

            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
        }

        /// <summary>
        /// Registration Commanding components
        /// </summary>
        /// <param name="services">Microsoft DependencyInjection Collection</param>
        /// <param name="assemblies">which contain commands and command handlers</param>
        public static void AddCommandingOnWeb(this IServiceCollection services, params Assembly[] assemblies)
        {
            AddCommandingOnWeb(services);

            foreach (var commandType in assemblies.GetCommandTypes())
            {
                services.AddScoped(commandType);
            }

            foreach (var typeInfo in assemblies.GetCommandHandlerTypes())
            {
                services.AddScoped(typeInfo.GetInterfaces().First(), typeInfo);
            }
        }
    }
}