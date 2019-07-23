using Altairis.AskMe.Data.Base.Objects;
using NUnit.Framework;

namespace Olbrasoft.AskMe.Data.Unit.Tests.Base.Objects
{
    public class QuestionTest
    {
        [Test]
        public void Id()
        {
            //Arrange
            const int id = 1976;

            //Act
            var question = new Question
            {
                Id = id
            };

            //Assert
            Assert.AreEqual(id, question.Id);
        }
    }
}