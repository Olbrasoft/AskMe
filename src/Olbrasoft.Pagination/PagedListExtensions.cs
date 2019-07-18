using Olbrasoft.Collections.Generic;

namespace Olbrasoft.Pagination
{
    public static class PagedListExtensions
    {
        public static IPagination AsPagination<TSource>(this IPagedList<TSource> sources) =>
            new Pagination(new PageInfo(sources.PageSize, sources.PageNumber), () => sources.TotalItemCount);
    }
}