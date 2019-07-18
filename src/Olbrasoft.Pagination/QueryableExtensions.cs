using Olbrasoft.Collections.Generic;
using System;
using System.Linq;


namespace Olbrasoft.Pagination
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Creates a <see cref="PagedList{TSource}" /> from an <see cref="IQueryable{TSource}" /> by enumerating.
        /// </summary>
        /// <typeparam name="TSource"> The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source"> An <see cref="IQueryable{TSource}" /> to create a list from.</param>
        /// <param name="paging">Paging information</param>
        /// <returns>The input sequence typed as <see cref="IPagedList{TSource}" />.</returns>

        public static IPagedList<TSource> AsPagedList<TSource>(this IQueryable<TSource> source, IPageInfo paging)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (paging == null)
                throw new ArgumentNullException(nameof(paging));

            var pagedList = new X.PagedList.PagedList<TSource>(source, paging.NumberOfSelectedPage, paging.PageSize);

            return new PagedList<TSource>(pagedList, pagedList.PageNumber, pagedList.PageSize, pagedList.TotalItemCount);
        }
    }
}