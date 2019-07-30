using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Mapping;

namespace Olbrasoft.Commanding.Mapping
{
    public class AwesomeCommandHandlerWithMapper : CommandHandlerWithMapper<Command>
    {
        public AwesomeCommandHandlerWithMapper(IMapper mapper) : base(mapper)
        {
        }

        public new T MapTo<T>(object source) => base.MapTo<T>(source);

        public override Task HandleAsync(Command command, CancellationToken token) => throw new System.NotImplementedException();
    }
}