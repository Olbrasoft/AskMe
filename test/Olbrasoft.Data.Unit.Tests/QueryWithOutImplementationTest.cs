using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;


namespace Olbrasoft.Data.Unit.Tests
{
    [TestFixture]
    internal class QueryWithOutImplementationTest
    {
        private IWindsorContainer _container;

        [SetUp]
        public void Setup()
        {
            _container = new WindsorContainer();
            _container.AddFacility<TypedFactoryFacility>();
            _container.Register(Component.For<IQueryWithOutImplementation>()
                .AsFactory());
        }

        [Test]
        public void Resolve_Is_Instance_of_Type_IQueryWithOutImplementation()
        {
            //Arrange
            var type = typeof(IQueryWithOutImplementation);

            //Act
            var query = _container.Resolve<IQueryWithOutImplementation>();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Resolve_with_set_Id_Error_Get()
        {
            //Arrange
            // const int id = 5;

            //Act
            var query = _container.Resolve<IQueryWithOutImplementation>();

            // var a = query.Name;

            // Assert.IsTrue(query.Id==5);
        }
    }
}