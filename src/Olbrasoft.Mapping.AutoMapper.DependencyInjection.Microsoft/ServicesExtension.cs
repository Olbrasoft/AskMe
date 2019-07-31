using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.Mapping.AutoMapper.DependencyInjection.Microsoft
{
    public static class ServicesExtension
    {
        public static void AddMapping(this IServiceCollection services, params Assembly[] assemblies)
        {
            if(assemblies.Length>0)  services.AddAutoMapper(assemblies);
            
            services.AddSingleton<IMapper, Mapper>();
            services.AddSingleton<IProjector, Projector>();
        }
    }
}