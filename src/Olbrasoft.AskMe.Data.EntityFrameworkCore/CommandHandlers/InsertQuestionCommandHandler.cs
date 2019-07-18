using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Commands;
using Olbrasoft.Data.Mapping;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.CommandHandlers
{
    public class InsertQuestionCommandHandler : AskCommandHandler<InsertQuestionCommand>
    {
        public InsertQuestionCommandHandler(AskDbContext context) : base( context)
        {
        }

        public override  Task HandleAsync(InsertQuestionCommand command, CancellationToken token)
        {

            return Task.WhenAll(
                Context.Questions.AddAsync(command.Data, token),  
                Context.SaveChangesAsync(token)
            );
        }
    }
}