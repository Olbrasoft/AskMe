using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data.Mapping;

namespace Olbrasoft.Data.Unit.Tests
{
    internal class SomeAsyncQueryHandlerWithDependentSource : AsyncQueryHandlerWithDependentSource<SomQuery,object, object>
    {
        

        public new object Handle(SomQuery query)
        {
            return new object();
            throw new System.NotImplementedException();
        }

        public override Task<object> HandleAsync(SomQuery query, CancellationToken token)
        {
            

            throw new System.NotImplementedException();
        }


        public SomeAsyncQueryHandlerWithDependentSource(IHaveQueryable<object> ownerQueryable, IProjection projector) : base(ownerQueryable, projector)
        {
        }
    }
}