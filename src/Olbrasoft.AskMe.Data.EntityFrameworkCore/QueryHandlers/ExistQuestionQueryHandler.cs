using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Microsoft.EntityFrameworkCore;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers
{
    public class ExistQuestionQueryHandler : Querying.EntityFrameworkCore.QueryHandlerWithDbContext<ExistQuestionQuery, bool, Question, AskDbContext>
    {
        public override Task<bool> HandleAsync(ExistQuestionQuery query, CancellationToken token)
        {
            return Entities().AnyAsync(p => p.Id == query.QuestionId, token);
        }

        public ExistQuestionQueryHandler(AskDbContext context) : base(context)
        {
        }
    }
}