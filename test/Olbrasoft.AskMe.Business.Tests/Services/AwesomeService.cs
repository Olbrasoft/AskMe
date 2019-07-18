using Olbrasoft.AskMe.Business.Services;
using Olbrasoft.Data.Commanding;
using Olbrasoft.Data.Querying;

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