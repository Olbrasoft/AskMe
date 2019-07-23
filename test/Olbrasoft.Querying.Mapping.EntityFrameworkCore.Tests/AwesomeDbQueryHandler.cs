using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Mapping;

namespace Olbrasoft.Querying.Mapping.EntityFrameworkCore
{

    public class AwesomeDbQueryHandler : QueryHandlerWithProjectorAndDbContext<Query<bool>,bool,AwesomeEntity,DbContext>
    {
      
        public override Task<bool> HandleAsync(Query<bool> query, CancellationToken token) => throw new System.NotImplementedException();

        public void BuildEntities()
        {
            Entities();
        }

        public AwesomeDbQueryHandler(IProjection projector, DbContext context) : base(projector, context)
        {
        }
    }
}