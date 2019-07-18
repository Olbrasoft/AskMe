using Altairis.AskMe.Data.Transfer.Objects;
using NUnit.Framework;

namespace Olbrasoft.AskMe.Data.Unit.Tests.Transfer.Objects
{
    public class CategoryListItemDtoTest
    {
        [Test]
        public void Text()
        {
            //Arrange
            const string text = "Awesome text";

            //Act
            var categoryListItem = new CategoryListItemDto()
            {
                Text = text
            };

            //Assert
            Assert.AreEqual(text, categoryListItem.Text);
        }

        [Test]
        public void Value()
        {
            //Arrange
            const int value = 1976;

            //Act
            var categoryListItem = new CategoryListItemDto()
            {
                Value = value
            };

            //Assert
            Assert.AreEqual(value, categoryListItem.Value);
        }
    }
}