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
    public class PagedAnsweredQuestionsQueryHandler : AskQueryHandler<PagedAnsweredQuestionsQuery, IResultWithTotalCount<QuestionDto>,Question>
    {
        public override async Task<IResultWithTotalCount<QuestionDto>> HandleAsync(PagedAnsweredQuestionsQuery query, CancellationToken token)
        {
            var answeredQuestions = Entities().Include(x => x.Category)
                .Where(x => x.DateAnswered.HasValue)
                .OrderByDescending(x => x.DateAnswered);

            var answeredQuestionsDataTransferObjects = ProjectTo<QuestionDto>(answeredQuestions);

            var result = new ResultWithTotalCount<QuestionDto>
            {
                Result = await answeredQuestionsDataTransferObjects.Skip(query.Paging.CalculateSkip()).Take(query.Paging.PageSize).ToArrayAsync(token),

                TotalCount = await answeredQuestionsDataTransferObjects.CountAsync(token)
            };

            return result;
        }


        public PagedAnsweredQuestionsQueryHandler(IProjector projector, AskDbContext context) : base(projector, context)
        {
        }
    }
}