using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Pagination;
using Olbrasoft.Querying;

namespace Altairis.AskMe.Data.Queries
{
    public class PagedAnsweredQuestionsQuery : Query<IResultWithTotalCount<QuestionDto>>
    {
        public PagedAnsweredQuestionsQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }

        public IPageInfo Paging { get; set; }
    }
}