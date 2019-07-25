using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Olbrasoft.Querying.DependencyInjection
{
    public class AssembliesExtensionTest
    {
        private readonly IEnumerable<Assembly> _assemblies = new[] { typeof(AssembliesExtensionTest).Assembly, typeof(Query<>).Assembly };

        [Fact]
        public void GetQueryTypes()
        {
            var queryTypes = _assemblies.GetQueryTypes();

            var count = queryTypes.Count();

            Assert.True(count == 1);
        }

        [Fact]
        public void GetQueryHandlerTypes()
        {
            var queryTypes = _assemblies.GetQueryHandlerTypes();

            var count = queryTypes.Count();

            Assert.True(count == 1);
        }
    }
}