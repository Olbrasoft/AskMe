using System.Linq;

namespace Olbrasoft.Mapping
{
    public interface IProjection
    {
        IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source);
    }
}