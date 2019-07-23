using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Olbrasoft.Mapping.AutoMapper
{
    public class Projector : IProjection
    {
        private readonly IConfigurationProvider _provider;

        public Projector(IConfigurationProvider provider)
        {
            _provider = provider;
        }

        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source)
        {
            return source.ProjectTo<TDestination>(_provider);
        }
    }
}