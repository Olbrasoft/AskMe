using System.Collections.Generic;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Transfer.Objects;
using Moq;
using NUnit.Framework;
using Olbrasoft.Pagination;

namespace Olbrasoft.AskMe.Business.Tests
{
    public class AskFacadeTest
    {
        [Test]
        public void Instance_Implement_Interface_IAsk()
        {
            //Arrange
            var type = typeof(IAsk);

            //Act
            var facade = AskFacade();

            //Assert
            Assert.IsInstanceOf(type, facade);
        }

        private static AskFacade AskFacade()
        {
            var categoriesMock = new Mock<ICategories>();
            var questionsMock = new Mock<IQuestions>();

            var facade = new AskFacade(categoriesMock.Object, questionsMock.Object);
            return facade;
        }

        [Test]
        public void GetCategoriesAsync_Return_Task_Of_IEnumerable_Of_CategoryListItemDto()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<CategoryListItemDto>>);

            //Act
            var result = AskFacade().GetCategoriesAsync();

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void GetAnsweredQuestionsAsync_Return_Task_Of_IResultWithTotalCount_Of_AnsweredQuestionDto()
        {
            //Arrange
            var type = typeof(Task<IResultWithTotalCount<QuestionDto>>);

            //Act
            var result = AskFacade().GetAnsweredQuestionsAsync(new PageInfo());

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void GetUnansweredQuestionsAsync_Return_Task_Of_IResultWithTotalCount_Of_UnansweredQuestionDto()
        {
            //Arrange
            var type = typeof(Task<IResultWithTotalCount<UnansweredQuestionDto>>);

            //Act
            var result = AskFacade().GetUnansweredQuestionsAsync(new PageInfo());

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void GetQuestionAsync_Return_Task_Of_QuestionDto()
        {
            //Arrange
            var type = typeof(Task<QuestionDto>);

            //Act
            var result = AskFacade().GetQuestionAsync(1976);

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void AddAsync_Return_Task()
        {
            //Arrange
            var facade = AskFacade();

            //Act
            var result = facade.AddAsync(new Question());

            //Assert
            Assert.IsInstanceOf<Task>(result);
        }


        [Test]
        public void EditAsync_Return_Task()
        {
            //Arrange
            var facade = AskFacade();

            //Act
            var result = facade.EditAsync(new QuestionDto(),out var notFound);

            //Assert
            Assert.IsInstanceOf<Task>(result);
        }


        [Test]
        public void ExistQuestion_Return_Task_Of_Boolean()
        {
            //Arrange
            var facade = AskFacade();

            //Act
            var result = facade.ExistQuestionAsync(1976);

            //Assert
            Assert.IsInstanceOf<Task<bool>>(result);

        }


        //[Test]
        //public void GetSyndicationQuestions_Return_Task_Of_IEnumerable_Of_SyndicationQuestionDto()
        //{
        //    //Arrange
        //    var facade = AskFacade();

        //    //Act
        //    var result = facade.GetSyndicationQuestionsAsync(1976);

        //    //Assert
        //    Assert.IsInstanceOf <Task<IEnumerable<SyndicationQuestionDto>>> (result);
        //}
    }
}