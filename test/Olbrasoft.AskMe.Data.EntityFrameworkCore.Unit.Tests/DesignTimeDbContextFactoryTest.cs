using Microsoft.EntityFrameworkCore.Design;
using NUnit.Framework;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests
{
    public class DesignTimeDbContextFactoryTest
    {
        [Test]
        public void Instance_Implement_Interface_IDesignTimeDbContextFactory_Of_AskDbContext()
        {
            //Arrange
            var type = typeof(IDesignTimeDbContextFactory<AskDbContext>);

            //Act
            var factory = ContextFactory();

            //Assert
            Assert.IsInstanceOf(type, factory);
        }

        private static DesignTimeDbContextFactory ContextFactory()
        {
            var factory = new DesignTimeDbContextFactory();
            return factory;
        }

        [Test]
        public void CreateContext()
        {
            //Arrange
            var type = typeof(AskDbContext);
            var args = new string[1];

            //Act
            var context = ContextFactory().CreateDbContext(args);

            //Assert
            Assert.IsInstanceOf(type, context);
        }
    }
}