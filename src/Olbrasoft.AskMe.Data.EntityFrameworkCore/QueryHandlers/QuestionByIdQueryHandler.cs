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
    public class QuestionByIdQueryHandler : AskQueryHandler<QuestionByIdQuery, QuestionDto,Question>
    {
    
        public override async Task<QuestionDto> HandleAsync(QuestionByIdQuery query, CancellationToken token)
        {
            return await ProjectTo<QuestionDto>(Entities().Where(p => p.Id == query.QuestionId)).FirstOrDefaultAsync(token);
        }

        public QuestionByIdQueryHandler(IProjector projector, AskDbContext context) : base(projector, context)
        {
        }
    }
}