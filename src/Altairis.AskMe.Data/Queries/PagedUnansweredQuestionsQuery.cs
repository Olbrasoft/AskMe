using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Pagination;
using Olbrasoft.Querying;

namespace Altairis.AskMe.Data.Queries
{
    public class PagedUnansweredQuestionsQuery : Query<IResultWithTotalCount<UnansweredQuestionDto>>
    {
        public PagedUnansweredQuestionsQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }

        public IPageInfo Paging { get; set; }
    }
}