using NHibernate;
using Olbrasoft.Mapping;

namespace Olbrasoft.Querying.Mapping.NHibernate
{
    public abstract class QueryHandlerWithMapperAndSessionFactory<TQuery, TResult> : QueryHandlerWithMapper<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly ISessionFactory _factory;

        protected ISession Session =>  _factory.OpenSession();

        protected QueryHandlerWithMapperAndSessionFactory(IMapper mapper, ISessionFactory factory) : base(mapper)
        {
            _factory = factory;

        }
    }
}