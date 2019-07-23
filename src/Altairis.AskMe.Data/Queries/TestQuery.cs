using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Pagination;
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