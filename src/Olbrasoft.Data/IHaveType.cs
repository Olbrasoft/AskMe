namespace Olbrasoft.Data
{
    public interface IHaveType<out T>
    {
        T Category { get; }
    }
}