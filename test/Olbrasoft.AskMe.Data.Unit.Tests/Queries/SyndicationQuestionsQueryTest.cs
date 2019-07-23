using System.Collections.Generic;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Moq;
using NUnit.Framework;
using Olbrasoft.Querying;

namespace Olbrasoft.AskMe.Data.Unit.Tests.Queries
{
    public class SyndicationQuestionsQueryTest
    {
        [Test]
        public void Instance_Is_Query_Of_IEnumerable_Of_SyndicationQuestionDto()
        {
            //Arrange
            var type = typeof(Query<IEnumerable<SyndicationQuestionDto>>);

            //Act
            var query = SyndicationQuestionsQuery();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Take()
        {
            //Arrange
            const int take = int.MaxValue;
            var query = SyndicationQuestionsQuery();

            //Act
            query.Take = take;

            //Assert
            Assert.AreEqual(take, query.Take);
        }

        private static SyndicationQuestionsQuery SyndicationQuestionsQuery()
        {
            var dispatcherMock = new Mock<IQueryDispatcher>();

            var query = new SyndicationQuestionsQuery(dispatcherMock.Object);
            return query;
        }
    }
}