using Olbrasoft.AskMe.Business.Services;
using Olbrasoft.Commanding;
using Olbrasoft.Querying;

namespace Olbrasoft.AskMe.Business.Tests.Services
{
    internal class AwesomeService : Service
    {
        public new IQueryFactory QueryFactory => base.QueryFactory;

        public AwesomeService(ICommandFactory commandFactory, IQueryFactory queryFactory) : base(commandFactory, queryFactory)
        {
        }
    }
}