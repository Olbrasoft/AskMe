using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Moq;
using NUnit.Framework;
using Olbrasoft.Querying;

namespace Olbrasoft.AskMe.Data.Unit.Tests.Queries
{
    public class QuestionByIdQueryTest
    {
        [NUnit.Framework.Test]
        public void Instance_Is_Query_Of_QuestionDto()
        {
            //Arrange
            var type = typeof(Query<QuestionDto>);

            //Act
            var query = QuestionByIdQuery();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void QuestionId()
        {
            //Arrange
            const int id = int.MaxValue;
            var query = QuestionByIdQuery();

            //Act
            query.QuestionId = id;

            //Assert
            Assert.AreEqual(id, query.QuestionId);
        }

        private static QuestionByIdQuery QuestionByIdQuery()
        {
            var dispatcherMock = new Mock<IQueryDispatcher>();

            var query = new QuestionByIdQuery(dispatcherMock.Object);
            return query;
        }
    }
}