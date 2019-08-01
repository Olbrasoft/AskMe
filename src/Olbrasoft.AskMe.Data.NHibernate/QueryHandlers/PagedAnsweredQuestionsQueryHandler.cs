using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using NHibernate;
using NHibernate.Criterion;
using Olbrasoft.Mapping;
using Olbrasoft.Paging;
using Olbrasoft.Querying.Mapping.NHibernate;

namespace Olbrasoft.AskMe.Data.NHibernate.QueryHandlers
{
    public class PagedAnsweredQuestionsQueryHandler : QueryHandlerWithMapperAndSessionFactory<PagedAnsweredQuestionsQuery, IResultWithTotalCount<QuestionDto>>
    {
        public PagedAnsweredQuestionsQueryHandler(IMapper mapper, ISessionFactory factory) : base(mapper, factory)
        {
        }

        public override async Task<IResultWithTotalCount<QuestionDto>> HandleAsync(PagedAnsweredQuestionsQuery query, CancellationToken token)
        {
            var questions = await Session.QueryOver<Question>().Where(p => p.DateAnswered != null)
                .OrderBy(p => p.DateAnswered).Desc.Skip(query.Paging.CalculateSkip()).Take(query.Paging.PageSize)
                .ListAsync(token);

            var result = new ResultWithTotalCount<QuestionDto>
            {
                Result = MapTo<QuestionDto[]>(questions),

                TotalCount = await Session.QueryOver<Question>().Where(p => p.DateAnswered != null).RowCountAsync(token)
            };

            return result;
        }
    }
}