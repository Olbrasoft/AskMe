using System;
using System.Linq;
using Xunit;

namespace Olbrasoft.Querying.DependencyInjection
{
    public class BaseQueryFactoryTest
    {
        private readonly Type _type = typeof(BaseQueryFactory);

        [Fact]
        public void BaseFactory_Is_Abstract_Class()
        {
            var result = _type.IsAbstract;

            Assert.True(result);
        }

        [Fact]
        public void BaseFactory_Implement_Interface_IQueryFactory()
        {
            var result = _type.GetInterfaces().FirstOrDefault(p => p == typeof(IQueryFactory));

            Assert.True(result != null);
        }
    }
}