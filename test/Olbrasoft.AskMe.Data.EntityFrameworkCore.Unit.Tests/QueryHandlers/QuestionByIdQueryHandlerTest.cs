﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    public class QuestionByIdQueryHandlerTest
    {
        [Test]
        public void Instance_Is_QueryHandler_Of_QuestionByIdQuery_Comma_Question_Comma_QuestionDto()
        {
            //Arrange
            var type = typeof(QueryHandler<QuestionByIdQuery,Question,QuestionDto>);

            //Act
            var handler = QuestionByIdQueryHandler();

            //Assert
            Assert.IsInstanceOf(type,handler);
        }

        [Test]
        public void HandleAsync_Return_Task_Of_QuestionDto()
        {
            //Arrange
            var handler = QuestionByIdQueryHandler();
            var dispatcherMock = new Mock<IQueryDispatcher>(); 
            var query = new QuestionByIdQuery(dispatcherMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf<Task<QuestionDto>>(result);
        }

        private static QuestionByIdQueryHandler QuestionByIdQueryHandler()
        {
            var contextMock = new Mock<AskDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new QuestionByIdQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }
    }
}
