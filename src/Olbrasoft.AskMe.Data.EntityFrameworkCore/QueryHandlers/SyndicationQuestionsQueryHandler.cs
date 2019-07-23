using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Mapping;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers
{
    public class SyndicationQuestionsQueryHandler : AskQueryHandler<SyndicationQuestionsQuery, IEnumerable<SyndicationQuestionDto>, Question>
    {
        public override async Task<IEnumerable<SyndicationQuestionDto>> HandleAsync(SyndicationQuestionsQuery query, CancellationToken token)
        {
            var q = Entities().Include(x => x.Category)
                .Where(x => x.DateAnswered.HasValue)
                .OrderByDescending(x => x.DateAnswered)
                .Take(query.Take);

            return await ProjectTo<SyndicationQuestionDto>(q).ToArrayAsync(token);
        }

        public SyndicationQuestionsQueryHandler(IProjection projector, AskDbContext context) : base(projector, context)
        {
        }
    }
}