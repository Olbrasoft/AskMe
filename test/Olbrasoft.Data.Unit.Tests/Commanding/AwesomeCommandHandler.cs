using System;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data.Commanding;
using Olbrasoft.Data.Mapping;

namespace Olbrasoft.Data.Unit.Tests.Commanding
{
    public class AwesomeCommandHandler : CommandHandler<AwesomeCommand>
    {
        public override Task HandleAsync(AwesomeCommand command, CancellationToken token) => throw new NotImplementedException();
        
    }
}