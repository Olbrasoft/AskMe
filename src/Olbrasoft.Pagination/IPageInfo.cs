namespace Olbrasoft.Pagination
{
    public interface IPageInfo
    { 
        int NumberOfSelectedPage { get; }
        int PageSize { get; }
    }
}