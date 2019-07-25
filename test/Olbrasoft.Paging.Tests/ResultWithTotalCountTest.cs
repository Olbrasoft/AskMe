using Xunit;

namespace Olbrasoft.Paging
{
    public class ResultWithTotalCountFact
    {
        [Fact]
        public void Instance_Implement_Interface_IResultWithTotalCount()
        {
          //Arrange
            var type = typeof(IResultWithTotalCount<object>);

            //Act
            var pagedResult = new ResultWithTotalCount<object>();

            //Assert
            Assert.IsAssignableFrom(type, pagedResult);
        }

        [Fact]
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
            Assert.IsAssignableFrom<object[]>(objects);
        }

        [Fact]
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
            Assert.IsAssignableFrom<int>(totalCount);
        }
    }
}