using System.Linq;

namespace Olbrasoft.Data.Mapping
{
    public interface IProjection
    {
        IQueryable<T> ProjectTo<T>(IQueryable source);
    }
}