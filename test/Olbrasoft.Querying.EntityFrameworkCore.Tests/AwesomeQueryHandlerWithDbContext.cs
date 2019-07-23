using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Olbrasoft.Querying.EntityFrameworkCore.Tests
{
    public class AwesomeQueryHandlerWithDbContext : QueryHandlerWithDbContext<Query<bool>, bool, AwesomeEntity, DbContext>
    {
        public override Task<bool> HandleAsync(Query<bool> query, CancellationToken token) => throw new NotImplementedException();

        public AwesomeQueryHandlerWithDbContext(DbContext context) : base(context)
        {
        }

        public void CallBaseEntities()
        {
            Entities();
        }
    }
}