using Altairis.AskMe.Data.Base.Objects;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;

namespace Olbrasoft.AskMe.Data.Unit.Tests.Base.Objects
{
    public class ApplicationUserTest
    {
        [Test]
        public void Instance_Is_IdentityUser_Of_Integer()
        {
            //Arrange
            var type = typeof(IdentityUser<int>);

            //Act
            var user = new ApplicationUser();

            //Assert
            Assert.IsInstanceOf(type, user);
        }
    }
}