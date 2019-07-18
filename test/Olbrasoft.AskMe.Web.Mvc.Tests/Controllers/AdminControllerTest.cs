using System.Threading.Tasks;
using Altairis.AskMe.Web.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Business;
using Olbrasoft.AskMe.Data.EntityFrameworkCore;

namespace Olbrasoft.AskMe.Web.Mvc.Tests.Controllers
{
    public class AdminControllerTest
    {
        [Test]
        public void Instance_Is_Controller()
        {
            //Arrange
            var type = typeof(Controller);

            //Act

            var controller = CreateController();

            //Assert
            Assert.IsInstanceOf(type, controller);
        }

        [Test]
        public void Index_With_Parameter_QuestionId_Return_Task_Of_IActionResult()
        {
            //Arrange
            var controller = CreateController();
            var type = typeof(Task<IActionResult>);

            //Act
            var result = controller.Index(1976);

            //Assert
            Assert.IsInstanceOf<Task<IActionResult>>(result);
        }


        

        private static AdminController CreateController()
        {
            new Mock<AskDbContext>();
            var facadeMock = new Mock<IAsk>();

            return new AdminController(new FakeUserManager(), new FakeSignInManager(), facadeMock.Object);
        }
    }
}