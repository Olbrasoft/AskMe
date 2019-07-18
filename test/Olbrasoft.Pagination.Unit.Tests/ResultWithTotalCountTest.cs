using NUnit.Framework;

namespace Olbrasoft.Pagination.Unit.Tests
{
    [TestFixture]
    internal class ResultWithTotalCountTest
    {
        [Test]
        public void Instance_Implement_Interface_IResultWithTotalCount()
        {
            //Arrange
            var type = typeof(IResultWithTotalCount<object>);

            //Act
            var pagedResult = new ResultWithTotalCount<object>();

            //Assert
            Assert.IsInstanceOf(type, pagedResult);
        }

        [Test]
        public void Result()
        {
            //Arrange
            var result = new ResultWithTotalCount<object>()
            {
                Result = new[] { new object(), }
            };

            //Act
            var objects = result.Result;

            //Assert
            Assert.IsInstanceOf<object[]>(objects);
        }

        [Test]
        public void TotalCount()
        {
            //Arrange
            var result = new ResultWithTotalCount<int>()
            {
                TotalCount = 100
            };

            //Act
            var totalCount = result.TotalCount;

            //Assert
            Assert.IsInstanceOf<int>(totalCount);
        }
    }
}