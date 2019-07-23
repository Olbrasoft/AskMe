namespace Olbrasoft.Commanding.EntityFrameworkCore
{
    public abstract class CommandHandlerWithDbContext<TCommand, TContext> : CommandHandler<TCommand> where TCommand : ICommand
    {
        protected readonly TContext Context;

        protected CommandHandlerWithDbContext(TContext context)
        {
            Context = context;
        }
    }
}