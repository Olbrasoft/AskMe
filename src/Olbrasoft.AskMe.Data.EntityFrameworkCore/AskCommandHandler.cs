using Olbrasoft.Commanding;
using Olbrasoft.Commanding.EntityFrameworkCore;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore
{
    public abstract class AskCommandHandler<TCommand> : CommandHandlerWithDbContext<TCommand,AskDbContext> where TCommand : ICommand
    {
        protected AskCommandHandler(AskDbContext context) : base(context)
        {
        }
    }
}