namespace Olbrasoft.Data
{
    public interface IHaveAscending<out T>
    {
        T Ascending { get; }
    }

    public interface IHaveAscending : IHaveAscending<int>
    {
    }
}