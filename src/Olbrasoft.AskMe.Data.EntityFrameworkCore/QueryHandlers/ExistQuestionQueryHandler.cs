using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers
{
    public class ExistQuestionQueryHandler : QueryHandler<ExistQuestionQuery, Question, bool>
    {
        public ExistQuestionQueryHandler(AskDbContext context, IProjection projector) : base(context, projector)
        {
        }

        public override Task<bool> HandleAsync(ExistQuestionQuery query, CancellationToken token)
        {
            return Source.AnyAsync(p => p.Id == query.QuestionId, token);
        }
    }
}