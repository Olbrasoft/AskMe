using System;
using System.Linq;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Data.Unit.Tests
{
    public interface IQueryWithSorting<T, TResult> : IQuery<TResult>
    {
        /// <summary>
        /// Gets a sort criteria applied on this query.
        /// </summary>
        Func<IQueryable<T>, IOrderedQueryable<T>> Sorting { get; set; }
    }
}