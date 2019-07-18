namespace Olbrasoft.Data
{
    public interface IHaveLanguageId<out T>
    {
        T LanguageId { get; }
    }

    public interface IHaveLanguageId : IHaveLanguageId<int>
    {
    }
}