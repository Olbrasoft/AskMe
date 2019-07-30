using System.Linq;

namespace Olbrasoft.Mapping
{
    public interface IProjector
    {
        IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source);
    }
}