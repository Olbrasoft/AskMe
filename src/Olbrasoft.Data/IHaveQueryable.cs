using System.Linq;

namespace Olbrasoft.Data
{
    public interface IHaveQueryable<out T>
    {
        IQueryable<T> Queryable { get; }
    }
}