using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data.Commanding;
using Olbrasoft.Data.Mapping;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.CommandHandlers
{
    public abstract class AskCommandHandler<TCommand> : CommandHandler<TCommand> where TCommand : ICommand
    {
        
        protected AskDbContext Context { get; }


        protected AskCommandHandler( AskDbContext context) 
        {
            Context = context;
        }
    }
}
