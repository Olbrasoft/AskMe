using NHibernate;
using Olbrasoft.Mapping;

namespace Olbrasoft.Commanding.Mapping.NHibernate
{
    public abstract class CommandHandlerWithMapperAndSessionFactory<TCommand> : CommandHandlerWithMapper<TCommand> where TCommand : ICommand
    {
        private readonly ISessionFactory _factory;

        private ISession _session;

        protected ISession Session => _session ?? (_session = _factory.OpenSession());

        protected CommandHandlerWithMapperAndSessionFactory(IMapper mapper, ISessionFactory factory) : base(mapper)
        {
            _factory = factory;
        }
    }
}