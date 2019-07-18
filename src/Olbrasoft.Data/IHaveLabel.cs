namespace Olbrasoft.Data
{
    public interface IHaveLabel<out T>
    {
        T Name { get; }
    }

    public interface IHaveLabel : IHaveLabel<string>
    {
    }
}