using NUnit.Framework;
using System;

namespace Olbrasoft.Data.Unit.Tests
{
    [TestFixture]
    internal class LocalizedQueryTest
    {
        [Test]
        public void Instance_Implement_Interface_ILocalized()
        {
            //Arrange
            var type = typeof(IHaveLanguageId);

            //Act
            var childLocalizeQuery = new ChildLocalizedQuery();

            //Assert
            Assert.IsInstanceOf(type, childLocalizeQuery);
        }

        [Test]
        public void Instance_Implement_Interface_ILocalizedQuery_of_Object()
        {
            //Arrange
            var type = typeof(ILocalizedQuery<object>);

            //Act
            var query = new ChildLocalizedQuery();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void LanguageId()
        {
            //Arrange
            var query = new ChildLocalizedQuery { LanguageId = 1033 };

            //Act
            var result = query.LanguageId;

            //Assert
            Assert.IsTrue(result == 1033);
        }
    }

    internal class ChildLocalizedQuery : LocalizedQuery<object>
    {
        public override object Execute()
        {
            throw new NotImplementedException();
        }
    }
}