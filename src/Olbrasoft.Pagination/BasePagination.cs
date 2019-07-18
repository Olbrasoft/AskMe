namespace Olbrasoft.Pagination
{
    public abstract class BasePagination : IPagination
    {
        protected BasePagination(IPageInfo pageInfo)
        {
            PageInfo = pageInfo;
        }

        public IPageInfo PageInfo { get; }

        public abstract int CountWithOutPaging();
    }
}