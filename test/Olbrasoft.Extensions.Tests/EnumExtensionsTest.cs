using Xunit;

namespace Olbrasoft.Extensions
{
    public class EnumExtensionsTest
    {
        [Fact]
        public void GetDescription()
        {
            //Arrange
            const string description = "Description of SomeEnumItem";

            //Act
            var result = SomeEnum.SomeEnumItem.GetDescription();

            //Assert
            Assert.True(result == description);
        }
    }
}
