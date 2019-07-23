using System.Collections.Generic;
using System.Linq;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Queries;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Querying.EntityFrameworkCore;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    public class ExistQuestionQueryHandlerTest
    {
        [Test]
        public void Instance_Is_QueryHandler_Of_ExistQuestionQuery_Comma_Question_Comma_Boolean()
        {
            //Arrange
            var type = typeof(QueryHandlerWithDbContext<ExistQuestionQuery, bool, Question, AskDbContext>);

            //Act
            var handler = ExistQuestionQueryHandler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        //[Test]
        //public void HandleAsync_Return_Task_Of_Boolean()
        //{
        //    //Arrange
        //    var handler = ExistQuestionQueryHandler();

        //    var dispatcherMock = new Mock<IQueryDispatcher>();
        //    var query = new ExistQuestionQuery(dispatcherMock.Object) {QuestionId = int.MaxValue};

        //    //Act
        //    var result = handler.HandleAsync(query);

        //    //Assert
        //    Assert.IsInstanceOf<Task<bool>>(result);
        //}

        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }

        private static ExistQuestionQueryHandler ExistQuestionQueryHandler()
        {
            var contextMock = new Mock<AskDbContext>();

            contextMock.Setup(p => p.Set<Question>()).Returns(GetQueryableMockDbSet(new List<Question>()));

            var handler = new ExistQuestionQueryHandler(contextMock.Object);
            return handler;
        }
    }
}