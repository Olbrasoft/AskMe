namespace Olbrasoft.Paging
{
    public interface IResultWithTotalCount<out T>
    {
        T[] Result { get; }
        int TotalCount { get; }
    }
}