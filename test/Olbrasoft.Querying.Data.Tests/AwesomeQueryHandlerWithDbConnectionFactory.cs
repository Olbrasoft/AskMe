using System;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data;

namespace Olbrasoft.Querying.Data
{
    public class AwesomeQueryHandlerWithDbConnectionFactory :QueryHandlerWithDbConnectionFactory<Query<bool>,bool>
    {
        public override Task<bool> HandleAsync(Query<bool> query, CancellationToken token) => throw new NotImplementedException();

        public AwesomeQueryHandlerWithDbConnectionFactory(IDbConnectionFactory factory) : base(factory)
        {
        }

        public void CallGetConnection()
        {
            GetConnection();
        }
    }
}