namespace Olbrasoft.Querying.DependencyInjection
{
    public abstract class BaseQueryFactory : IQueryFactory
    {
        public abstract T Create<T>() where T : IQuery;
    }
}