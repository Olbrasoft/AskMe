using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Data.Querying;
using Olbrasoft.Pagination;

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