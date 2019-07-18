namespace Olbrasoft.Pagination
{
    public interface IPagination
    {
        IPageInfo PageInfo { get; }

        int CountWithOutPaging();
    }
}