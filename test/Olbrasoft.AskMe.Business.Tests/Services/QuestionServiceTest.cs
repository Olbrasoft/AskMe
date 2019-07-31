using System.Collections.Generic;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Commands;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Business.Services;
using Olbrasoft.Commanding;
using Olbrasoft.CommandingAndQuerying.Business;
using Olbrasoft.Paging;
using Olbrasoft.Querying;

namespace Olbrasoft.AskMe.Business.Tests.Services
{
    public class QuestionServiceTest
    {
        [Test]
        public void Instance_Is_Service()
        {
            //Arrange
            var type = typeof(ServiceWithCommandFactoryAndQueryFactory);

            //Act
            var service = QuestionService();

            //Assert
            Assert.IsInstanceOf(type, service);
        }

        [Test]
        public void Instance_Implement_Interface_IQuestions()
        {
            //Arrange
            var type = typeof(IQuestions);

            //Act
            var service = QuestionService();

            //Assert
            Assert.IsInstanceOf(type, service);
        }

        [Test]
        public void GetAnsweredAsync_Return_Task_Of_IResultWithTotalCount_Of_AnsweredQuestionDto()
        {
            //Arrange
            var service = QuestionService();

            //Act
            var result = service.GetAnsweredAsync(new PageInfo());

            //Assert
            Assert.IsInstanceOf<Task<IResultWithTotalCount<QuestionDto>>>(result);
        }

        [Test]
        public void GetUnansweredAsync_Return_Task_Of_IResultWithTotalCount_Of_UnansweredQuestionDto()
        {
            //Arrange
            var service = QuestionService();

            //Act
            var result = service.GetUnansweredAsync(new PageInfo());

            //Assert
            Assert.IsInstanceOf<Task<IResultWithTotalCount<UnansweredQuestionDto>>>(result);
        }

        [Test]
        public void GetAsync_Return_Task_Of_QuestionDto()
        {
            //Arrange
            var service = QuestionService();

            //Act
            var result = service.GetAsync(1976);

            //Assert
            Assert.IsInstanceOf<Task<QuestionDto>>(result);
        }

        [Test]
        public void GetSyndicationsAsync_Return_Task_Of_IEnumerable_Of_SyndicationQuestionDto()
        {
            //Arrange
            var service = QuestionService();

            //Act
            var result = service.GetSyndicationsAsync(1976);

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<SyndicationQuestionDto>>>(result);
        }

        [Test]
        public void ExistAsync_Return_Task_Of_Boolean()
        {
            //Arrange
            var service = QuestionService();

            //Act
            var result = service.ExistAsync(1976);

            //Assert
            Assert.IsInstanceOf<Task<bool>>(result);
        }

        [Test]
        public void EditAsync_Return_Task()
        {
            //Arrange
            var service = QuestionService();

            //Act
            var result = service.EditAsync(new QuestionDto(), out _);

            //Assert
            Assert.IsInstanceOf<Task>(result);
        }

        private static QuestionService QuestionService()
        {
            var queryDispatcherMock = new Mock<IQueryDispatcher>();

            var dispatcherMock = new Mock<ICommandDispatcher>();

            var commandFactoryMock = new Mock<ICommandFactory>();
            var queryFactoryMock = new Mock<IQueryFactory>();

            commandFactoryMock.Setup(p => p.CreateCommand<UpdateQuestionCommand>())
                .Returns(new UpdateQuestionCommand(dispatcherMock.Object));

            queryFactoryMock.Setup(p => p.CreateQuery<SyndicationQuestionsQuery>())
                .Returns(new SyndicationQuestionsQuery(queryDispatcherMock.Object));

            queryFactoryMock.Setup(p => p.CreateQuery<PagedAnsweredQuestionsQuery>())
                .Returns(new PagedAnsweredQuestionsQuery(queryDispatcherMock.Object));

            queryFactoryMock.Setup(p => p.CreateQuery<PagedUnansweredQuestionsQuery>())
                .Returns(new PagedUnansweredQuestionsQuery(queryDispatcherMock.Object));

            queryFactoryMock.Setup(p => p.CreateQuery<QuestionByIdQuery>())
                .Returns(new QuestionByIdQuery(queryDispatcherMock.Object));

            queryFactoryMock.Setup(p => p.CreateQuery<ExistQuestionQuery>())
                .Returns(new ExistQuestionQuery(queryDispatcherMock.Object));

            var service = new QuestionService(commandFactoryMock.Object, queryFactoryMock.Object);

            return service;
        }
    }
}