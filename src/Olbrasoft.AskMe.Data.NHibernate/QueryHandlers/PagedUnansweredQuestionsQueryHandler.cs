using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using NHibernate;
using Olbrasoft.Mapping;
using Olbrasoft.Paging;
using Olbrasoft.Querying.Mapping.NHibernate;

namespace Olbrasoft.AskMe.Data.NHibernate.QueryHandlers
{
    public class PagedUnansweredQuestionsQueryHandler : QueryHandlerWithMapperAndSessionFactory<PagedUnansweredQuestionsQuery, IResultWithTotalCount<UnansweredQuestionDto>>
    {
        public PagedUnansweredQuestionsQueryHandler(IMapper mapper, ISessionFactory factory) : base(mapper, factory)
        {
        }

        public override async Task<IResultWithTotalCount<UnansweredQuestionDto>> HandleAsync(PagedUnansweredQuestionsQuery query, CancellationToken token)
        {
            var questions = await Session.QueryOver<Question>().Where(p => p.DateAnswered == null)
                .OrderBy(p => p.DateCreated).Desc.Skip(query.Paging.CalculateSkip()).Take(query.Paging.PageSize)
                .ListAsync(token);

            var result = new ResultWithTotalCount<UnansweredQuestionDto>
            {
                Result = MapTo<UnansweredQuestionDto[]>(questions),

                TotalCount = await Session.QueryOver<Question>().Where(p => p.DateAnswered == null).RowCountAsync(token)
            };

            return result;
        }
    }
}