using System.Collections.Generic;
using Altairis.AskMe.Data.Transfer.Objects;
using Altairis.AskMe.Web.Mvc.Models.Home;
using Microsoft.AspNetCore.Mvc.Rendering;
using NUnit.Framework;
using Olbrasoft.Paging.X.PagedList;


namespace Olbrasoft.AskMe.Web.Mvc.Tests.Models.Home
{
    public class UnansweredQuestionsModelTest
    {
        [Test]
        public void Categories()
        {
            //Arrange
            IEnumerable<SelectListItem> categories = new List<SelectListItem>();
            var model = UnansweredQuestionsModel();

            //Act
            model.Categories = categories;


            //Assert
            Assert.AreSame(categories,model.Categories);
        }

        [Test]
        public void UnansweredQuestions()
        {
            //Arrange
            IPagedList<UnansweredQuestionDto> questions = new PagedList<UnansweredQuestionDto>(new List<UnansweredQuestionDto>(),1,1,1 );
            var model = UnansweredQuestionsModel();

            //Act
            model.UnansweredQuestions = questions;

            //Assert
            Assert.AreSame(questions,model.UnansweredQuestions);
        }
        
        private static UnansweredQuestionsModel UnansweredQuestionsModel()
        {
            var model = new UnansweredQuestionsModel();
            return model;
        }
    }
}
