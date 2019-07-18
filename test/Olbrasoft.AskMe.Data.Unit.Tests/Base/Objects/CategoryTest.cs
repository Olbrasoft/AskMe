using Altairis.AskMe.Data.Base.Objects;
using NUnit.Framework;


namespace Olbrasoft.AskMe.Data.Unit.Tests.Base.Objects
{
    public class CategoryTest
    {
        [Test]
        public void Id()
        {
            //Arrange
            const int id = 1976;

            //Act
            var category = new Category { Id = id };

            //Assert
            Assert.AreEqual(id, category.Id);
        }

        [Test]
        public void Name()
        {
            //Arrange
            const string name = "Some Name";

            //Act
            var category = new Category()
            {
                Name = name
            };

            //Assert
            Assert.AreSame(name, category.Name);
        }
    }
}