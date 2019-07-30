using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Mapping;
using Olbrasoft.Paging;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers
{
    public class PagedUnansweredQuestionsQueryHandler : AskQueryHandler<PagedUnansweredQuestionsQuery, IResultWithTotalCount<UnansweredQuestionDto>, Question>
    {
        public override async Task<IResultWithTotalCount<UnansweredQuestionDto>> HandleAsync(PagedUnansweredQuestionsQuery query, CancellationToken token)
        {
            var unansweredQuestions = Entities().Include(x => x.Category)
                .Where(x => !x.DateAnswered.HasValue)
                .OrderByDescending(x => x.DateCreated);

            var unansweredQuestionsDataTransferObjects = ProjectTo<UnansweredQuestionDto>(unansweredQuestions);

            var result = new ResultWithTotalCount<UnansweredQuestionDto>
            {
                Result = await unansweredQuestionsDataTransferObjects.Skip(query.Paging.CalculateSkip()).Take(query.Paging.PageSize).ToArrayAsync(token),

                TotalCount = await unansweredQuestionsDataTransferObjects.CountAsync(token)
            };

            return result;
        }

        public PagedUnansweredQuestionsQueryHandler(IProjector projector, AskDbContext context) : base(projector, context)
        {
        }
    }
}