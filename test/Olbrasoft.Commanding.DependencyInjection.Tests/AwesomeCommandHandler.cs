using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Commanding.DependencyInjection
{
    public class AwesomeCommandHandler:CommandHandler<AwesomeCommand>
    {
        public override Task HandleAsync(AwesomeCommand command, CancellationToken token) => throw new NotImplementedException();
    }
}
