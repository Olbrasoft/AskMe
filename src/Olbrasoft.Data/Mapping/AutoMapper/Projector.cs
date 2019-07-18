using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Olbrasoft.Data.Mapping.AutoMapper
{
    public class Projector : IProjection
    {
        private readonly IConfigurationProvider _configurationProvider;

        public Projector(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        public IQueryable<T> ProjectTo<T>(IQueryable source)
        {
            return source.ProjectTo<T>(_configurationProvider);
        }
    }
}