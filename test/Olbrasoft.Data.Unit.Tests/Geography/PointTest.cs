using NetTopologySuite.Geometries;
using NUnit.Framework;


namespace Olbrasoft.Data.Unit.Tests.Geography
{
    [TestFixture]
    internal class PointTest
    {
        [Test]
        public void Instance_Implement_Interface_IPoint()
        {
            //Arrange
            var type = typeof(Point);

            //Act
            var point = Point.Empty;

            //Assert
            Assert.IsInstanceOf(type, point);
        }
    }
}