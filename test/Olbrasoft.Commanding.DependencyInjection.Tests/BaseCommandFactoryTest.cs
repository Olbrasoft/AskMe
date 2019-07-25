using System;
using System.Linq;
using Xunit;

namespace Olbrasoft.Commanding.DependencyInjection
{
    public class BaseCommandFactoryTest
    {
        private readonly Type _type = typeof(BaseCommandFactory);

        [Fact]
        public void BaseFactory_Is_Abstract_Class()
        {
            var result = _type.IsAbstract;

            Assert.True(result);
        }

        [Fact]
        public void BaseFactory_Implement_Interface_IQueryFactory()
        {
            var result = _type.GetInterfaces().FirstOrDefault(p => p == typeof(ICommandFactory));

            Assert.True(result != null);
        }
    }
}