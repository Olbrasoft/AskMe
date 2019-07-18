using System.Threading;
using System.Threading.Tasks;
using Moq;
using Olbrasoft.Data.Mapping;

namespace Olbrasoft.Data.Unit.Tests
{
    internal class SomeQueryHandlerWithDependentSource : QueryHandlerWithDependentSource<SomQuery,object, object>
    {
    
        public SomeQueryHandlerWithDependentSource(IHaveQueryable<object> source) : base(source,new Mock<IProjection>().Object)
        {
        }

        public override object Handle(SomQuery query)
        {
            return new object();
            throw new System.NotImplementedException();
        }

        public override Task<object> HandleAsync(SomQuery query, CancellationToken token)
        {



            throw new System.NotImplementedException();
        }
    }
}