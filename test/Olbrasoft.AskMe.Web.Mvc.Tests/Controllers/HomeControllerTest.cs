using System.Threading.Tasks;
using Altairis.AskMe.Web.Mvc;
using Altairis.AskMe.Web.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Business;
using Olbrasoft.AskMe.Data.EntityFrameworkCore;

namespace Olbrasoft.AskMe.Web.Mvc.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Test]
        public void Instance_Is_Controller()
        {
            //Arrange
            var type = typeof(Controller);

            //Act
            var controller = HomeController();

            //Assert
            Assert.IsInstanceOf(type, controller);
        }

        [Test]
        public void Index_Returns_Task_Of_IActionResult()
        {
            //Arrange
            var type = typeof(Task<IActionResult>);
            var controller = HomeController();

            //Act
            var result = controller.Index(1);

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void Questions_Returns_Task_Of_IActionResult()
        {
            //Arrange
            var type = typeof(Task<IActionResult>);
            var controller = HomeController();

            //Act
            var result = controller.Questions(1);

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void Question_Return_Task_Of_IActionResult()
        {
            //Arrange
            var controller = HomeController();

            //Act
            var result = controller.Question(1976);

            //Assert
            Assert.IsInstanceOf<Task<IActionResult>>(result);

        }


        private static HomeController HomeController()
        {
            var facadeMock = new Mock<IAsk>();

            var controller = new HomeController( facadeMock.Object);

            return controller;
        }
    }
}