using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Commanding.DependencyInjection
{
    public class BaseCommandExecutorFactoryTest
    {
        private readonly Type _type = typeof(BaseCommandExecutorFactory);

        [Fact]
        public void BaseQueryExecutorFactory_Is_Abstract()
        {
            Assert.True(_type.IsAbstract);
        }

        [Fact]
        public void BaseQueryExecutorFactory_Is_Public()
        {
            Assert.True(_type.IsPublic);
        }

        [Fact]
        public void BaseQueryExecutorFactory_Implement_Interface_IQueryExecutorFactory()
        {
            var result = _type.GetInterfaces().FirstOrDefault(p => p == typeof(ICommandExecutorFactory));

            Assert.True(result != null);
        }
    }
}
