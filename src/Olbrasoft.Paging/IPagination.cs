namespace Olbrasoft.Paging
{
    public interface IPagination
    {
        IPageInfo PageInfo { get; }

        int CountWithOutPaging();
    }
}