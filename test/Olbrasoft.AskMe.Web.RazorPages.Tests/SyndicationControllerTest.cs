using System.Text.Encodings.Web;
using Altairis.AskMe.Web.RazorPages.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Olbrasoft.AskMe.Business;
using Xunit;

namespace Altairis.AskMe.Web.RazorPages
{
    /// <summary>
    /// Web syndication is a form of syndication in which content is made available from one website to other sites
    /// https://en.wikipedia.org/wiki/Web_syndication
    /// </summary>
    public class SyndicationControllerTest
    {
        [Fact]
        public void Instance_Inherits_From_Controller()
        {
            var type = typeof(Controller);

            var questionsMock = new Mock<IQuestions>();
            var encoderMock = new Mock<HtmlEncoder>();
            
            var controller = new SyndicationController(encoderMock.Object,questionsMock.Object);
            
            Assert.IsAssignableFrom(type,controller);

        }
    }
}
