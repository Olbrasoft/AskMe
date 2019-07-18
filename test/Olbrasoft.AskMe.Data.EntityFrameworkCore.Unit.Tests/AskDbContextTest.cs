using Altairis.AskMe.Data.Base.Objects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests
{
    public class AskDbContextTest
    {
        [Test]
        public void Instance_Is_IdentityDbContext_Of_ApplicationUser_Comma_ApplicationRole_Comma_Integer()
        {
            //Arrange
            var type = typeof(IdentityDbContext<ApplicationUser, ApplicationRole, int>);
            var options = new DbContextOptionsBuilder<AskDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            //Act
            var context = new AskDbContext(options);

            //Assert
            Assert.IsInstanceOf(type,context);

        }



    }
}
