using Olbrasoft.Collections.Generic;
using System;

namespace Olbrasoft.Pagination
{
    public static class ResultWithTotalCountExtensions
    {
        public static IPagedList<T> AsPagedList<T>(this IResultWithTotalCount<T> source, IPageInfo pageInfo)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (pageInfo == null) throw new ArgumentNullException(nameof(pageInfo));

            return new PagedList<T>(source.Result, pageInfo.NumberOfSelectedPage, pageInfo.PageSize, source.TotalCount);
        }
    }
}