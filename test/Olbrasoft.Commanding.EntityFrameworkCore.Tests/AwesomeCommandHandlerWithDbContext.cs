using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Olbrasoft.Commanding.EntityFrameworkCore
{
    public class AwesomeCommandHandlerWithDbContext : CommandHandlerWithDbContext<Command, DbContext>
    {
        public override Task HandleAsync(Command command, CancellationToken token) => throw new System.NotImplementedException();

        public AwesomeCommandHandlerWithDbContext(DbContext context) : base(context)
        {
        }
    }
}