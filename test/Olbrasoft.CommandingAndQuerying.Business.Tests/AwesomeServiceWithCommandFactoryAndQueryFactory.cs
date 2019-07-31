using Olbrasoft.Commanding;
using Olbrasoft.Querying;

namespace Olbrasoft.CommandingAndQuerying.Business.Tests
{
    public class AwesomeServiceWithCommandFactoryAndQueryFactory : ServiceWithCommandFactoryAndQueryFactory
    {
        public AwesomeServiceWithCommandFactoryAndQueryFactory(ICommandFactory commandFactory, IQueryFactory queryFactory) : base(commandFactory, queryFactory)
        {
        }

        public void CallGetQuery()
        {
            GetQuery<Query<bool>>();
        }
    }
}