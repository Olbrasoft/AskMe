using Altairis.AskMe.Web.RazorPages.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using Olbrasoft.AskMe.Business;
using Xunit;

namespace Altairis.AskMe.Web.RazorPages
{
    public class QuestionModelTest
    {
        [Fact]
        public void Instance_Inherits_From_PageModel()
        {
            var serviceMock = new Mock<IQuestions>();

            var model = new QuestionModel(serviceMock.Object);

            Assert.IsAssignableFrom<PageModel>(model);
        }
    }
}