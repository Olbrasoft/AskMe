using System;
using Altairis.AskMe.Data.Transfer.Objects;
using NUnit.Framework;

namespace Olbrasoft.AskMe.Data.Unit.Tests.Transfer.Objects
{
    public class QuestionDtoTest
    {

        [Test]
        public void Instance_Is_UnansweredQuestion()
        {
            //Arrange
            var type = typeof(UnansweredQuestionDto);

            //Act
            var question= new QuestionDto();

            //Assert
            Assert.IsInstanceOf(type,question);

        }

        [Test]
        public void DateAnswered()
        {
            //Arrange
            var dateAnswered = DateTime.Now;

            //Act
            var question= new QuestionDto()
            {
                DateAnswered = dateAnswered
            };

            //Assert
            Assert.AreEqual(dateAnswered,question.DateAnswered);
        }

        [Test]
        public void AnswerText()
        {
            //Arrange
            const string answerText = "Some answer text.";

            //Act
            var question = new QuestionDto()
            {
                AnswerText = answerText
            };


            //Assert
            Assert.AreEqual(answerText,question.AnswerText);
        }


        [Test]
        public void Id()
        {
            //Arrange
            const int id = 1976;

            //Act
            var question = new QuestionDto
            {
                Id = id
            };

            //Assert
            Assert.AreEqual(id, question.Id);
        }
    }
}