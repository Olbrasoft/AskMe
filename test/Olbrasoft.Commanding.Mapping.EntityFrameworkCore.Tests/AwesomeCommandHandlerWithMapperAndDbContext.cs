using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Mapping;

namespace Olbrasoft.Commanding.Mapping.EntityFrameworkCore.Tests
{
    public class AwesomeCommandHandlerWithMapperAndDbContext :CommandHandlerWithMapperAndDbContext<Command,DbContext>
    {
        public new DbContext Context => base.Context;

        public AwesomeCommandHandlerWithMapperAndDbContext(IMapper mapper, DbContext context) : base(mapper, context)
        {
        }

        public override Task HandleAsync(Command command, CancellationToken token) => throw new System.NotImplementedException();
    }
}