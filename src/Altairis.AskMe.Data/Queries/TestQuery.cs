using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Paging;
using Olbrasoft.Querying;

namespace Altairis.AskMe.Data.Queries
{
    public class TestQuery : Query<IResultWithTotalCount<QuestionDto>>
    {
        public TestQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}