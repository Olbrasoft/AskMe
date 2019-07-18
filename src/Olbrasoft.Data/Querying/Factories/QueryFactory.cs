using Olbrasoft.Dependence;

namespace Olbrasoft.Data.Querying.Factories
{
    public class QueryFactory : IQueryFactory
    {
        protected IResolver ObjectResolver { get; }

        public QueryFactory(IResolver objectResolver)
        {
            ObjectResolver = objectResolver;
        }

        public T Get<T>() where T : IQuery
        {
            return (T)ObjectResolver.Resolve(typeof(T)); 
        }
    }
}