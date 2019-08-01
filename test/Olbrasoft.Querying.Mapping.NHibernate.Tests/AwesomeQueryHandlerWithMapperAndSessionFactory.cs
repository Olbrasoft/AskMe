using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using Olbrasoft.Mapping;

namespace Olbrasoft.Querying.Mapping.NHibernate
{
    public class AwesomeQueryHandlerWithMapperAndSessionFactory :QueryHandlerWithMapperAndSessionFactory<Query<bool>,bool>
    {

        public new ISession Session =>base.Session;
     
        public override Task<bool> HandleAsync(Query<bool> query, CancellationToken token) => throw new System.NotImplementedException();

        public AwesomeQueryHandlerWithMapperAndSessionFactory(IMapper mapper, ISessionFactory factory) : base(mapper, factory)
        {
        }
    }
}