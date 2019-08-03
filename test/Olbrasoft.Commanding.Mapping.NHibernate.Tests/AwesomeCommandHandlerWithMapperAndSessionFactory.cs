using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using Olbrasoft.Mapping;

namespace Olbrasoft.Commanding.Mapping.NHibernate
{
    public class AwesomeCommandHandlerWithMapperAndSessionFactory : CommandHandlerWithMapperAndSessionFactory<Command>
    {
        public ISession CallSession() => Session;

        public AwesomeCommandHandlerWithMapperAndSessionFactory(IMapper mapper, ISessionFactory factory) : base(mapper, factory)
        {
        }

        public override Task HandleAsync(Command command, CancellationToken token) => throw new System.NotImplementedException();
    }
}