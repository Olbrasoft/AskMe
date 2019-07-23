using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Mapping;

namespace Olbrasoft.Querying.Mapping
{
    public class AwesomeQueryHandlerWithProjector : QueryHandlerWithProjector<Query<bool>,bool>
    {
        public override Task<bool> HandleAsync(Query<bool> query, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public void Projection()
        {
            ProjectTo<bool>(new List<bool>().AsQueryable());
        }

        public AwesomeQueryHandlerWithProjector(IProjection projector) : base(projector)
        {
        }
    }
}