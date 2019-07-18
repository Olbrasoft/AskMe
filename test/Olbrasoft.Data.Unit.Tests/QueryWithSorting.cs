using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Pagination;

namespace Olbrasoft.Data.Unit.Tests
{
    public abstract class QueryWithSorting<T, TResult> : IQueryWithSorting<T, TResult>
    {
        public IPageInfo Paging { get; set; }

        /// <summary>
        ///     Gets a list of sort criteria applied on this query.
        /// </summary>
        public Func<IQueryable<T>, IOrderedQueryable<T>> Sorting { get; set; }


        public TResult Execute()
        {
            throw new NotImplementedException();
        }

        public Task<TResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}