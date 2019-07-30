using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altairis.AskMe.Web.RazorPages.Pages;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Moq;
using Olbrasoft.AskMe.Business;
using Olbrasoft.AskMe.Data.EntityFrameworkCore;
using Xunit;

namespace Altairis.AskMe.Web.RazorPages
{
    public class QuestionsModelTest
    {
        [Fact]
        public void Instance_Is_PageModel()
        {
            var type = typeof(PageModel);
            
            var facadeMock = new Mock<IAsk>();

            var model= new QuestionsModel(facadeMock.Object);

            Assert.IsAssignableFrom(type,model);
        }
    }
}
