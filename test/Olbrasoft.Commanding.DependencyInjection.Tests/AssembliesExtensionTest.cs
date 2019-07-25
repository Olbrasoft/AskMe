using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Olbrasoft.Commanding.DependencyInjection
{
    public class AssembliesExtensionTest
    {
        private readonly IEnumerable<Assembly> _assemblies = new[] { typeof(AssembliesExtensionTest).Assembly, typeof(Command<>).Assembly };

        [Fact]
        public void GetQueryTypes()
        {
            var queryTypes = _assemblies.GetCommandTypes();

            var count = queryTypes.Count();

            Assert.True(count == 1);
        }

        
        [Fact]
        public void GetQueryHandlerTypes()
        {
            var queryTypes = _assemblies.GetCommandHandlerTypes();

            var count = queryTypes.Count();

            Assert.True(count == 1);
        }
    }
}
