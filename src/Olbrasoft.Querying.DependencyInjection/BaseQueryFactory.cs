namespace Olbrasoft.Querying.DependencyInjection
{
    public abstract class BaseQueryFactory : IQueryFactory
    {
        public abstract T CreateQuery<T>() where T : IQuery;
    }
}