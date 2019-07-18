using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Data.Querying;
using Olbrasoft.Pagination;

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