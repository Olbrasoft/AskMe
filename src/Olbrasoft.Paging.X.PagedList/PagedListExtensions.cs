namespace Olbrasoft.Paging.X.PagedList
{
    public static class PagedListExtensions
    {
        public static IPagination AsPagination<TSource>(this global::X.PagedList.IPagedList<TSource> sources) =>
            new Pagination(new PageInfo(sources.PageSize, sources.PageNumber), () => sources.TotalItemCount);
    }
}