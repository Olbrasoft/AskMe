using NUnit.Framework;

namespace Olbrasoft.Pagination.Unit.Tests
{
    public class PageInfoTest
    {
        [Test]
        public void Instance_Implement_Interface_IPageInfo()
        {
            //Arrange
            var type = typeof(IPageInfo);

            //Act
            var pageInfo = new PageInfo();

            //Assert
            Assert.IsInstanceOf(type, pageInfo);
        }

        [Test]
        public void PageSize()
        {
            //Arrange
            const int pageSize = 1976;

            //Act
            var pageInfo = new PageInfo(pageSize);

            //Assert
            Assert.AreEqual(pageSize, pageInfo.PageSize);
        }

        [Test]
        public void NumberOfSelectedPage()
        {
            //Arrange
            const int selectedPage = 19;

            //Act
            var pageInfo = new PageInfo(10, selectedPage);

            //Assert
            Assert.AreEqual(selectedPage, pageInfo.NumberOfSelectedPage);
        }
    }
}