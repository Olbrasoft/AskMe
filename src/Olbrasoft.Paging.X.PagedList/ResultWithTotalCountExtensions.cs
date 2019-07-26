using System;
using X.PagedList;

namespace Olbrasoft.Paging.X.PagedList
{
    public static class ResultWithTotalCountExtensions
    {
        public static IPagedList<T> AsPagedList<T>(this IResultWithTotalCount<T> source, IPageInfo pageInfo)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (pageInfo == null) throw new ArgumentNullException(nameof(pageInfo));

            return new SimplePagedList<T>(source.Result, pageInfo.NumberOfSelectedPage, pageInfo.PageSize, source.TotalCount);
        }
    }
}