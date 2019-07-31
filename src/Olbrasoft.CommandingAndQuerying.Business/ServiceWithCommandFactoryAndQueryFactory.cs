using Olbrasoft.Commanding;
using Olbrasoft.Commanding.Business;
using Olbrasoft.Querying;

namespace Olbrasoft.CommandingAndQuerying.Business
{
    public class ServiceWithCommandFactoryAndQueryFactory : ServiceWithCommandFactory
    {
        private readonly IQueryFactory _queryFactory;

        protected TQuery GetQuery<TQuery>() where TQuery : IQuery
        {
            return _queryFactory.CreateQuery<TQuery>();
        }

        public ServiceWithCommandFactoryAndQueryFactory(ICommandFactory commandFactory, IQueryFactory queryFactory) : base(commandFactory)
        {
            _queryFactory = queryFactory;
        }
    }
}