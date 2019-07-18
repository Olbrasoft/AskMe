using System.Reflection;
using AutoMapper;

namespace Altairis.AskMe.Data.Mapping
{
    public class MapperConfigurationProvider : MapperConfiguration
    {
        public MapperConfigurationProvider() : base(configure => configure.AddProfiles(Assembly.GetAssembly(typeof(MapperConfigurationProvider))))
        {
        }
    }
}