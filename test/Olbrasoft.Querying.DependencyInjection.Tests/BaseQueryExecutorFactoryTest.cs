using System;
using System.Linq;
using Xunit;

namespace Olbrasoft.Querying.DependencyInjection
{
    public class BaseQueryExecutorFactoryTest
    {
        private readonly Type _type = typeof(BaseQueryExecutorFactory);

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
            var result = _type.GetInterfaces().FirstOrDefault(p => p == typeof(IQueryExecutorFactory));

            Assert.True(result != null);
        }
    }
}