using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Commanding
{
    public class AwesomeCommandHandler : CommandHandler<Command>
    {
        public override Task HandleAsync(Command command, CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}