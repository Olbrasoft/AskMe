using Xunit;

namespace Olbrasoft.Paging
{
    public class PageInfoFact
    {
        [Fact]
        public void Instance_Implement_Interface_IPageInfo()
        {
            //Arrange
            var type = typeof(IPageInfo);

            //Act
            var pageInfo = new PageInfo();

            //Assert
            Assert.IsAssignableFrom(type, pageInfo);
        }

        [Fact]
        public void PageSize()
        {
            //Arrange
            const int pageSize = 1976;

            //Act
            var pageInfo = new PageInfo(pageSize);

            //Assert
            Assert.Equal(pageSize, pageInfo.PageSize);
        }

        [Fact]
        public void NumberOfSelectedPage()
        {
            //Arrange
            const int selectedPage = 19;

            //Act
            var pageInfo = new PageInfo(10, selectedPage);

            //Assert
            Assert.Equal(selectedPage, pageInfo.NumberOfSelectedPage);
        }
    }
}