using Microsoft.EntityFrameworkCore;
using Olbrasoft.Mapping;

namespace Olbrasoft.Commanding.Mapping.EntityFrameworkCore
{
    public abstract class CommandHandlerWithMapperAndDbContext<TCommand, TContext> : CommandHandlerWithMapper<TCommand> where TCommand : ICommand where TContext : DbContext
    {
        protected readonly TContext Context;

        protected CommandHandlerWithMapperAndDbContext(IMapper mapper, TContext context) : base(mapper)
        {
            Context = context;
        }
    }
}