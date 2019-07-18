using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Data.Unit.Tests.Querying
{
    internal class AwesomeNextQueryHandler : Handler<AwesomeQuery, AwesomeSource, object>
    {

        public new AwesomeSource Source => base.Source;

        public AwesomeNextQueryHandler(IProjection projector) : base(projector)
        {
        }


        public new IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source)
        {
            return base.ProjectTo<TDestination>(source);
        }

        public override Task<object> HandleAsync(AwesomeQuery query, CancellationToken token) => throw new NotImplementedException();

        protected override AwesomeSource GetSource() => new AwesomeSource();
    }
}