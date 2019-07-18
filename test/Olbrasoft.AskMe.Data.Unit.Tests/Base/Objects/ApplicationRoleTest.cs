using Altairis.AskMe.Data.Base.Objects;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;

namespace Olbrasoft.AskMe.Data.Unit.Tests.Base.Objects
{
    public class ApplicationRoleTest
    {
        [Test]
        public void Instance_Is_IdentityRole_Of_Integer()
        {
            //Arrange
            var type = typeof(IdentityRole<int>);

            //Act
            var role = new ApplicationRole();

            //Assert
            Assert.IsInstanceOf(type, role);
        }
    }
}