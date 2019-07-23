using System;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers;
using Olbrasoft.Mapping;
using Olbrasoft.Querying;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests
{
    public class AwesomeQueryHandler : AskQueryHandler<Query<bool>,bool,AwesomeEntity>
    {
        public AwesomeQueryHandler(IProjection projector, AskDbContext context) : base(projector, context)
        {
        }

        public override Task<bool> HandleAsync(Query<bool> query, CancellationToken token) => throw new NotImplementedException();
    }
}