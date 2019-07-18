using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers
{
    public class QuestionByIdQueryHandler : QueryHandler<QuestionByIdQuery, Question, QuestionDto>
    {
        public QuestionByIdQueryHandler(AskDbContext context, IProjection projector) : base(context, projector)
        {
        }

        public override async Task<QuestionDto> HandleAsync(QuestionByIdQuery query, CancellationToken token)
        {
            return await ProjectTo<QuestionDto>(Source.Where(p => p.Id == query.QuestionId)).FirstOrDefaultAsync(token);
        }
    }
}