using System;
using System.Collections.Generic;
using System.Linq;

namespace Olbrasoft.Paging.X.PagedList
{
    public static class EnumerableExtensions
    {
        /// <summary>Returns the input typed as <see cref="T:System.Collections.Generic.IEnumerable`1" />.</summary>
        /// <param name="source">The sequence to type as <see cref="T:System.Collections.Generic.IEnumerable`1" />.</param>
        /// <param name="pagination"></param>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <returns>The input sequence typed as <see cref="T:Olbrasoft.Collections.Generic.SimplePagedList`1" />.</returns>
        public static SimplePagedList<TSource> ToPagedList<TSource>(this IEnumerable<TSource> source, IPagination pagination)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return new SimplePagedList<TSource>(source, pagination.PageInfo.NumberOfSelectedPage, pagination.PageInfo.PageSize, pagination.CountWithOutPaging());
        }

        /// <summary>
        /// Creates a <see cref="SimplePagedList{T}" /> from an <see cref="IEnumerable{TSource}" /> by enumerating.
        /// </summary>
        /// <typeparam name="TSource"> The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source"> An <see cref="IEnumerable{TSource}" /> to create a list from.</param>
        /// <returns>The input sequence typed as <see cref="SimplePagedList{T}" />.</returns>
        public static SimplePagedList<TSource> ToPagedList<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var enumerable = source as TSource[] ?? source.ToArray();

            IPagination pagination = new Pagination(new PageInfo(enumerable.Length), enumerable.Count);

            return enumerable.ToPagedList(pagination);
        }
    }
}